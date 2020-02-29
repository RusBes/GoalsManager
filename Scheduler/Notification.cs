using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler
{
	public class Notification
	{
		public long NotificationId { get; set; }

		public long TaskId { get; set; }
		public virtual Task Task { get; set; }

		public DateTime NotificationStartTime { get; set; }
	}
}
