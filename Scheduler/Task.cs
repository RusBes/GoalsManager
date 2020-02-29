using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler
{
	public class Task
	{
		public long TaskId { get; set; }
		
		public long? TaskParentId { get; set; }
		public virtual Task TaskParent { get; set; }

		public string Name { get; set; }

		public int Status { get; set; }

		public string Group { get; set; }

		public DateTime DateTimeStart { get; set; }

		public DateTime DateTimeEnd { get; set; }

		public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

		public virtual ICollection<Task> Goals { get; set; } = new List<Task>();
	}
}

