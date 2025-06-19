using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.Data.Sqlite;

namespace CentroEventos.Repositorios.Contexto;

public class CentroEventosContext : DbContext
{

    public CentroEventosContext() : base()
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<EventoDeportivo> Eventos => Set<EventoDeportivo>();
    public DbSet<Persona> Persona => Set<Persona>();
    public DbSet<Reserva> Reservas => Set<Reserva>();

    public CentroEventosContext(DbContextOptions<CentroEventosContext> options) : base(options)
    {
        var connection = (SqliteConnection)Database.GetDbConnection();
        if (connection.State == System.Data.ConnectionState.Closed)
        {
            connection.Open();
        }

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentroEventosContext).Assembly);
    }    
}