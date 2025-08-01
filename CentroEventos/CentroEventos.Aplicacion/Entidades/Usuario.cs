using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public Guid id { get; set; }
    public string nombre { get; set; } = null!;
    public string apellido { get; set; } = null!;
    public string email { get; set; } = null!;
    public string hashpassword { get; set; } = null!;
    public List<Permiso> permisos { get; set; } = new();
    public bool esAdmin { get; set; } = false; // este campo lo agregamos para q solo pueda editar permisos el admin
}
