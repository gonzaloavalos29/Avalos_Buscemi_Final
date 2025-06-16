using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; set; }
    public Guid UsuarioId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; } //fecha y hora en la q se realizo la inscripcion
    public EstadoAsistencia EstadoAsistencia { get; set; }
    
}
