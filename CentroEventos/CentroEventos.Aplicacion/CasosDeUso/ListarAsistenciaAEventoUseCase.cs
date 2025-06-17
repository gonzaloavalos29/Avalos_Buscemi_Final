using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IRepositorioPersona _repoUsuario;
    private readonly IRepositorioReserva _repoReserva;

    public ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IRepositorioReserva repoReserva){
        _repoEventoDeportivo=repoEvento;
        _repoUsuario=repoPersona;
        _repoReserva=repoReserva;
    }

    public List<Persona> Ejecutar(int Id){
        var evento = _repoEventoDeportivo.ObtenerPorId(Id)??throw new EntidadNotFoundException("El evento no existe");

        if(evento.FechaHoraInicio>DateTime.Now) throw new OperacionInvalidaException("El evento no ha ocurrido");

        var ReservasAsistieron= _repoReserva.ListarPorEvento(Id).Where(r=> r.EstadoAsistencia==EstadoAsistencia.Presente).ToList();
        var Usuarios =new  List<Persona>();
        foreach(var r in ReservasAsistieron){
            var usuario = _repoUsuario.ObtenerPorId(r.PersonaId);
            if(usuario!= null ){
                Usuarios.Add(usuario);
            }
        }
        return Usuarios;
    }

}
