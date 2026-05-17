using System;

namespace Microservicios.Atracciones.Identify.DataAccess.Entities;

public class IdentityAuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? CorrelationId { get; set; }
    public string? TableName { get; set; }
    public Guid? RecordId { get; set; }
    public string? Action { get; set; }
    public string? ChangedBy { get; set; }
    public DateTime? ChangedAt { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
}
