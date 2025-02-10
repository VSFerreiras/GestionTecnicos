using GestionTecnicos.Models;
using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionTecnicos.Services;

public class TecnicosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
        {
            return await Insertar(tecnico);
        }
        else
        {
            return await Modificar(tecnico);
        }
    }

    private async Task<bool> Existe(int tecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.AnyAsync(t => t.TecnicoId == tecnicoId);
    }

    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tecnicos.Add(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Tecnicos?> Buscar(int tecnidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.FirstOrDefaultAsync(t => t.TecnicoId == tecnidoId);
    }

    public async Task<(bool Success, string Message)> Eliminar(int tecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        bool hasClientes = await contexto.Clientes.AnyAsync(c => c.TecnicoId == tecnicoId);
        if (hasClientes)
        {
            return (false, "El técnico tiene clientes asignados. Reasigne los clientes antes de eliminar.");
        }

        bool deleted =
            await contexto.Tecnicos.AsNoTracking().Where(t => t.TecnicoId == tecnicoId).ExecuteDeleteAsync() > 0;
        return (deleted, deleted ? "Técnico eliminado exitosamente." : "Error al eliminar el técnico.");
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.Where(criterio).AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExisteNombre(string Nombres)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.AnyAsync(t => t.Nombres.ToLower() == Nombres.ToLower());
    }
}