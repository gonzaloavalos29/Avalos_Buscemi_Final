using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class ReservaAltaUseCase {
    private readonly IRepositorioReserva _repoReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion servicioAutorizacion) {
        _repoReserva = repoReserva;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva datosReserva, Guid idUsuario, ValidadorReserva validador) {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.ReservaAlta))
            throw new FalloAutorizacionException();
        validador.Validar(datosReserva);
        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;
        _repoReserva.Agregar(datosReserva);
    }
}