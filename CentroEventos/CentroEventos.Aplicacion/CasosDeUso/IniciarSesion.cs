using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

public class IniciarSesion
{
    private readonly IRepositorioUsuario _repo;
    private readonly ValidadorUsuario _validador;
    public IniciarSesion(IRepositorioUsuario repo, ValidadorUsuario validador)
    {
        _repo = repo;
        _validador = validador;
    }
    public Usuario Ejecutar(string email, string contraseña)
    {
        var usuario = _repo.ObtenerPorEmail(email)
            ?? throw new EntidadNotFoundException("Usuario no encontrado");

        _validador.ValidarContraseña(contraseña);
        return usuario;
    }
}