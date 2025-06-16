using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    void Modificar(Usuario usuario);
    void Eliminar(Guid Id);
    Usuario ObtenerPorEmail(string email);

    Usuario ObtenerPorId(Guid id);

    Usuario ObtenerPorDNI(string DNI);

    List<Usuario> ListarTodos();

    bool TieneReservas(Guid personaId);
    bool EsResponsable(Guid personaId);
}