using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public interface IServicioSesionUsuario
{
    Usuario? UsuarioActual { get; }
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
 
}