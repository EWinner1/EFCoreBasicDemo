namespace EFCoreDemo1.Infrastructure.Models
{
	public class StaffExpaned
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Sex { get; set; } = string.Empty;
		public int StaffLevel { get; set; }
		public string Description { get; set; } = string.Empty;
		public int CompanyCode { get; set; }
		public string CountryCode { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public string CompanyTelephone { get; set; } = string.Empty;
		public string CompanyCountry { get; set; } = string.Empty;
	}
}
