using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo {

    private IRepositorioPersona repoPersona;
    private IRepositorioEventoDeportivo repoEvento;
    public ValidadorEventoDeportivo(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona){
        this.repoEvento = repositorioEventoDeportivo;
        this.repoPersona = repositorioPersona;
    }

    public void Validar(EventoDeportivo eventoDeportivo) {
        var Persona = this.repoPersona.ObtenerPorId(eventoDeportivo.ResponsableId);
        if (Persona == null)
            throw new EntidadNotFoundException("Responsable no encontrado");
        if (eventoDeportivo.CupoMaximo < 0)
            throw new ValidacionException("Cupo Maximo debe ser mayor a 0");
        if (eventoDeportivo.DuracionHoras < 0)
            throw new ValidacionException("El evento debe durar mas de 0 hs");
        if (eventoDeportivo.FechaHoraInicio < DateTime.Now)
            throw new ValidacionException("La Fecha del evento debe ser posterior a la actual");
        if (string.IsNullOrWhiteSpace(eventoDeportivo.Nombre))
            throw new ValidacionException("El evento debe tener un nombre");
        if (string.IsNullOrWhiteSpace(eventoDeportivo.Descripcion))
            throw new ValidacionException("El evento debe tener una descripcion");
    }
}
