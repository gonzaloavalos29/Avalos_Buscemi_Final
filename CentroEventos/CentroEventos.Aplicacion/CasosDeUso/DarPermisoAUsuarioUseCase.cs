using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;
public class DarPermisoAUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;

    public DarPermisoAUsuarioUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Guid idUsuario, Guid idUsuarioLogueado,List<Permiso> permisos, ValidadorUsuario validador)
    {
        if (!_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioPermiso))
            throw new FalloAutorizacionException();
        var usu = _repo.ObtenerPorId(idUsuario)
          ?? throw new EntidadNotFoundException("Usuario no encontrado.");
        validador.Validar(usu, esNuevo: false);
        _repo.Modificar(usu);
    }
}