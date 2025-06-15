using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona {
    private readonly string archivo = "Personas/personas.csv";
    private readonly string archivoId = "Personas/ultimoId.txt";

    public void Eliminar(int id) {
        if (!File.Exists(archivo)) return;

        var personas = Listar();
        personas = personas.Where(p => p.Id != id).ToList();

        GuardarTodas(personas);
    }

    public void Agregar(Persona persona) {
        persona.Id = ObtenerNuevoId();
        Directory.CreateDirectory("Personas");
        var linea = $"{persona.Id},{persona.Nombre},{persona.Apellido},{persona.DNI},{persona.Email},{persona.Telefono}";
        File.AppendAllLines(archivo, [linea]);
    }

    public List<Persona> Listar() {
        var personas = new List<Persona>();
        if (!File.Exists(archivo)) return personas;
        foreach (var linea in File.ReadAllLines(archivo)) {
            var partes = linea.Split(',');
            if (partes.Length >= 5) {
                personas.Add(new Persona
                {
                    // trim: eliminar espacios en blanco al inicio y al final de una cadena de texto
                    Id = int.Parse(partes[0]),
                    Nombre = partes[1].Trim(),
                    Apellido = partes[2].Trim(),
                    DNI = partes[3].Trim(),
                    Email = partes[4].Trim(),
                    Telefono= partes[5].Trim()
                });
            }
        }
        return personas;
    }

    public void Modificar(Persona persona) {
        var personas = Listar();
        var index = personas.FindIndex(p => p.Id == persona.Id);
        if (index != -1) {
            personas[index] = persona;
            GuardarTodas(personas);
        }
    }

    public Persona? ObtenerPorId(int id) {
        return Listar().FirstOrDefault(p => p.Id == id);
    }

    public Persona? ObtenerPorDni(string dni) {
        return Listar().FirstOrDefault(p => p.DNI == dni);
    }

    public Persona? ObtenerPorEmail(string email) {
        return Listar().FirstOrDefault(p => p.Email == email);
    }

    // Estos métodos necesitan lógica según el dominio,
    // acá pongo implementaciones de ejemplo que siempre retornan false
    public bool TieneReservas(int id) {
        // Implementar la lógica real para saber si la persona tiene reservas
        return false;
    }

    public bool EsResponsable(int id) {
        // Implementar la lógica real para saber si la persona es responsable de algo
        return false;
    }

    private int ObtenerNuevoId() {
        Directory.CreateDirectory("Personas");
        if (!File.Exists(archivoId))
            File.WriteAllText(archivoId, "0");
        int ultimoId = int.Parse(File.ReadAllText(archivoId));
        int nuevoId = ultimoId + 1;
        File.WriteAllText(archivoId, nuevoId.ToString());
        return nuevoId;
    }

    private void GuardarTodas(List<Persona> personas) {
        var lineas = personas.Select(p => $"{p.Id},{p.Nombre},{p.Apellido},{p.DNI},{p.Email},{p.Telefono}");
        File.WriteAllLines(archivo, lineas);
    }
}
