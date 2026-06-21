using GovernanceHub.Domain.Entities;
using GovernanceHub.Domain.Enums;
using GovernanceHub.Domain.Interfaces;
using GovernanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernanceHub.Infrastructure.Repositories;

public class PolicyRepository : IPolicyRepository
{
	private readonly ApplicationDbContext _context;

	public PolicyRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Policy?> GetByIdAsync(Guid id)
	{
		return await _context.Policies
			.Include(p => p.Department)
			.FirstOrDefaultAsync(p => p.Id == id);
	}

	public async Task<IEnumerable<Policy>> GetAllAsync()
	{
		return await _context.Policies
			.Include(p => p.Department)
			.ToListAsync();
	}

	public async Task<Policy> AddAsync(Policy entity)
	{
		_context.Policies.Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task UpdateAsync(Policy entity)
	{
		_context.Policies.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var policy = await _context.Policies.FindAsync(id);
		if (policy != null)
		{
			_context.Policies.Remove(policy);
			await _context.SaveChangesAsync();
		}
	}

	public async Task<IEnumerable<Policy>> GetByTenantAsync(Guid tenantId)
	{
		return await _context.Policies
			.Include(p => p.Department)
			.Where(p => p.TenantId == tenantId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Policy>> GetByDepartmentAsync(Guid departmentId)
	{
		return await _context.Policies
			.Include(p => p.Department)
			.Where(p => p.DepartmentId == departmentId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Policy>> GetByStatusAsync(PolicyStatus status)
	{
		return await _context.Policies
			.Include(p => p.Department)
			.Where(p => p.Status == status)
			.ToListAsync();
	}

	public async Task<IEnumerable<Policy>> GetOverdueReviewsAsync()
	{
		return await _context.Policies
			.Include(p => p.Department)
			.Where(p => p.ReviewDate < DateTime.UtcNow && p.Status == PolicyStatus.Approved)
			.ToListAsync();
	}
}