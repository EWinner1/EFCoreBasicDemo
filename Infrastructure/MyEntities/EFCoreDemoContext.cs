using EFCoreDemo1.Infrastructure.Mappers;
using EFCoreDemo1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo1.Infrastructure.Entities
{
	public class EFCoreDemoContext : DbContext
	{
		public virtual DbSet<Staff> StaffRepositories { get; set; }
		public EFCoreDemoContext() { }
		public EFCoreDemoContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
			@"server=TIANHE4\MYTESTDATABASE;database=MyDatabase;uid=ewinner;pwd=QAQ123456789;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
			//@"server=127.0.0.1;database=MYDATABASE\MyTestData;uid=ewinner;pwd=QAQ123456789")
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StaffConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
