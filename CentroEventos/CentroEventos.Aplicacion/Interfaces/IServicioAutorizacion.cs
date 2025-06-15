using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion {
    bool PoseeElPermiso(int idUsuario, Permiso permiso);
}
