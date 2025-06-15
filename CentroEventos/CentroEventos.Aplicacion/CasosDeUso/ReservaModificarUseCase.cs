using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificarUseCase {
    private readonly IRepositorioReserva _repo;
    private readonly IServicioAutorizacion _servicioAutorizacion;


    public ReservaModificarUseCase(IRepositorioReserva repo, IServicioAutorizacion servicioAutorizacion)
    {
        _repo = repo;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva reserva,int idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar reservas.");
        var mod=_repo.ObtenerPorId(reserva.Id)??throw new EntidadNotFoundException("Reserva no encontrada");
        _repo.Modificar(reserva);
    }
}
