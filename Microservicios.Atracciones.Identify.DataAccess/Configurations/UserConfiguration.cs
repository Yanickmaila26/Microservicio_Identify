using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicios.Atracciones.Identify.DataAccess.Entities;

namespace Microservicios.Atracciones.Identify.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.IsActive).HasDefaultValue(true).IsRequired();
        builder.Property(u => u.EmailVerified).HasDefaultValue(false).IsRequired();
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("now()").IsRequired();
        builder.Property(u => u.UpdatedAt).HasDefaultValueSql("now()").IsRequired();

        // 1-1 con Client
        builder.HasOne(u => u.Client)
               .WithOne(c => c.User)
               .HasForeignKey<Client>(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
