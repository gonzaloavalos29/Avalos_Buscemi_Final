using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;
public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo {
    private readonly string archivo = "Eventos/eventos.csv";
    private readonly string archivoId = "Eventos/ultimoId.txt";

    public RepositorioEventoDeportivo()  {
        Directory.CreateDirectory("Eventos");
        if (!File.Exists(archivo)) File.Create(archivo).Dispose();
        if (!File.Exists(archivoId)) File.WriteAllText(archivoId, "0");
    }

    public void Agregar(EventoDeportivo evento) {
        evento.Id = ObtenerNuevoId();
        var linea = $"{evento.Id},{evento.Nombre},{evento.FechaHoraInicio:yyyy-MM-dd HH:mm},{ evento.Lugar},{evento.CupoMaximo},{evento.DuracionHoras},{evento.ResponsableId},{evento.Descripcion}";
        File.AppendAllLines(archivo, [linea]);
    }

    public void Modificar(EventoDeportivo evento) {
        var eventos = ListarTodos();
        var index = eventos.FindIndex(e => e.Id == evento.Id);
        if (index >= 0) {
            eventos[index] = evento;
            GuardarTodos(eventos);
        }
    }

    public void Eliminar(int id) {
        var eventos = ListarTodos().Where(e => e.Id != id).ToList();
        GuardarTodos(eventos);
    }

    public List<EventoDeportivo> ListarTodos() {
        if (!File.Exists(archivo)) return new List<EventoDeportivo>();
        return File.ReadAllLines(archivo)
            .Select(l => l.Split(','))
            .Where(p => p.Length >= 4)
            .Select(p => new EventoDeportivo
            {
                Id = int.Parse(p[0]),
                Nombre = p[1].Trim(),
                FechaHoraInicio = DateTime.Parse(p[2]),
                Lugar = p[3].Trim(),
                CupoMaximo = int.Parse(p[4]),
                DuracionHoras = int.Parse(p[5]),
                ResponsableId = int.Parse(p[6]),
                Descripcion=p[7]
                
            }).ToList();
    }

    public EventoDeportivo? ObtenerPorId(int id) {
        return ListarTodos().FirstOrDefault(e => e.Id == id);
    }

    public void Guardar(EventoDeportivo evento) {
        var eventos = ListarTodos();
        var index = eventos.FindIndex(e => e.Id == evento.Id);
        if (index >= 0)
            eventos[index] = evento;
        else {
            evento.Id = ObtenerNuevoId();
            eventos.Add(evento);
        }
        GuardarTodos(eventos);
    }

    private void GuardarTodos(List<EventoDeportivo> eventos) {
        var lineas = eventos.Select(e => $"{e.Id},{e.Nombre},{e.FechaHoraInicio:yyyy-MM-dd HH:mm},{e.Lugar},{e.CupoMaximo},{e.DuracionHoras},{e.ResponsableId},{e.Descripcion}");
        File.WriteAllLines(archivo, lineas);
    }

    private int ObtenerNuevoId() {
        int ultimoId = int.Parse(File.ReadAllText(archivoId));
        int nuevoId = ultimoId + 1;
        File.WriteAllText(archivoId, nuevoId.ToString());
        return nuevoId;
    }
}
