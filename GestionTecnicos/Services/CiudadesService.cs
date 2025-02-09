using GestionTecnicos.Models;
using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionTecnicos.Services;

public class CiudadesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.Where(Criterio).AsNoTracking().Include(c => c.Cliente).ToListAsync();
    }

    public async Task<bool> Eliminar(int ciudadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ciudades.AsNoTracking().Where(c => c.CiudadId == ciudadId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Ciudades?> Buscar(int CiudadId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Ciudades.Include(c => c.Cliente).FirstOrDefaultAsync(c => c.CiudadId == CiudadId);
    }

    private async Task<bool> Modificar(Ciudades ciudad)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Ciudades.Update(ciudad);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExisteNombre(int ciudad, string nombre)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Ciudades.AnyAsync(c =>
            c.CiudadId != ciudad && c.CiudadNombre.ToLower().Equals(nombre.ToLower()));
    }

    private async Task<bool> Insertar(Ciudades ciudad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Ciudades.Add(ciudad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int ciudadId)
    {
        await using var Contexto = DbFactory.CreateDbContext();
        return await Contexto.Ciudades.AnyAsync(c => c.CiudadId == ciudadId);
    }

    public async Task<bool> Guardar(Ciudades ciudad)
    {
        if (!await Existe(ciudad.CiudadId))
        {
            return await Insertar(ciudad);
        }
        else
        {
            return await Modificar(ciudad);
        }
    }
}