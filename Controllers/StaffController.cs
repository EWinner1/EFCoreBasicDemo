using EFCoreBasicDemo.Infrastructure.Models;
using EFCoreBasicDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBasicDemo.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly StaffService staffService;
		// private readonly StaffExpanedService staffExpanedService;

		public StaffController(StaffService staffService, StaffExpanedService staffExpanedService)
		{
			this.staffService = staffService;
			// this.staffExpanedService = staffExpanedService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateStaff([FromBody] Staff staff)
		{
			await staffService.CreateStaffAsync(staff);
			return Ok("success");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteStaff(int id)
		{
			await staffService.DeleteStaffAsync(id);
			return Ok("success");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateStaff(int id)
		{
			Staff staff = staffService.GetStaffById(id);
			//staff.Description = "Test Description";
			staff.Description = "Description 1";
			await staffService.UpdateStaffAsync(staff);
			return Ok("success");
		}

		[HttpGet]
		public Staff GetStaffById(int id)
		{
			return staffService.GetStaffById(id);
		}

		[HttpGet]
		public async Task<List<Staff>> GetAllStaffAsync()
		{
			return await staffService.GetAllStaffAsync();
		}

		//[HttpGet]
		//public List<StaffExpaned> GetStaffDetailsByIdUseStoredProcedure()
		//{
		//	return staffExpanedService.GetStaffDetailById();
		//}
	}
}
