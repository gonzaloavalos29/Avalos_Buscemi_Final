
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using System.Collections;
using System.Data.Common;
using CentroEventos.Aplicacion.Servicios;

// Crear una instancia del repositorio
var repo = new RepositorioPersona();
var repoevento = new RepositorioEventoDeportivo();
var repoReserva = new RepositorioReserva();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();
int idAutorizado = 1;
Boolean ok = true;
    Console.WriteLine("0: Finalizar");
    Console.WriteLine("1: Agregar Persona:");
    Console.WriteLine("2: Agregar Evento Deportivo: ");
    Console.WriteLine("3: Agregar Reserva: ");
    Console.WriteLine("4: Eliminar Persona: ");
    Console.WriteLine("5: Eliminar Evento Deportivo: ");
    Console.WriteLine("6: Eliminar Reserva: ");  
    Console.WriteLine("7: Modificar Persona: ");
    Console.WriteLine("8: Modificar Evento Deportivo: ");
    Console.WriteLine("9: Modificar Reserva: ");
    Console.WriteLine("10: Listar Persona: ");
    Console.WriteLine("11: Listar Evento Deportivo: ");
    Console.WriteLine("12: Listar Reserva: ");
    Console.WriteLine("13: Listar asistencia a Evento: ");
    Console.WriteLine("14: Listar Eventos con cupo disponible: ");
while (ok)
{
    Console.WriteLine("Que accion quiere realizar?: ");
    Console.WriteLine("Para ver el menu presione 15 ");
    string? operacion = Console.ReadLine();

    switch (operacion)
    {
        case "0":
            ok = false;
            Console.WriteLine("Programa Finalizado con exito. ");
            break;
        case "1":
            Console.WriteLine("== Agregar persona ==");
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string? apellido = Console.ReadLine();

            Console.Write("DNI: ");
            string? dni = Console.ReadLine();

            Console.Write("Email: ");
            string? email = Console.ReadLine();

            Console.Write("Telefono: ");
            string? telefono = Console.ReadLine();

            // Agregar una persona
            var persona = new Persona {
                Nombre = nombre ?? "",
                Apellido = apellido ?? "",
                DNI = dni ?? "",
                Email = email ?? "",
                Telefono = telefono ?? ""
            };

            var agregarPersona = new PersonaAltaUseCase(repo,servicioAutorizacion);
            agregarPersona.Ejecutar(persona,idAutorizado);
            Console.WriteLine($"Persona agregada con ID: {persona.Id}");
            break;
        case "2":

            Console.WriteLine("\n=== Alta de Evento ===");
            Console.Write("Nombre del Evento: ");
            string? nombreEvento = Console.ReadLine();
            Console.Write("Descripcion del Evento: ");
            string? desc = Console.ReadLine();
            Console.Write("Fecha de inicio del Evento: ");
            string? Fecha = Console.ReadLine();
            Console.Write("Duracion en horas del Evento: ");
            string? Duracion = Console.ReadLine();
            Console.Write("ID del responsable del Evento: ");
            string? Id = Console.ReadLine();
            Console.Write("Cupo maximo del Evento: ");
            string? capacidad = Console.ReadLine();
            Console.WriteLine("Lugar del evento: ");
            string? donde = Console.ReadLine();
            if (DateTime.TryParse(Fecha, out DateTime fecha))
                Console.WriteLine("Fecha válida: " + fecha.ToShortDateString());
            else
                Console.WriteLine("Fecha inválida. Intente nuevamente.");
            if (int.TryParse(Duracion, out int dura))
                Console.WriteLine("Duracion correcta");
            else
                Console.WriteLine("Duracion invalida");
            if (int.TryParse(Id, out int id))
                Console.WriteLine("Id valido");
            else
                Console.WriteLine("ID invalido");
            if (int.TryParse(capacidad, out int cupo))
                Console.WriteLine("Cupo valido");
            else
                Console.WriteLine("Cupo invalido");
            var evento = new EventoDeportivo {
                Nombre = nombreEvento ?? "",
                Descripcion = desc ?? "",
                FechaHoraInicio = fecha,
                Lugar = donde ?? "",
                DuracionHoras = dura,
                CupoMaximo = cupo,
                ResponsableId = id
            };
            var crearEvento = new EventoDeportivoAltaUseCase(repoevento, repo,servicioAutorizacion);
            crearEvento.Ejecutar(evento,idAutorizado);
            break;
        case "3":
            //Reserva Alta
            Console.WriteLine("Insertar Id de la persona q quiere hacer la reserva: ");
            string? idPersonaReserva = Console.ReadLine();
            Console.WriteLine("Insertar Id del evento a reservar: ");
            string? idEventoReserva = Console.ReadLine();
            if (int.TryParse(idPersonaReserva, out int PersonaReservaId)){}
            else
                Console.WriteLine("ID de la persona q quiere reservar invalido");
            if (int.TryParse(idEventoReserva, out int EventoReservaId)){}
            else
                Console.WriteLine("ID del evento q quiere reservar invalido");
            var AgregarReserva = new ReservaAltaUseCase(repoReserva, repoevento, repo, servicioAutorizacion);
            var reserva = new Reserva() {
                PersonaId = PersonaReservaId,
                EventoDeportivoId = EventoReservaId
            };
            AgregarReserva.Ejecutar(reserva, idAutorizado);
            break;
        case "4":
            // Eliminar persona
            Console.WriteLine("Ingrese Id de la persona a eliminar: ");
            string? inputEliminar = Console.ReadLine();
            if (inputEliminar != "") {
                if (int.TryParse(inputEliminar, out int idEliminar)) {
                    var eliminarPersona = new PersonaBajaUseCase(repo,servicioAutorizacion);
                    eliminarPersona.Ejecutar(idEliminar,idAutorizado);
                    Console.WriteLine($"Persona con Id {idEliminar} eliminada");
                }
                else
                    Console.WriteLine("Id no encontrado");
            }
            break;
        case "5":
            //Baja del evento
            Console.WriteLine("Ingrese el Id del evento a eliminar");
            string? eventoEliminar = Console.ReadLine();
            if (eventoEliminar != "") {
                if (int.TryParse(eventoEliminar, out int idEvento)) {
                    var bajaEvento = new EventoDeportivoBajaUseCase(repoevento, repoReserva,servicioAutorizacion);
                    bajaEvento.Ejecutar(idEvento,idAutorizado);
                    Console.WriteLine("Evento Eliminado con exito");

                }
                else
                    Console.WriteLine("Id del evento no encontrado");
            }
            break;
        case "6":
            //Eliminar Reserva
            Console.WriteLine("Ingresar el Id de la reserva a eliminar: ");
            string? reservaEliminar = Console.ReadLine();
            if (reservaEliminar != "") {
                if (int.TryParse(reservaEliminar, out int idReservaEliminar)) {
                    var bajaReserva = new ReservaBajaUseCase(repoReserva,servicioAutorizacion);
                    bajaReserva.Ejecutar(idReservaEliminar,idAutorizado);
                    Console.WriteLine("Reserva eliminada con exito");
                }
                else
                    Console.WriteLine("Id de la reserva no encontrado");
            }
            break;
        case "7":
            // Buscar por ID
            Console.Write("\nIngrese el ID de la persona a buscar: ");
            string? inputBuscar = Console.ReadLine();
            if (int.TryParse(inputBuscar, out int idBuscar)) {
                var encontrada = repo.ObtenerPorId(idBuscar);
                if (encontrada is not null) {
                    Console.WriteLine($"Encontrada: {encontrada.Nombre} {encontrada.Apellido}");
                    var modificarPersona = new PersonaModificarUseCase(repo,servicioAutorizacion);
                    // Modificar email
                    Console.Write("Ingrese nuevo email para esta persona: ");
                    string? nuevoEmail = Console.ReadLine();
                    encontrada.Email = nuevoEmail ?? encontrada.Email;
                    modificarPersona.Ejecutar(encontrada,idAutorizado);
                    Console.WriteLine($"Email modificado para persona con ID {encontrada.Id}");
                }
                else
                    Console.WriteLine($"No se encontró una persona con ID {idBuscar}.");
            }
            else
                Console.WriteLine("ID inválido.");
            break;
        case "8":
            //Modificar Evento
            Console.WriteLine("Ingresar id del evento a modificar: ");
            string? idEventoModificar = Console.ReadLine();
            if (int.TryParse(idEventoModificar, out int idBuscarEvento))
            {
                var eventoEncontrado = repoevento.ObtenerPorId(idBuscarEvento);
                if (eventoEncontrado is not null)
                {
                    Console.WriteLine($"Evento Encontrado: {eventoEncontrado.Nombre}");
                    var Modificar = new EventoDeportivoModificarUseCase(repoevento, repo, servicioAutorizacion);
                    Console.WriteLine("Insertar nueva fecha para el evento: ");
                    string? fechanueva = Console.ReadLine();
                    if (DateTime.TryParse(fechanueva, out DateTime fechaEvento))
                        Console.WriteLine("Fecha valida");
                    else
                        Console.WriteLine("Fecha Invalida");
                    eventoEncontrado.FechaHoraInicio = fechaEvento;
                    Modificar.Ejecutar(eventoEncontrado, idAutorizado);
                    Console.WriteLine($"Evento con id {eventoEncontrado.Id} modificado con exito");
                }
                else Console.WriteLine("no hay evento con ese id");
            }
            break;
        case "9":
            //modificar reserva
            Console.WriteLine("Insertar Id de la reserva a modificar: ");
            string? idReservaModificar = Console.ReadLine();
            if (int.TryParse(idReservaModificar, out int ReservaModificarId)) {
                var encontrarReserva = repoReserva.ObtenerPorId(ReservaModificarId);
                if (encontrarReserva is not null) {
                    Console.WriteLine($"Reserva Encontrada: {encontrarReserva.Id}");
                    var ModificarReserva = new ReservaModificarUseCase(repoReserva,servicioAutorizacion);
                    Console.WriteLine("Insertar nuevo id de evento: ");
                    string? idnuevo = Console.ReadLine();
                    if (int.TryParse(idnuevo, out int nuevoid))
                        Console.WriteLine("id valido");
                    else
                        Console.WriteLine("id Invalido");
                    encontrarReserva.EventoDeportivoId = nuevoid;
                    ModificarReserva.Ejecutar(encontrarReserva,idAutorizado);
                    Console.WriteLine($"Reserva con id {encontrarReserva.Id} modificada con exito");
                }
            }
            else
                Console.WriteLine("Id de la reserva invalido");
            break;
        case "10":
            // Listar personas
            Console.WriteLine("Listado de personas:");
            var Lista = new PersonaListarUseCase(repo);
            foreach (var p in Lista.Ejecutar())
            {
                Console.WriteLine($"{p.Id}: {p.Nombre} {p.Apellido} - DNI: {p.DNI} - Email: {p.Email} - Telefono: {p.Telefono}");
            }
            break;
        case "11":
            Console.WriteLine("Listado de eventos");
            var ListaEventos = new EventoDeportivoListarUseCase(repoevento);
            foreach (var e in ListaEventos.Ejecutar()) {
                Console.WriteLine($"Id: {e.Id} - Evento: {e.Nombre}: {e.Descripcion} - Fecha de inicio: {e.FechaHoraInicio} - Lugar: {e.Lugar}");
            }
            break;
        case "12":
            //Listar reservas
            Console.WriteLine("Listado de Reservas:");
            var ListaReserva = new ReservaListarUseCase(repoReserva);
            foreach (var p in ListaReserva.Ejecutar()) {
                Console.WriteLine($"Id de la reserva: {p.Id}: Id de la persona que reserva: {p.PersonaId} - Id del evento: {p.EventoDeportivoId} - Fecha: {p.FechaAltaReserva}");
            }
            break;
        case "13":
            //Listar asistencia al evento
            Console.WriteLine("Insertar Id del evento del que se desea listar la asistencia");
            string? idEventoAlistar = Console.ReadLine();
            if (int.TryParse(idEventoAlistar, out int idevent)) {
                Console.WriteLine($"Listado De asistencia Al evento con ID {idevent}");
                var ListarAsistencia = new ListarAsistenciaAEventoUseCase(repoevento, repo, repoReserva);
                foreach (var p in ListarAsistencia.Ejecutar(idevent))
                    Console.WriteLine($"{p.Id}: {p.Nombre} {p.Apellido} - DNI: {p.DNI} - Email: {p.Email} - Telefono: {p.Telefono}");
            }
            break;
        case "14":
            //ListarEventoConCupoDisponible
            Console.WriteLine("Listado de Eventos con cupo disponible: ");
            var ListaEventosDisponibles = new ListarEventosConCupoDisponibleUseCase(repoevento, repoReserva);
            foreach (var e in ListaEventosDisponibles.Ejecutar())
                Console.WriteLine($"Id: {e.Id} - Evento: {e.Nombre}: {e.Descripcion} - Fecha de inicio: {e.FechaHoraInicio} - Lugar: {e.Lugar}");
            break;
        case "15": 
            Console.WriteLine("0: Finalizar");
            Console.WriteLine("1: Agregar Persona:");
            Console.WriteLine("2: Agregar Evento Deportivo: ");
            Console.WriteLine("3: Agregar Reserva: ");
            Console.WriteLine("4: Eliminar Persona: ");
            Console.WriteLine("5: Eliminar Evento Deportivo: ");
            Console.WriteLine("6: Eliminar Reserva: ");
            Console.WriteLine("7: Modificar Persona: ");
            Console.WriteLine("8: Modificar Evento Deportivo: ");
            Console.WriteLine("9: Modificar Reserva: ");
            Console.WriteLine("10: Listar Persona: ");
            Console.WriteLine("11: Listar Evento Deportivo: ");
            Console.WriteLine("12: Listar Reserva: ");
            Console.WriteLine("13: Listar asistencia a Evento: ");
            Console.WriteLine("14: Listar Eventos con cupo disponible: ");
            break;
        default:
            Console.WriteLine("Insertar un numero valido o 0 para finalizar");
            break;
    }
}


