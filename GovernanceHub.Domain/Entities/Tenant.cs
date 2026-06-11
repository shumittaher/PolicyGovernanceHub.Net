using System;
using System.Collections.Generic;
using System.Text;

namespace GovernanceHub.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
