using Microsoft.EntityFrameworkCore;

namespace Scheduler
{
	/// <summary>
	/// Task Table Info
	/// </summary>
	public class TaskContext : DbContext
	{
		public DbSet<Task> Tasks { get; set; }

		public DbSet<Notification> Notifications { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=schedulerdb;Trusted_Connection=True;");
	}
}
