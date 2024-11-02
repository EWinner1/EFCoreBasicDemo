using EFCoreBasicDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBasicDemo.Infrastructure.Mappers
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.ToTable("Company");
			builder.HasKey(c => c.CompanyCode).HasName("CompanyCode");
			builder.Property(c => c.CompanyCode).HasColumnType("nvarchar").HasColumnName("CompanyCode").HasMaxLength(50);
			builder.Property(c => c.CompanyName).HasColumnType("nvarchar").HasColumnName("CompanyName").HasMaxLength(50);
			builder.Property(c => c.CompanyTelephone).HasColumnType("nvarchar").HasColumnName("CompanyTelephone").HasMaxLength(50);
			builder.Property(c => c.CompanyCountry).HasColumnType("nvarchar").HasColumnName("CompanyCountry").HasMaxLength(5);
		}
	}
}
