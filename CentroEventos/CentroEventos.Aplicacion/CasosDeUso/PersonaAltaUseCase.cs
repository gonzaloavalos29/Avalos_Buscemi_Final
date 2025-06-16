/*using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase
{
    private readonly IRepositorioPersona _repo;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly ValidadorPersona _validador;
    public PersonaAltaUseCase(IRepositorioPersona repo, IServicioAutorizacion servicioAutorizacion)
    {
        _repo = repo;
        _validador = new ValidadorPersona(repo);
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Persona persona, Guid idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para agregar una persona.");
        _validador.Validar(persona);
        _repo.Agregar(persona);
    }
}
*/