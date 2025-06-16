using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.VisualBasic;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    private readonly IRepositorioUsuario _repo;

    public ValidadorUsuario(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public void Validar(Usuario usuario, bool esNuevo)
    {
        if (string.IsNullOrWhiteSpace(usuario.nombre))
            throw new ValidacionException("El nombre no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(usuario.apellido))
            throw new ValidacionException("El apellido no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(usuario.email))
            throw new ValidacionException("El email no puede estar vacío.");

        var existente = _repo.ObtenerPorEmail(usuario.email);
        if (existente != null && (esNuevo || existente.id != usuario.id))
            throw new DuplicadoException("Ya existe un usuario con ese email.");
    }

    public void ValidarContraseña(string contraseña)
    {
        if (string.IsNullOrWhiteSpace(contraseña))
            throw new ValidacionException("La contraseña no puede estar vacía.");

        if (contraseña.Length < 8)
            throw new ValidacionException("La contraseña debe tener al menos 8 caracteres.");
    }

    public void ValidacionHash(Usuario usuario, string contraseña)
    {
        string hash =ServicioDeHash.HashSHA256(contraseña);
        if (usuario.hashpassword != hash)
            throw new OperacionInvalidaException("Contraseña incorrecta.");
    }
}