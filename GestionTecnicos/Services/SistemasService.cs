using System.Linq.Expressions;
using GestionTecnicos.DAL;
using GestionTecnicos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTecnicos.Services;

public class SistemasService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Sistemas Sistema)
    {
        if (!await Existe(Sistema.SistemaId))
        {
            return await Insertar(Sistema);
        }
        else
        {
            return await Modificar(Sistema);
        }
    }

    public async Task<bool> Existe(int SistemaId)
    {
        await using var Contexto = DbFactory.CreateDbContext();
        return await Contexto.Sistemas.AsNoTracking().AnyAsync(s => s.SistemaId == SistemaId);
    }

    public async Task<bool> Insertar(Sistemas Sistema)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Sistemas.Add(Sistema);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Sistemas Sistema)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Sistemas.Update(Sistema);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<Sistemas?> Buscar(int SistemaId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Sistemas.AsNoTracking().FirstOrDefaultAsync(s => s.SistemaId == SistemaId);
    }

    public async Task<bool> Eliminar(int SistemaId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Sistemas.AsNoTracking().Where(s => s.SistemaId == SistemaId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Sistemas.Where(criterio).AsNoTracking().ToListAsync();
    }
}