using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Contexto;

public class RepositorioPersonaEF : IRepositorioPersona
{
    private readonly CentroEventosContext _context;

    public RepositorioPersonaEF(CentroEventosContext context)
    {
        _context = context;
    }

    public void Agregar(Persona usuario)
    {
        _context.Persona.Add(usuario);
        _context.SaveChanges();
    }

    public void Modificar(Persona usuario)
    {
        _context.Persona.Update(usuario);
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var usuario = ObtenerPorId(id);
        if (usuario != null)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }
    }
    public Persona? ObtenerPorId(int id) => _context.Persona.Find(id);
    public Persona? ObtenerPorDni(string DNI) => _context.Persona.FirstOrDefault(u => u.DNI == DNI);

    public Persona? ObtenerPorEmail(string email) => _context.Persona.FirstOrDefault(u => u.Email == email);

    public List<Persona> Listar() => _context.Persona.ToList();

    public bool TieneReservas(int usuarioId)
    {
        return _context.Reservas.Any(r => r.PersonaId == usuarioId);
    }
    public bool EsResponsable(int usuarioId)
    {
        return _context.Eventos.Any(e => e.ResponsableId == usuarioId);
    }
}