using Microsoft.EntityFrameworkCore;

namespace Scheduler
{
	public class GoalContext : DbContext
	{
		public DbSet<Goal> Goals { get; set; }

		public DbSet<Notification> Notifications { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=schedulerdb;Trusted_Connection=True;");
	}
}
