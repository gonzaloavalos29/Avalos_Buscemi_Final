using CentroEventos.Aplicacion.Entidades;

public class ServicioSesionUsuario : IServicioSesionUsuario
{
    public Usuario? UsuarioActual { get; private set; }

    public void IniciarSesion(Usuario? usuario) => UsuarioActual = usuario;
    public void CerrarSesion() => UsuarioActual = null;

    public bool EstaLogeado => UsuarioActual != null;
}