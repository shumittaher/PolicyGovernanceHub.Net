using GovernanceHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovernanceHub.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }
}