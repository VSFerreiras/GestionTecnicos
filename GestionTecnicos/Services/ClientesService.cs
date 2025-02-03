using GestionTecnicos.Models;
using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionTecnicos.Services;

public class ClientesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio){
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.Where(Criterio).AsNoTracking().Include(c => c.Tecnico).ToListAsync();
    }
    
    public async Task<bool> Eliminar(int clienteId){
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AsNoTracking().Where(c => c.ClienteId == clienteId).ExecuteDeleteAsync() > 0;
    }    
    
    public async Task<Clientes?> Buscar(int ClienteId){
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Clientes.Include(c => c.Tecnico).Include(c=>c.Ciudad).FirstOrDefaultAsync(c => c.ClienteId == ClienteId);    }    
    
    private async Task<bool> Modificar(Clientes cliente){
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Clientes.Update(cliente);
        return await Contexto.SaveChangesAsync() > 0;
    }    
    
    public async Task<bool> ExisteNombre(int cliente,string nombre){
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Clientes.AnyAsync(c => c.ClienteId != cliente && c.Nombres.ToLower().Equals(nombre.ToLower()));
    }    
    
    private async Task<bool> Insertar(Clientes cliente){
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }    
    
    public async Task<bool> Existe(int clienteId){
        await using var Contexto = DbFactory.CreateDbContext();
        return await Contexto.Clientes.AnyAsync(c => c.ClienteId == clienteId);
    }
    
    public async Task<bool> ExisteRnc(int ClienteId, string rnc){
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Clientes.AnyAsync(c => c.ClienteId != ClienteId && c.Nombres.ToLower().Equals(rnc.ToLower()));

    }
    
    public async Task<bool> Guardar(Clientes cliente) {
        if (!await Existe(cliente.ClienteId)){
            return await Insertar(cliente);
        }
        else{
            return await Modificar(cliente);
        }
    }

}