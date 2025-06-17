using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class CrearEventoUseCase {
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioEventoDeportivo _repositorioEvento;


    public CrearEventoUseCase(IServicioAutorizacion servicioAutorizacion, IRepositorioEventoDeportivo repositorioEvento)
    {
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioEvento = repositorioEvento;
    }

    public void Ejecutar(Guid idUsuario, EventoDeportivo evento,ValidadorEventoDeportivo validador) {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para crear eventos.");
         validador.Validar(evento);
        _repositorioEvento.Guardar(evento);
    }

}
