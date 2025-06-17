using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using System.Text.Json;

public class PersonaConfiguraciones : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Apellido).IsRequired();
        builder.Property(p => p.Nombre).IsRequired();
        builder.Property(p => p.Telefono).IsRequired();
        builder.Property(p => p.DNI).IsRequired();
    }
}