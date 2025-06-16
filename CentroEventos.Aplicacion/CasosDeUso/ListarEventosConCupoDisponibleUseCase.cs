using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class ListarEventosConCupoDisponibleUseCase {
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioReserva _repoReserva;

    public ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva) {
        _repoEvento = repoEvento;
        _repoReserva = repoReserva;
    }

    public List<EventoDeportivo> Ejecutar() {
        var eventosFuturos = _repoEvento.ListarTodos().Where(e => e.FechaHoraInicio > DateTime.Now).ToList();
        var resultado = new List<EventoDeportivo>();
        foreach(var evento in eventosFuturos) {
            var reservas = _repoReserva.ListarPorEvento(evento.Id);
            if (reservas.Count() < evento.CupoMaximo)
                resultado.Add(evento);
        }
        return resultado;
    }
}