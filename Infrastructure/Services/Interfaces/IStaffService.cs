using EFCoreDemo1.Infrastructure.Models;

namespace EFCoreDemo1.Infrastructure.Services.Interfaces
{
	public interface IStaffService
	{
		Task CreateStaffAsync(Staff staff);
		Task DeleteStaffAsync(int Id);
		Task UpdateStaffAsync(Staff staff);
		IEnumerable<Staff> GetAllStaff();
		Task<List<Staff>> GetAllStaffAsync();
		Staff GetStaffById(int id);
		Task<Staff> GetStaffByIdAsync(int id);
	}
}
