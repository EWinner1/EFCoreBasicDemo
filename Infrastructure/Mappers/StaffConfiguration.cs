using EFCoreDemo1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo1.Infrastructure.Mappers
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
		}
	}
}
