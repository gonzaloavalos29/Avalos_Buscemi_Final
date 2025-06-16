/*using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaModificarUseCase
{
    private readonly IRepositorioPersona repositorioPersona;
    private readonly ValidadorPersona _validador;
    private IServicioAutorizacion _servicioAutorizacion;

    public PersonaModificarUseCase(IRepositorioPersona repo, IServicioAutorizacion servicioAutorizacion)
    {
        repositorioPersona = repo;
        _validador = new ValidadorPersona(repo);
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Persona persona,Guid idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar personas.");
        var add = repositorioPersona.ObtenerPorId(persona.Id)?? throw new EntidadNotFoundException("Persona no encontrada");
        _validador.Validar(persona);
        repositorioPersona.Modificar(persona);
    }
}
*/