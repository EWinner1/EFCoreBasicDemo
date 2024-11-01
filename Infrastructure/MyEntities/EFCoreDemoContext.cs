using EFCoreDemo1.Infrastructure.Mappers;
using EFCoreDemo1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo1.Infrastructure.Entities
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
			//@"server=TIANHE4\MYTESTDATABASE;database=MyDatabase;uid=ewinner;pwd=QAQ123456789;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;")
			//@"server=127.0.0.1;database=MYDATABASE\MyTestData;uid=ewinner;pwd=QAQ123456789")
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StaffConfiguration());
			// modelBuilder.ApplyConfiguration(new CompanyConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
