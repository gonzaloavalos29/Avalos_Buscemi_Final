using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public PersonaBajaUseCase(IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioPersona = repositorioPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(int Id, Guid idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.PersonaBaja))
            throw new UnauthorizedAccessException("El usuario no tiene permiso eliminar una persona");
        var PersonaEliminar =_repositorioPersona.ObtenerPorId(Id)?? throw new EntidadNotFoundException("Persona no encontrada");
        if(_repositorioPersona.EsResponsable(Id)|| _repositorioPersona.TieneReservas(Id))
            throw new OperacionInvalidaException("La persona no puede eliminarse");
        _repositorioPersona.Eliminar(Id);
    }
}