using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioAltaUseCase
{
    private readonly IRepositorioUsuario _repo;

    public UsuarioAltaUseCase(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Usuario usuario, string contraseña)
    {
        if (_repo.ObtenerPorEmail(usuario.email) != null)
        {
            throw new DuplicadoException("Ya existe un usuario con ese email");
        }


        if (_repo.ListarTodos().Count == 0)
        {
            usuario.permisos = Enum.GetValues<PermisoUsuario>().ToList();
        }
    }
} 