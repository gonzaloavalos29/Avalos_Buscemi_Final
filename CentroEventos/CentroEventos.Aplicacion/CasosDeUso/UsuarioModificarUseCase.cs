using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class UsuarioModificarUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;
    private readonly ValidadorUsuario _validador;

    public UsuarioModificarUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
        _validador = new ValidadorUsuario(repo);
    }

    public void Ejecutar(Usuario usuario, Guid idUsuarioLogueado)
    {
        if (!_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException();

        var actual = _repo.ObtenerPorId(usuario.id)
            ?? throw new EntidadNotFoundException("Usuario no encontrado.");

        _validador.Validar(usuario, esNuevo: false);

        usuario.hashpassword = actual.hashpassword; 
        _repo.Modificar(usuario);
    }
}