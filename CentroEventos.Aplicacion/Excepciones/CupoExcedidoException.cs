namespace CentroEventos.Aplicacion.Excepciones;

public class CupoExcedidoException:Exception {
    public CupoExcedidoException():base("No hay cupo disponible"){}
}
