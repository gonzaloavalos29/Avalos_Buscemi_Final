using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class UsuarioModificarUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;

    public UsuarioModificarUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Usuario usuario, Guid idUsuarioLogueado, ValidadorUsuario validador)
    {
        if (!_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException();

        var actual = _repo.ObtenerPorId(usuario.id)
            ?? throw new EntidadNotFoundException("Usuario no encontrado.");

        validador.Validar(usuario, esNuevo: false);

        usuario.hashpassword = actual.hashpassword; 
        _repo.Modificar(usuario);
    }
}