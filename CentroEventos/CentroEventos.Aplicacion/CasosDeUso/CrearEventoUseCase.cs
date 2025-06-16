using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class CrearEventoUseCase {
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioEventoDeportivo _repositorioEvento;

    private readonly ValidadorEventoDeportivo _validador;

    public CrearEventoUseCase(IServicioAutorizacion servicioAutorizacion, IRepositorioEventoDeportivo repositorioEvento, ValidadorEventoDeportivo validador)
    {
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioEvento = repositorioEvento;
        _validador = validador;
    }

    public void Ejecutar(Guid idUsuario, EventoDeportivo evento) {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para crear eventos.");
        _validador.Validar(evento);
        _repositorioEvento.Guardar(evento);
    }

}
