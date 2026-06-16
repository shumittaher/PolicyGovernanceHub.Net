using GovernanceHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernanceHub.Application.DTOs
{
    public class CreatePolicyDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public PolicyRiskLevel RiskLevel { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
