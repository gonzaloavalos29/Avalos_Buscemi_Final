using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class RegistrarUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;

    public RegistrarUsuarioUseCase(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Usuario usuario, string contraseña,ValidadorUsuario validador)
    {
        validador.Validar(usuario, esNuevo: true);
        validador.ValidarContraseña(contraseña);

        usuario.hashpassword = ServicioDeHash.HashSHA256(contraseña);

        if (_repo.ListarTodos().Count == 0)
            usuario.permisos = Enum.GetValues<Permiso>().ToList(); 

        _repo.Agregar(usuario);
    }
}