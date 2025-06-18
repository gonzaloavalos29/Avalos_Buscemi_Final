using CentroEventos.Repositorios.Contexto;
using CentroEventos.Repositorios.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;
using Microsoft.EntityFrameworkCore;
using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.CasosDeUso;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CentroEventosContext>(options =>
    options.UseSqlite("Data Source=centroeventos.db"));

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoEF>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReservaEF>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaEF>();


builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ValidadorUsuario>();
builder.Services.AddScoped<ValidadorEventoDeportivo>();
builder.Services.AddScoped<ValidadorReserva>();
builder.Services.AddScoped<ValidadorPersona>();


builder.Services.AddScoped<CrearEventoUseCase>();
builder.Services.AddScoped<EventoDeportivoAltaUseCase>();
builder.Services.AddScoped<EventoDeportivoBajaUseCase>();
builder.Services.AddScoped<EventoDeportivoListarUseCase>();
builder.Services.AddScoped<EventoDeportivoModificarUseCase>();
builder.Services.AddScoped<IniciarSesion>();
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();
builder.Services.AddScoped<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<PersonaAltaUseCase>();
builder.Services.AddScoped<PersonaBajaUseCase>();
builder.Services.AddScoped<PersonaListarUseCase>();
builder.Services.AddScoped<PersonaModificarUseCase>();
builder.Services.AddScoped<RegistrarUsuarioUseCase>();
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ReservaBajaUseCase>();
builder.Services.AddScoped<ReservaListarUseCase>();
builder.Services.AddScoped<ReservaModificarUseCase>();
builder.Services.AddScoped<UsuarioBajaUseCase>();
builder.Services.AddScoped<UsuarioModificarUseCase>();
builder.Services.AddSingleton<ServicioSesionUsuario>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();