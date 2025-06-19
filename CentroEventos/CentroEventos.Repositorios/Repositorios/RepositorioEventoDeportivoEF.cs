using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.Repositorios
{
    public class RepositorioEventoEF : IRepositorioEventoDeportivo
    {
        private readonly CentroEventosContext _context;

        public RepositorioEventoEF(CentroEventosContext context)
        {
            _context = context;
        }


        public void Agregar(EventoDeportivo evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
        }

        public void Modificar(EventoDeportivo evento)
        {
            _context.Eventos.Update(evento);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var e = ObtenerPorId(id);
            if (e != null)
            {
                _context.Eventos.Remove(e);
                _context.SaveChanges();
            }
        }



        public EventoDeportivo? ObtenerPorId(int id)
        {
            return _context.Eventos.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public List<EventoDeportivo> ListarTodos()
        {
            return _context.Eventos.AsNoTracking().ToList();
        }
        public void Guardar(EventoDeportivo evento)
        {
            if (evento.Id == 0)
                Agregar(evento);
            else
                Modificar(evento);
        }
    }
}