using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaListarUseCase {
    private readonly IRepositorioReserva _repo;
    public ReservaListarUseCase(IRepositorioReserva repo){
        _repo=repo;
    }

    public List<Reserva> Ejecutar(){
        return _repo.Listar();
    }
}
