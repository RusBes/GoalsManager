using System;
using System.Collections.Generic;

namespace GoalsManager
{
	public class Goal
	{
		public long GoalId { get; set; }
		
		public string Name { get; set; }

		public Status Status { get; set; }

		public string Group { get; set; }

		public DateTime? DateTimeStart { get; set; }

		public DateTime? DateTimeEnd { get; set; }

		public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
	}

	public enum Status
	{
		Created,
		Completed
	}
}

