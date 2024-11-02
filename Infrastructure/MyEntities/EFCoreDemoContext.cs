using EFCoreBasicDemo.Infrastructure.Mappers;
using EFCoreBasicDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFCoreBasicDemo.Infrastructure.MyEntities
{
	public class EFCoreDemoContext : DbContext
	{
		private readonly IConfiguration configuration;
		public virtual DbSet<Staff> StaffRepositories { get; set; }
		// public virtual DbSet<Company> CompanyRepositories { get; set; }

		public EFCoreDemoContext()
		{
		}
		public EFCoreDemoContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
		{
			this.configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connStr = configuration.GetConnectionString("ConnectionString");
			optionsBuilder.UseSqlServer(connStr);
			// optionsBuilder.EnableSensitiveDataLogging(true);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StaffConfiguration());
			modelBuilder.ApplyConfiguration(new CompanyConfiguration());
			modelBuilder.Entity<StaffExpaned>().ToTable("StaffExpaned", se => se.ExcludeFromMigrations());

			modelBuilder.InsertData();

			base.OnModelCreating(modelBuilder);
		}
	}


	public static class ModelBuilderExtensions
	{
		public static void InsertData(this ModelBuilder modelBuilder)
		{
			Company accenture = new("AC001", "Accenture", "01064858999", "EN");
			Company redMaple = new("RMT", "Red Maple", "86866668888", "CN");

			Staff hengli = new(1, "Xiaoyu", "female", 12, "White Moon Light", "AC001", "CN");
			Staff xiaoyu = new(2, "Henry", "male", 10, "Software Engineer", "AC001", "CN");
			Staff tony = new(3, "tony", "male", 10, "180+++++", "RMT", "CN");
			Staff coco = new(4, "Henry", "female", 11, "Cute girl", "RMT", "CN");

			modelBuilder.Entity<Company>().HasData(accenture, redMaple);
			modelBuilder.Entity<Staff>().HasData(hengli, xiaoyu, tony, coco);
		}
	}
	
}
