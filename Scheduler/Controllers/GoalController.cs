using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GoalController : ControllerBase
	{
		private readonly GoalContext _goalContext;

		public GoalController(GoalContext goalContext)
		{
			_goalContext = goalContext;
		}

		#region Goal CRUD operations
		[Route("api/[controller]/[action]")]
		[HttpPost("AddGoal")]
		public long AddGoal(Goal goal)
		{
			goal.GoalId = 0;
			_goalContext.Add(goal);
			_goalContext.SaveChanges();

			return goal.GoalId;
		}

		[Route("api/[controller]/[action]")]
		[HttpPut("UpdateGoal")]
		public void UpdateGoal(Goal goal)
		{
			var currentGoal = _goalContext.Goals.Find(goal.GoalId);

			if (currentGoal != null)
			{
				_goalContext.Entry(currentGoal).CurrentValues.SetValues(goal);
				_goalContext.SaveChanges();
			}
		}

		[Route("api/[controller]/[action]")]
		[HttpDelete("DeleteGoal")]
		public void DeleteGoal(Goal goal)
		{
			var currentGoal = _goalContext.Goals.Find(goal.GoalId);

			if (currentGoal != null)
			{
				_goalContext.Remove(currentGoal);
				_goalContext.SaveChanges();
			}
		}

		[Route("api/[controller]/[action]")]
		[HttpGet("GetGoalById")]
		public Goal GetGoalById(long goalId)
		{
			return _goalContext.Goals.Find(goalId);
		}

		[Route("api/[controller]/[action]")]
		[HttpGet("GetAllGoals")]
		public IEnumerable<Goal> GetAllGoals()
		{
			return _goalContext.Goals;
		}
		#endregion

		#region Notification CRUD operations
		[Route("api/[controller]/[action]")]
		[HttpPost("AddNotification")]
		public long AddNotification(Notification notification)
		{
			notification.NotificationId = 0;
			_goalContext.Add(notification);
			_goalContext.SaveChanges();

			return notification.NotificationId;
		}

		[Route("api/[controller]/[action]")]
		[HttpPut("UpdateNotification")]
		public void UpdateNotification(Notification notification)
		{
			var currentNotification = _goalContext.Notifications.Find(notification.NotificationId);

			if (currentNotification != null)
			{
				_goalContext.Entry(currentNotification).CurrentValues.SetValues(notification);
				_goalContext.SaveChanges();
			}
		}

		[Route("api/[controller]/[action]")]
		[HttpDelete("DeleteNotification")]
		public void DeleteNotification(Notification notification)
		{
			var currentNotification = _goalContext.Notifications.Find(notification.NotificationId);

			if (currentNotification != null)
			{
				_goalContext.Remove(currentNotification);
				_goalContext.SaveChanges();
			}
		}

		[Route("api/[controller]/[action]")]
		[HttpGet("GetNotificationsByGoalId")]
		public IEnumerable<Notification> GetNotificationsByGoalId(long goalId)
		{
			return _goalContext.Notifications.Where(el => el.GoalId == goalId);
		}
		#endregion
	}
}