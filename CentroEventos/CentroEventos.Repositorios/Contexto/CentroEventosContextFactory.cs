using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CentroEventos.Repositorios.Contexto
{
    public class CentroEventosContextFactory : IDesignTimeDbContextFactory<CentroEventosContext>
    {
        public CentroEventosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CentroEventosContext>();
            optionsBuilder.UseSqlite("Data Source=centroeventos.db");

            return new CentroEventosContext(optionsBuilder.Options);
        }
        
    }
}