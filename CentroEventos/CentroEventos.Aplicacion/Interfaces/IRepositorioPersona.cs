using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona {
    void Agregar(Persona persona);
    void Eliminar(int Id);
    void Modificar(Persona persona);
    bool TieneReservas(int Id);
    bool EsResponsable(int Id);
    Persona? ObtenerPorId(int Id);
    Persona? ObtenerPorDni(string DNI);
    Persona? ObtenerPorEmail(string Email);
    List<Persona> Listar();

}