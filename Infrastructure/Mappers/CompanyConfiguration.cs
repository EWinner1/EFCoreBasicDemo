using EFCoreDemo1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo1.Infrastructure.Mappers
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.ToTable("Company");
			builder.HasKey(c => c.CompanyCode).HasName("CompanyCode");
			builder.Property(c => c.CompanyName).HasColumnType("int").HasColumnName("Id");
			builder.Property(c => c.CompanyTelephone).HasColumnType("nvarchar").HasColumnName("Name").HasMaxLength(30);
			builder.Property(c => c.CompanyCountry).HasColumnType("nvarchar").HasColumnName("Sex").HasMaxLength(10);
		}
	}
}
