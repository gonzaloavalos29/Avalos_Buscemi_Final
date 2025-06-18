using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Repositorios.Contexto;

public class RepositorioUsuarioEF : IRepositorioUsuario
{
    private readonly CentroEventosContext _context;

    public RepositorioUsuarioEF(CentroEventosContext context)
    {
        _context = context;
    }

    public void Agregar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Modificar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public void Eliminar(Guid id)
    {
        var usuario = ObtenerPorId(id);
        if (usuario != null)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }
    }
    public Usuario? ObtenerPorId(Guid id) => _context.Usuarios.Find(id);
    public Usuario? ObtenerPorEmail(string email) => _context.Usuarios.FirstOrDefault(u => u.email == email);

    public List<Usuario> ListarTodos() => _context.Usuarios.ToList();

}