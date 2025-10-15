using GestionTecnicos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTecnicos.DAL;

public class Contexto : DbContext{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Sistemas> Sistemas { get; set; }
}