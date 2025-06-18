using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class UsuarioAltaUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;


    public UsuarioAltaUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Usuario usuario, string contraseña, Guid idUsuarioLogueado,ValidadorUsuario validador)
    {
        if (_repo.ListarTodos().Count > 0 && !_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException();

        validador.Validar(usuario, esNuevo: true);
        validador.ValidarContraseña(contraseña);

        usuario.hashpassword = ServicioDeHash.HashSHA256(contraseña);

        if (_repo.ListarTodos().Count == 0)
            usuario.permisos = Enum.GetValues<Permiso>().ToList(); 

        _repo.Agregar(usuario);
    }
}