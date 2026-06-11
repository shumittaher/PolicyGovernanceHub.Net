using System;
using System.Collections.Generic;
using System.Text;
using GovernanceHub.Domain.Entities;
using GovernanceHub.Domain.Enums;

namespace GovernanceHub.Domain.Interfaces
{
    public interface IPolicyRepository : IRepository<Policy>
    {
        Task<IEnumerable<Policy>> GetByTenantAsync(Guid tenantId);
        Task<IEnumerable<Policy>> GetByDepartmentAsync(Guid departmentId);
        Task<IEnumerable<Policy>> GetByStatusAsync(PolicyStatus status);
        Task<IEnumerable<Policy>> GetOverdueReviewsAsync();

    }
}