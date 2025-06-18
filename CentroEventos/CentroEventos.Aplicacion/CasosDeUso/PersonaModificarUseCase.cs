using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaModificarUseCase
{
    private readonly IRepositorioPersona repositorioPersona;
    private IServicioAutorizacion _servicioAutorizacion;

    public PersonaModificarUseCase(IRepositorioPersona repo, IServicioAutorizacion servicioAutorizacion)
    {
        repositorioPersona = repo;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Persona persona,Guid idUsuario,ValidadorPersona validador){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.PersonaModificar))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar personas.");
        var add = repositorioPersona.ObtenerPorId(persona.Id)?? throw new EntidadNotFoundException("Persona no encontrada");
        validador.Validar(persona);
        repositorioPersona.Modificar(persona);
    }
}