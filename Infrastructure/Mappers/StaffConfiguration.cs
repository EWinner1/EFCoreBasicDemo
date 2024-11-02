using EFCoreBasicDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreBasicDemo.Infrastructure.Mappers
{
	public class StaffConfiguration : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.ToTable("Staff");
			builder.HasKey(staff => staff.Id).HasName("Id");
			builder.Property(staff => staff.Id).HasColumnType("int").HasColumnName("Id");
			builder.Property(user => user.Name).HasColumnType("nvarchar").HasColumnName("Name").HasMaxLength(30);
			builder.Property(user => user.Sex).HasColumnType("nvarchar").HasColumnName("Sex").HasMaxLength(10);
			builder.Property(user => user.StaffLevel).HasColumnType("int").HasColumnName("StaffLevel");
			builder.Property(user => user.Description).HasColumnType("nvarchar").HasColumnName("Description").HasMaxLength(50);
			builder.Property(user => user.CompanyCode).HasColumnType("nvarchar").HasColumnName("CompanyCode").HasMaxLength(50);
			builder.Property(user => user.CountryCode).HasColumnType("nvarchar").HasColumnName("Country_Code").HasMaxLength(5);
			// builder.HasOne(user => user.Company).WithMany(c => c.Staffs).HasForeignKey(u => u.CompanyCode).IsRequired();
		}
	}
}
