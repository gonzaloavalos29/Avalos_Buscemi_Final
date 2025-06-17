using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;
public class UsuarioBajaUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;

    public UsuarioBajaUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Guid idUsuarioAEliminar, Guid idUsuarioLogueado)
    {
        if (!_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException();

        var usuario = _repo.ObtenerPorId(idUsuarioAEliminar)
            ?? throw new EntidadNotFoundException("Usuario no encontrado.");
        _repo.Eliminar(idUsuarioAEliminar);
    }
}