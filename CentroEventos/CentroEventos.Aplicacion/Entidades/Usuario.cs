using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public Guid id { get; set; } = Guid.NewGuid(); // identificador único de 128 bits
    public string nombre { get; set; } = null!;
    public string apellido { get; set; } = null!;
    public string email { get; set; } = null!;
    public string hashpassword { get; set; } = null!;
    public List<PermisoUsuario> permisos { get; set; } = new();
}
