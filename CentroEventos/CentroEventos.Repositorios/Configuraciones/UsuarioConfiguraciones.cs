using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using System.Text.Json;

public class UsuarioConfiguraciones : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.id);
        builder.Property(u => u.email).IsRequired();
        builder.Property(u => u.hashpassword).IsRequired();
        builder.Property(u=> u.apellido).IsRequired();
        builder.Property(u=>u.nombre).IsRequired();
        builder.Property(u => u.permisos).HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<List<Permiso>>(v, (JsonSerializerOptions?)null) ?? new List<Permiso>()
        );
    }
}