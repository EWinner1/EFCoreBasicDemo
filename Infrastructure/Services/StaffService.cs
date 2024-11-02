using EFCoreBasicDemo.Infrastructure.Models;
using EFCoreBasicDemo.Infrastructure.Repositories;
using EFCoreBasicDemo.Infrastructure.Services.Interfaces;

namespace EFCoreBasicDemo.Infrastructure.Services
{
	public class StaffService : IStaffService
	{
		private readonly StaffRepository staffRepository;

		public StaffService(StaffRepository staffRepository)
		{
			this.staffRepository = staffRepository;
		}

		public async Task CreateStaffAsync(Staff staff)
		{
			await staffRepository.CreateStaffAsync(staff);
		}

		public async Task DeleteStaffAsync(int Id)
		{
			var staff = await staffRepository.GetStaffByIdAsync(Id);
			if (staff != null)
			{
				await staffRepository.DeleteStaffAsync(staff);
			}
		}

		public async Task UpdateStaffAsync(Staff staff)
		{
			await staffRepository.UpdateStaffAsync(staff);
		}

		public IEnumerable<Staff> GetAllStaff()
		{
			return staffRepository.GetAllStaff();
		}

		public Task<List<Staff>> GetAllStaffAsync()
		{
			return staffRepository.GetAllStaffAsync();
		}

		public Staff GetStaffById(int id)
		{
			return staffRepository.GetStaffById(id);
		}

		public Task<Staff> GetStaffByIdAsync(int id)
		{
			return staffRepository.GetStaffByIdAsync(id);
		}
	}
}
