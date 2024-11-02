using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreBasicDemo.Infrastructure.Models
{
	public class Staff
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Sex { get; set; }
		[Required]
		public int StaffLevel { get; set; }
		public string Description { get; set; } = string.Empty;
		[ForeignKey("CompanyCode"), Required]
		public string CompanyCode { get; set; }
		[Required]
		public string CountryCode { get; set; }
		[Required]
		public Company Company { get; set; }

		public Staff(int id, string name, string sex, int staffLevel, string description, string companyCode, string countryCode)
		{
			Id = id;
			Name = name;
			Sex = sex;
			StaffLevel = staffLevel;
			Description = description;
			CompanyCode = companyCode;
			CountryCode = countryCode;
		}
	}
}
