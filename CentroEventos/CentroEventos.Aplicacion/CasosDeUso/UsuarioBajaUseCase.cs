using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
public class EliminarUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;

    public EliminarUsuarioUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
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
        if (_repo.EsResponsable(idUsuarioAEliminar))
            throw new OperacionInvalidaException("No se puede eliminar: la persona es responsable de un evento.");

        if (_repo.TieneReservas(idUsuarioAEliminar))
            throw new OperacionInvalidaException("No se puede eliminar: la persona tiene reservas.");
        _repo.Eliminar(idUsuarioAEliminar);
    }
}