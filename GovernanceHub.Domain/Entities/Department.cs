using System;
using System.Collections.Generic;
using System.Text;

namespace GovernanceHub.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid TenantId { get; set; }
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }

}
