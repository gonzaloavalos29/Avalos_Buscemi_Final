using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class CrearEventoUseCase {
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioEventoDeportivo _repositorioEvento;

    public CrearEventoUseCase(IServicioAutorizacion servicioAutorizacion, IRepositorioEventoDeportivo repositorioEvento) {
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioEvento = repositorioEvento;
    }

    public void Ejecutar(int idUsuario, EventoDeportivo evento) {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para crear eventos.");
        _repositorioEvento.Guardar(evento);
    }

}
