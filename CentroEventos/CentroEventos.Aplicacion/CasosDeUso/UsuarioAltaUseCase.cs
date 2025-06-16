using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

public class CrearUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;
    private readonly ValidadorUsuario _validador;

    public CrearUsuarioUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
        _validador = new ValidadorUsuario(repo);
    }

    public void Ejecutar(Usuario usuario, string contraseña, int idUsuarioLogueado)
    {
        if (_repo.ListarTodos().Count > 0 && !_autorizacion.PoseeElPermiso(idUsuarioLogueado, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException();

        _validador.Validar(usuario, esNuevo: true);
        _validador.ValidarContraseña(contraseña);

        usuario.hashpassword = ServicioDeHash.HashSHA256(contraseña);

        if (_repo.ListarTodos().Count == 0)
            usuario.permisos = Enum.GetValues<Permiso>().ToList(); 

        _repo.Agregar(usuario);
    }
}