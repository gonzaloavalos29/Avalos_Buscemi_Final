using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

public class IniciarSesion
{
    private readonly IRepositorioUsuario _repo;
    public IniciarSesion(IRepositorioUsuario repo)
    {
        _repo = repo;
    }
    public Usuario Ejecutar(string email, string contraseña)
    {
        var usuario = _repo.ObtenerPorEmail(email)
            ?? throw new EntidadNotFoundException("Usuario no encontrado");

        var Validar = new ValidadorUsuario(_repo);
        Validar.ValidarContraseña(contraseña);
        return usuario;
    }
}