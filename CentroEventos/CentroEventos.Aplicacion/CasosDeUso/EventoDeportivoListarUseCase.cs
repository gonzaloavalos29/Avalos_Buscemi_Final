using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoListarUseCase
{
    private readonly IRepositorioEventoDeportivo _repo;

    public EventoDeportivoListarUseCase(IRepositorioEventoDeportivo repo){
        _repo=repo;
    }

    public List<EventoDeportivo> Ejecutar(){
        return _repo.ListarTodos();
    }
}
