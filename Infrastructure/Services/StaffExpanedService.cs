using EFCoreDemo1.Infrastructure.Models;
using EFCoreDemo1.Infrastructure.Repositories;
using EFCoreDemo1.Infrastructure.Services.Interfaces;

namespace EFCoreDemo1.Infrastructure.Services
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
