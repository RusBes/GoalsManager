using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler
{
	/// <summary>
	/// Notification Table Info
	/// </summary>
	public class Notification
	{
		public long NotificationId { get; set; }

		[ForeignKey("Task")]
		public long? TaskId { get; set; }

		public DateTime DateTimeStart { get; set; }

		public virtual Task Task { get; set; }
	}
}
