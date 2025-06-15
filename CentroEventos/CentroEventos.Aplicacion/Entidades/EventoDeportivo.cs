namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo {
    public int Id{get;set;}
    public string Nombre{get;set;}="";
    public string Descripcion{get;set;}="";
    public string Lugar { get; set; } = "";
    public DateTime FechaHoraInicio { get; set; } //Fecha y hora de cuando inicia el evento
    public double DuracionHoras{get;set;}
    public int CupoMaximo{get;set;}
    public int ResponsableId{get;set;}  //id de la persona responsable
}
