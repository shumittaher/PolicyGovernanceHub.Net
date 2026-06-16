using GovernanceHub.Application.DTOs;
using GovernanceHub.Domain.Enums;

namespace GovernanceHub.Application.Interfaces;

public interface IPolicyService
{
    Task<PolicyDto?> GetByIdAsync(Guid id, Guid tenantId);
    Task<IEnumerable<PolicyDto>> GetAllByTenantAsync(Guid tenantId);
    Task<IEnumerable<PolicyDto>> GetByDepartmentAsync(Guid departmentId, Guid tenantId);
    Task<IEnumerable<PolicyDto>> GetByStatusAsync(PolicyStatus status, Guid tenantId);
    Task<IEnumerable<PolicyDto>> GetOverdueReviewsAsync(Guid tenantId);
    Task<PolicyDto> CreateAsync(CreatePolicyDto dto, Guid tenantId, string userId);
    Task<PolicyDto> UpdateAsync(Guid id, CreatePolicyDto dto, Guid tenantId);
    Task DeleteAsync(Guid id, Guid tenantId);
    Task<PolicyDto> UpdateStatusAsync(Guid id, PolicyStatus status, Guid tenantId, string userId);
}