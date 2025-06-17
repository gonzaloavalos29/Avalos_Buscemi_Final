using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentroEventos.Aplicacion.Entidades;

public class ReservaConfiguracion : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.FechaAltaReserva).IsRequired();

        builder.Property(r => r.EstadoAsistencia).IsRequired();

        builder.HasOne<Persona>().WithMany().HasForeignKey(r => r.PersonaId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<EventoDeportivo>().WithMany().HasForeignKey(r => r.EventoDeportivoId).OnDelete(DeleteBehavior.Restrict);


    }
}
