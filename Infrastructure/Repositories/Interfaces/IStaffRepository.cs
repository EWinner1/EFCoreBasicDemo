﻿using EFCoreBasicDemo.Infrastructure.Models;

namespace EFCoreBasicDemo.Infrastructure.Repositories.Interfaces
{
	public interface IStaffRepository
	{
		IEnumerable<Staff> GetAllStaff();
		Task<List<Staff>> GetAllStaffAsync();
		Task<Staff> GetStaffByIdAsync(int id);
		Staff GetStaffById(int id);
		Task UpdateStaffAsync(Staff staff);
		Task DeleteStaffAsync(Staff staff);
		Task CreateStaffAsync(Staff staff);
	}
}
