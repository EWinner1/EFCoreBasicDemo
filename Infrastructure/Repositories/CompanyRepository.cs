using EFCoreBasicDemo.Infrastructure.Models;
using EFCoreBasicDemo.Infrastructure.MyEntities;

namespace EFCoreBasicDemo.Infrastructure.Repositories
{
	public class CompanyRepository : MyRepository<Company, EFCoreDemoContext>
	{
		public CompanyRepository(EFCoreDemoContext context) : base(context)
		{

		}

		//public List<StaffExpaned> GetStaffDetailsById()
		//{
		//	List<StaffExpaned> staffExpaneds = [];

		//	int staffId = 7;
		//	var staffIdParam = new SqlParameter("@StaffId", staffId);

		//	var query = from s in Context.StaffRepositories
		//				join c in Context.CompanyRepositories on s.CompanyCode.ToString() equals c.CompanyCode
		//				select new
		//				{ s, c.CompanyName, c.CompanyTelephone, c.CompanyCountry };

		//	//var result = Context.StaffExpanedRepositories.FromSqlRaw("exec [dbo].[GetStaffInfomationDetails] @StaffId", staffIdParam).ToList();
		//	//var result = Context.StaffExpanedRepositories.FromSqlInterpolated($"exec [dbo].[GetStaffInfomationDetails] {staffId}").ToList();
		//	//var result = Context.Set<StaffExpaned>().FromSqlRaw("exec [dbo].[GetStaffInfomationDetails] @StaffId", staffIdParam).ToList();
		//	//var result = Context.StaffExpanedRepositories($"exec [dbo].[GetStaffInfomationDetails] @StaffId = {staffId}").ToList();

		//	foreach (var item in query)
		//	{
		//		staffExpaneds.Add(new StaffExpaned
		//		{
		//			Id = item.s.Id,
		//			Name = item.s.Name,
		//			StaffLevel = item.s.StaffLevel,
		//			Description = item.s.Description,
		//			Sex = item.s.Sex,
		//			CompanyCode = item.s.CompanyCode,
		//			CompanyCountry = item.CompanyCountry,
		//			CompanyName = item.CompanyName,
		//			CompanyTelephone = item.CompanyTelephone,
		//		});
		//	}
		//	return staffExpaneds;
		//}
	}
}
