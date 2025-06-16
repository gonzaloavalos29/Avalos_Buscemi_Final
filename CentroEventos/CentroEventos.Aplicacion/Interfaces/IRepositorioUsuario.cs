using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario {
    void Agregar(Usuario usuario);
    void Modificar(Usuario usuario);
    void Eliminar(int Id);
}