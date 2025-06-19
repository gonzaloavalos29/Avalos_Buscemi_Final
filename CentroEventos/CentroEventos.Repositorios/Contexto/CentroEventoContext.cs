using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios.Contexto;

public class CentroEventosContext : DbContext
{
    
    public CentroEventosContext() : base()
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<EventoDeportivo> Eventos => Set<EventoDeportivo>();
    public DbSet<Persona> Persona =>Set<Persona>();
    public DbSet<Reserva> Reservas => Set<Reserva>();

    public CentroEventosContext(DbContextOptions<CentroEventosContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentroEventosContext).Assembly);
    }
    
}