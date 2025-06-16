using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
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

    public Usuario? ObtenerPorDNI(string DNI) => _context.Usuarios.FirstOrDefault(u => u.DNI == DNI);
    public List<Usuario> ListarTodos() => _context.Usuarios.ToList();
    public bool TieneReservas(Guid usuarioId)
    {
        return _context.Reservas.Any(r => r.UsuarioId == usuarioId);
    }
    public bool EsResponsable(Guid usuarioId)
    {
        return _context.Eventos.Any(e => e.ResponsableId == usuarioId);
    }

}