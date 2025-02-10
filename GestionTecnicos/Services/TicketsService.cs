using GestionTecnicos.Models;
using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionTecnicos.Services;

public class TicketsService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Tickets ticket)
    {
        if (!await Existe(ticket.TicketId))
        {
            return await Insertar(ticket);
        }
        else
        {
            return await Modificar(ticket);
        }
    }

    public async Task<bool> Existe(int ticketId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Tickets.AnyAsync(t => t.TicketId == ticketId);
    }

    private async Task<bool> Insertar(Tickets ticket)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Tickets.Add(ticket);
        return await Contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tickets ticket)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Tickets.Update(ticket);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<Tickets?> Buscar(int ticketId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Tickets.Include(t => t.Cliente)
            .Include(t => t.Cliente.Tecnico)
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);
    }

    public async Task<bool> Eliminar(int ticketId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Tickets.AsNoTracking().Where(t => t.TicketId == ticketId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Tickets.Where(criterio)
            .AsNoTracking()
            .Include(t => t.Cliente)
            .Include(t => t.Cliente.Tecnico)
            .ToListAsync();
    }
}