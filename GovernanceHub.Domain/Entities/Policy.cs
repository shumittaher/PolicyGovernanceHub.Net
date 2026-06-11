using System;
using System.Collections.Generic;
using System.Text;
using GovernanceHub.Domain.Enums;


namespace GovernanceHub.Domain.Entities
{
    public class Policy : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Version { get; set; } = "1.0";
        public PolicyStatus Status { get; set; } = PolicyStatus.Draft;
        public PolicyRiskLevel RiskLevel { get; set; } = PolicyRiskLevel.Low;
        public Guid DepartmentId { get; set; }        
        public Department? Department { get; set; }   
        public string OwnerId { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
        public Guid TenantId { get; set; }
    }

}
