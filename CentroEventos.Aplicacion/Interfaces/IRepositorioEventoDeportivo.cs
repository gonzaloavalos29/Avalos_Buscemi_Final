using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo {
    void Agregar(EventoDeportivo eventoDeportivo);
    void Modificar(EventoDeportivo eventoDeportivo);
    void Eliminar(int Id);
    List<EventoDeportivo> ListarTodos();
    EventoDeportivo? ObtenerPorId(int Id);
    void Guardar(EventoDeportivo evento);
}
