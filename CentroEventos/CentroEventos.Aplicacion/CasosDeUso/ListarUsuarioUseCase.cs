using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ListarUsuariosUseCase
{
    private readonly IRepositorioUsuario _repo;

    public ListarUsuariosUseCase(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public List<Usuario> Ejecutar()
    {
        return _repo.ListarTodos();
    }
}