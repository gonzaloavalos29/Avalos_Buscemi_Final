using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva {
    void Agregar(Reserva reserva);
    void Modificar(Reserva reserva);
    void Eliminar(int Id);
    bool ExisteReserva(int EventoId, int PersonaId);
    Reserva? ObtenerPorId(int Id);
    List<Reserva> Listar();
    List<Reserva> ListarPorEvento(int Id);
}
