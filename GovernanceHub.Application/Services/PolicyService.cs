using GovernanceHub.Application.DTOs;
using GovernanceHub.Application.Interfaces;
using GovernanceHub.Domain.Entities;
using GovernanceHub.Domain.Enums;
using GovernanceHub.Domain.Interfaces;

namespace GovernanceHub.Application.Services;

public class PolicyService : IPolicyService
{
    private readonly IPolicyRepository _policyRepository;

    public PolicyService(IPolicyRepository policyRepository)
    {
        _policyRepository = policyRepository;
    }

    public async Task<PolicyDto?> GetByIdAsync(Guid id, Guid tenantId)
    {
        var policy = await _policyRepository.GetByIdAsync(id);
        if (policy == null || policy.TenantId != tenantId) return null;
        return MapToDto(policy);
    }

    public async Task<IEnumerable<PolicyDto>> GetAllByTenantAsync(Guid tenantId)
    {
        var policies = await _policyRepository.GetByTenantAsync(tenantId);
        return policies.Select(MapToDto);
    }

    public async Task<IEnumerable<PolicyDto>> GetByDepartmentAsync(Guid departmentId, Guid tenantId)
    {
        var policies = await _policyRepository.GetByDepartmentAsync(departmentId);
        return policies.Where(p => p.TenantId == tenantId).Select(MapToDto);
    }

    public async Task<IEnumerable<PolicyDto>> GetByStatusAsync(PolicyStatus status, Guid tenantId)
    {
        var policies = await _policyRepository.GetByStatusAsync(status);
        return policies.Where(p => p.TenantId == tenantId).Select(MapToDto);
    }

    public async Task<IEnumerable<PolicyDto>> GetOverdueReviewsAsync(Guid tenantId)
    {
        var policies = await _policyRepository.GetOverdueReviewsAsync();
        return policies.Where(p => p.TenantId == tenantId).Select(MapToDto);
    }

    public async Task<PolicyDto> CreateAsync(CreatePolicyDto dto, Guid tenantId, string userId)
    {
        var policy = new Policy
        {
            Title = dto.Title,
            Description = dto.Description,
            Content = dto.Content,
            RiskLevel = dto.RiskLevel,
            DepartmentId = dto.DepartmentId,
            ReviewDate = dto.ReviewDate,
            TenantId = tenantId,
            CreatedBy = userId,
            Status = PolicyStatus.Draft
        };

        var created = await _policyRepository.AddAsync(policy);
        return MapToDto(created);
    }

    public async Task<PolicyDto> UpdateAsync(Guid id, CreatePolicyDto dto, Guid tenantId)
    {
        var policy = await _policyRepository.GetByIdAsync(id);
        if (policy == null || policy.TenantId != tenantId)
            throw new KeyNotFoundException("Policy not found");

        policy.Title = dto.Title;
        policy.Description = dto.Description;
        policy.Content = dto.Content;
        policy.RiskLevel = dto.RiskLevel;
        policy.DepartmentId = dto.DepartmentId;
        policy.ReviewDate = dto.ReviewDate;
        policy.UpdatedAt = DateTime.UtcNow;

        await _policyRepository.UpdateAsync(policy);
        return MapToDto(policy);
    }

    public async Task DeleteAsync(Guid id, Guid tenantId)
    {
        var policy = await _policyRepository.GetByIdAsync(id);
        if (policy == null || policy.TenantId != tenantId)
            throw new KeyNotFoundException("Policy not found");

        await _policyRepository.DeleteAsync(id);
    }

    public async Task<PolicyDto> UpdateStatusAsync(Guid id, PolicyStatus status, Guid tenantId, string userId)
    {
        var policy = await _policyRepository.GetByIdAsync(id);
        if (policy == null || policy.TenantId != tenantId)
            throw new KeyNotFoundException("Policy not found");

        policy.Status = status;
        policy.UpdatedAt = DateTime.UtcNow;

        await _policyRepository.UpdateAsync(policy);
        return MapToDto(policy);
    }

    private static PolicyDto MapToDto(Policy policy) => new()
    {
        Id = policy.Id,
        Title = policy.Title,
        Description = policy.Description,
        Content = policy.Content,
        Version = policy.Version,
        Status = policy.Status,
        RiskLevel = policy.RiskLevel,
        DepartmentId = policy.DepartmentId,
        DepartmentName = policy.Department?.Name ?? string.Empty,
        OwnerId = policy.OwnerId,
        ReviewDate = policy.ReviewDate,
        CreatedAt = policy.CreatedAt,
        CreatedBy = policy.CreatedBy
    };
}