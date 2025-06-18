using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase
{
    private readonly IRepositorioPersona _repo;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public PersonaAltaUseCase(IRepositorioPersona repo, IServicioAutorizacion servicioAutorizacion)
    {
        _repo = repo;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Persona persona, Guid idUsuario, ValidadorPersona validador){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.PersonaAlta))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para agregar una persona.");
        validador.Validar(persona);
        _repo.Agregar(persona);
    }
}