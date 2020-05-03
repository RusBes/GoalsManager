using System;

namespace GoalsManager
{
	public class Notification
	{
		public long NotificationId { get; set; }

		public long GoalId { get; set; }
		public virtual Goal Goal { get; set; }

		public DateTime NotificationStartTime { get; set; }
	}
}
