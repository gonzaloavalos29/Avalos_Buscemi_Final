using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoModificarUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly ValidadorEventoDeportivo _Validar;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public EventoDeportivoModificarUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo,IServicioAutorizacion servicioAutorizacion,ValidadorEventoDeportivo validar)
    {
        _servicioAutorizacion = servicioAutorizacion;
        _repoEvento = repositorioEventoDeportivo;
        _Validar = validar;
    }

    public void Ejecutar(EventoDeportivo evento,Guid idUsuario)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar eventos.");
        var mod = _repoEvento.ObtenerPorId(evento.Id) ?? throw new EntidadNotFoundException("El evento no existe");
        if (mod.FechaHoraInicio < DateTime.Now) throw new OperacionInvalidaException("No se puede modificar un evento terminado");
        _Validar.Validar(evento);
        _repoEvento.Modificar(evento);
    }
}
