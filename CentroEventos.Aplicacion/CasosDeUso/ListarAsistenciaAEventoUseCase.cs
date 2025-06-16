using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioReserva _repoReserva;

    public ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento
    , IRepositorioPersona repoPersona, IRepositorioReserva repoReserva){
        _repoEventoDeportivo=repoEvento;
        _repoPersona=repoPersona;
        _repoReserva=repoReserva;
    }

    public List<Persona> Ejecutar(int Id){
        var evento = _repoEventoDeportivo.ObtenerPorId(Id)??throw new EntidadNotFoundException("El evento no existe");

        if(evento.FechaHoraInicio>DateTime.Now) throw new OperacionInvalidaException("El evento no ha ocurrido");

        var ReservasAsistieron= _repoReserva.ListarPorEvento(Id).Where(r=> r.EstadoAsistencia==EstadoAsistencia.Presente).ToList();
        var Personas =new  List<Persona>();
        foreach(var r in ReservasAsistieron){
            var persona = _repoPersona.ObtenerPorId(r.Id);
            if(persona!= null ){
                Personas.Add(persona);
            }
        }
        return Personas;
    }

}
