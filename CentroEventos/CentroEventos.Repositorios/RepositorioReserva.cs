using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;
public class RepositorioReserva : IRepositorioReserva {
    private readonly string archivo = "Reservas/reservas.csv";
    private readonly string archivoId = "Reservas/ultimoId.txt";

    public RepositorioReserva() {
        Directory.CreateDirectory("Reservas");
        if (!File.Exists(archivo)) File.Create(archivo).Dispose();
        if (!File.Exists(archivoId)) File.WriteAllText(archivoId, "0");
    }

    public void Agregar(Reserva reserva) {
        reserva.Id = ObtenerNuevoId();
        var linea = $"{reserva.Id},{reserva.EventoDeportivoId},{reserva.UsuarioId},{reserva.FechaAltaReserva:yyyy-MM-dd HH:mm},{reserva.EstadoAsistencia}";
        File.AppendAllLines(archivo, new[] { linea });
    }

    public void Modificar(Reserva reserva) {
        var reservas = Listar();
        var index = reservas.FindIndex(r => r.Id == reserva.Id);
        if (index >= 0)
        {
            reservas[index] = reserva;
            GuardarTodas(reservas);
        }
    }

    public void Eliminar(int id) {
        var reservas = Listar().Where(r => r.Id != id).ToList();
        GuardarTodas(reservas);
    }

    public bool ExisteReserva(int eventoId, Guid personaId) {
        return Listar().Any(r => r.EventoDeportivoId == eventoId && r.UsuarioId == personaId);
    }

    public Reserva ObtenerPorId(int id) {
        var reserva = Listar().FirstOrDefault(r => r.Id == id);
        if (reserva == null)
            throw new KeyNotFoundException($"No se encontró reserva con Id {id}");
        return reserva;
    }


    public List<Reserva> Listar() {
        if (!File.Exists(archivo)) return new List<Reserva>();
        return File.ReadAllLines(archivo)
            .Select(l => l.Split(','))
            .Where(p => p.Length >= 4)
            .Select(p => new Reserva
            {
                Id = int.Parse(p[0]),
                EventoDeportivoId = int.Parse(p[1]),
                UsuarioId = Guid.Parse(p[2]),
                FechaAltaReserva = DateTime.Parse(p[3])
                
            }).ToList();
    }

    public List<Reserva> ListarPorEvento(int eventoId) {
        return Listar().Where(r => r.EventoDeportivoId == eventoId).ToList();
    }

    private void GuardarTodas(List<Reserva> reservas) {
        var lineas = reservas.Select(r => $"{r.Id},{r.EventoDeportivoId},{r.UsuarioId},{r.FechaAltaReserva:yyyy-MM-dd HH:mm}");
        File.WriteAllLines(archivo, lineas);
    }

    private int ObtenerNuevoId() {
        int ultimoId = int.Parse(File.ReadAllText(archivoId));
        int nuevoId = ultimoId + 1;
        File.WriteAllText(archivoId, nuevoId.ToString());
        return nuevoId;
    }
}
