using EFCoreBasicDemo.Infrastructure.Models;
using EFCoreBasicDemo.Infrastructure.MyEntities;
using EFCoreBasicDemo.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBasicDemo.Infrastructure.Repositories
{
	public class StaffRepository : MyRepository<Staff, EFCoreDemoContext>, IStaffRepository
	{
		public StaffRepository(EFCoreDemoContext context) : base(context)
		{
		}

		public async Task CreateStaffAsync(Staff staff)
		{
			await CreateAsync(staff);
		}

		public async Task DeleteStaffAsync(Staff staff)
		{
			await DeleteAsync(staff);
		}

		public async Task UpdateStaffAsync(Staff staff)
		{
			await UpdateAsync(staff);
			//Context.StaffRepositories.Update(staff);
			//Context.SaveChanges();
		}

		public IEnumerable<Staff> GetAllStaff()
		{
			return Context.StaffRepositories.ToList();
		}

		public Task<List<Staff>> GetAllStaffAsync()
		{
			return Context.StaffRepositories.Include("Company").ToListAsync();
		}

		public Staff? GetStaffById(int id)
		{
			return Context.StaffRepositories.Find(id);
		}

		public async Task<Staff?> GetStaffByIdAsync(int id)
		{
			return Context.StaffRepositories.FindAsync(id).GetAwaiter().GetResult();
		}
	}
}
