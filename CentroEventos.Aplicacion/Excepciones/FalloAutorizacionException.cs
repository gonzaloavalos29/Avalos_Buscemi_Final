namespace CentroEventos.Aplicacion.Excepciones;

public class FalloAutorizacionException:Exception {
    public FalloAutorizacionException(): base("No autorizado"){}
}
