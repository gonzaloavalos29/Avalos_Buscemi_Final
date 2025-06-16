using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string nombre { get; set; } = null!;
    public string apellido { get; set; } = null!;
    public string email { get; set; } = null!;
    public string hashpassword { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public List<Permiso> permisos { get; set; } = new();
    public override string ToString()=>$"[{id}], {nombre} {apellido}: DNI: {DNI}, Email: {email}, Telefono: {Telefono}";
}
