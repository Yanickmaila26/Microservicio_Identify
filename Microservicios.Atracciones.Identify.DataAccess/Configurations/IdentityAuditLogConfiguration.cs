using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicios.Atracciones.Identify.DataAccess.Entities;

namespace Microservicios.Atracciones.Identify.DataAccess.Configurations;

public class IdentityAuditLogConfiguration : IEntityTypeConfiguration<IdentityAuditLog>
{
    public void Configure(EntityTypeBuilder<IdentityAuditLog> builder)
    {
        builder.ToTable("identity_audit_log");
        builder.HasKey(al => al.Id);

        builder.Property(al => al.TableName).HasMaxLength(100);
        builder.Property(al => al.Action).HasMaxLength(10);
        builder.Property(al => al.ChangedBy).HasMaxLength(256);
        builder.Property(al => al.ChangedAt).HasDefaultValueSql("now()");
        builder.Property(al => al.OldValues).HasColumnType("jsonb");
        builder.Property(al => al.NewValues).HasColumnType("jsonb");
    }
}
