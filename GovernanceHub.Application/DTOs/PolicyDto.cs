using GovernanceHub.Domain.Enums;

namespace GovernanceHub.Application.DTOs;

public class PolicyDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public PolicyStatus Status { get; set; }
    public PolicyRiskLevel RiskLevel { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}