using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    void Modificar(Usuario usuario);
    void Eliminar(Guid Id);
    Usuario? ObtenerPorEmail(string email);

    Usuario? ObtenerPorId(Guid id);

    List<Usuario> ListarTodos();

}