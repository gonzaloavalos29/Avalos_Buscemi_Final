using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentroEventos.Aplicacion.Entidades;

public class EventoDeportivoConfiguracion : IEntityTypeConfiguration<EventoDeportivo>
{
    public void Configure(EntityTypeBuilder<EventoDeportivo> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nombre).IsRequired();
        builder.Property(e => e.CupoMaximo).IsRequired();
        builder.Property(e => e.FechaHoraInicio).IsRequired();
        builder.Property(e => e.DuracionHoras).IsRequired();
        builder.Property(e => e.Lugar).IsRequired();
        builder.Property(e => e.ResponsableId).IsRequired();
        builder.Property(e=> e.Descripcion).IsRequired();
    }
}