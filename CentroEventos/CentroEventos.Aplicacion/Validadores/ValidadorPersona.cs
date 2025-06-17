using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorPersona {
    private readonly IRepositorioPersona _repositorioPersona;
    public ValidadorPersona(IRepositorioPersona repositorioPersona) {
        _repositorioPersona = repositorioPersona;
    }
    public void Validar(Persona persona) {
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            throw new ValidacionException("El Nombre debe completarse");
        if (string.IsNullOrWhiteSpace(persona.Apellido))
            throw new ValidacionException("El Apellido debe completarse");
        if (string.IsNullOrWhiteSpace(persona.DNI))
            throw new ValidacionException("El DNI debe completarse");
        if (string.IsNullOrWhiteSpace(persona.Email))
            throw new ValidacionException("El Email debe completarse");

        var Email = _repositorioPersona.ObtenerPorEmail(persona.Email);
        var DNI = _repositorioPersona.ObtenerPorDni(persona.DNI);

        if (Email != null && Email.Id != persona.Id)
            throw new DuplicadoException("Ya existe una persona con ese Email");
        if (DNI != null && DNI.Id != persona.Id)
            throw new DuplicadoException("Ya existe una persona con ese DNI");
    }
}