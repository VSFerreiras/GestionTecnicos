using GestionTecnicos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTecnicos.DAL;

public class Contexto : DbContext{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
}