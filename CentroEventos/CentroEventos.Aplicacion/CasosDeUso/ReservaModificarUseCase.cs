using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificarUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaModificarUseCase( IRepositorioReserva repoReserva, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicioAutorizacion)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEvento = repoEvento;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva reserva, Guid idUsuario)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar reservas.");

        var actual = _repoReserva.ObtenerPorId(reserva.Id)
            ?? throw new EntidadNotFoundException("Reserva no encontrada.");

        if (_repoPersona.ObtenerPorId(reserva.PersonaId) is null)
            throw new EntidadNotFoundException("Persona asociada a la reserva no existe.");


        if (_repoEvento.ObtenerPorId(reserva.EventoDeportivoId) is null)
            throw new EntidadNotFoundException("Evento asociado a la reserva no existe.");

        _repoReserva.Modificar(reserva);
    }
}