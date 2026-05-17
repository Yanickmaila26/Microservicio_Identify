using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicios.Atracciones.Identify.DataAccess.Entities;

namespace Microservicios.Atracciones.Identify.DataAccess.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("client");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.UserId).IsUnique();

        builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.DocumentType).HasMaxLength(20);
        builder.Property(c => c.DocumentNumber).HasMaxLength(50);
        builder.Property(c => c.Nationality).HasMaxLength(100);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("now()").IsRequired();
        builder.Property(c => c.UpdatedAt).HasDefaultValueSql("now()").IsRequired();

        // Propiedad calculada — no mapeada a columna
        builder.Ignore(c => c.FullName);
    }
}
