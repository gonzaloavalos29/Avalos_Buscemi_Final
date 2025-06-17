using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Contexto;
using Microsoft.EntityFrameworkCore;

public class RepositorioReservaEF : IRepositorioReserva
{
    private readonly CentroEventosContext _context;

    public RepositorioReservaEF(CentroEventosContext context)
    {
        _context = context;
    }

    public void Agregar(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
    }

    public void Modificar(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var reserva = ObtenerPorId(id);
        if (reserva != null)
        {
            _context.Remove(reserva);
            _context.SaveChanges();
        }
    }
    public bool ExisteReserva( int eventoId,int usuarioId)=> _context.Reservas.Any(r => r.PersonaId == usuarioId && r.EventoDeportivoId == eventoId);
    public Reserva? ObtenerPorId(int id) => _context.Reservas.AsNoTracking().FirstOrDefault(r => r.Id == id);

    public List<Reserva> Listar() => _context.Reservas.AsNoTracking().ToList();

   public List<Reserva> ListarPorEvento(int eventoId)=> _context.Reservas.AsNoTracking().Where(r => r.EventoDeportivoId == eventoId).ToList();
    
}