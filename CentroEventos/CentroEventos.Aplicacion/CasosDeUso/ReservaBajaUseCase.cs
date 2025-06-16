using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaBajaUseCase
{
    private readonly IRepositorioReserva _repo;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaBajaUseCase(IRepositorioReserva repo, IServicioAutorizacion servicioAutorizacion)
    {
        _repo = repo;
        _servicioAutorizacion = servicioAutorizacion;

    }

    public void Ejecutar(int Id,Guid idUsuario)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
            throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar reservas.");
        var del = _repo.ObtenerPorId(Id) ?? throw new EntidadNotFoundException("Reserva no encontrada");
        _repo.Eliminar(Id);
    }
}
