using System;
using System.Collections.Generic;
using System.Text;

namespace GovernanceHub.Domain.Entities
{
    public class AuditLog : BaseEntity
    {
        public string Action { get; set; } = string.Empty;
        public string EntityName { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public Guid TenantId { get; set; }
    }
}
