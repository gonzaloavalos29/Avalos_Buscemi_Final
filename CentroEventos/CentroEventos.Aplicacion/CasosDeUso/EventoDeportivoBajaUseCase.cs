using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEvento;
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva,IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioEvento = repositorioEventoDeportivo;
        _repositorioReserva = repositorioReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(int Id,Guid idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar eventos.");
        var del= _repositorioEvento.ObtenerPorId(Id)??throw new EntidadNotFoundException("Evento no encontrado");
        if(_repositorioReserva.ListarPorEvento(Id).Any())throw new OperacionInvalidaException("No se Puede eliminar un evento con reservas asociadas");
        _repositorioEvento.Eliminar(Id);
    }
}
