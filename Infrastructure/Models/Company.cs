using System.ComponentModel.DataAnnotations;

namespace EFCoreBasicDemo.Infrastructure.Models
{
	public class Company
	{
		[Key]
		public string CompanyCode { get; set; }
		public string CompanyName { get; set; }
		public string? CompanyTelephone { get; set; }
		public string? CompanyCountry { get; set; }
		public List<Staff>? Staffs { get; set; }

		public Company(string companyCode, string companyName, string? companyTelephone, string? companyCountry)
		{
			CompanyCode = companyCode;
			CompanyName = companyName;
			CompanyTelephone = companyTelephone;
			CompanyCountry = companyCountry;
		}
	}
}
