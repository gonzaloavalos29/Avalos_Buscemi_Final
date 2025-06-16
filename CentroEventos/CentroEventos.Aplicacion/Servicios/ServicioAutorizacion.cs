using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IRepositorioUsuario _repo;

    public ServicioAutorizacion(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public bool PoseeElPermiso(Guid idUsuario, Permiso permiso)
    {
        var usuario = _repo.ObtenerPorId(idUsuario);
        if (usuario == null )
            return false;

        return usuario.permisos.Contains(permiso);
    }
}