using CentroEventos.Aplicacion.Entidades;

public class ServicioSesionUsuario : IServicioSesionUsuario
{
    public Usuario? UsuarioActual { get; set; }

    public void IniciarSesion(Usuario usuario) => UsuarioActual = usuario;
    public void CerrarSesion() => UsuarioActual = null;
}