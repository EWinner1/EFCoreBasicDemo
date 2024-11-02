using EFCoreBasicDemo.Infrastructure.Repositories;
using EFCoreBasicDemo.Infrastructure.Services.Interfaces;

namespace EFCoreBasicDemo.Infrastructure.Services
{
	public class StaffExpanedService : IStaffExpanedService
	{
		private readonly StaffRepository staffRepository;
		private readonly CompanyRepository companyRepository;

		public StaffExpanedService(StaffRepository staffRepository, CompanyRepository companyRepository)
		{
			this.staffRepository = staffRepository;
			this.companyRepository = companyRepository;
		}

		//public List<StaffExpaned> GetStaffDetailById()
		//{
		//	return companyRepository.GetStaffDetailsById();
		//}
	}
}
