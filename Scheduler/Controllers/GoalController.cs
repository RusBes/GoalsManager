using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GoalController : ControllerBase
	{
		[HttpPost]
		public long AddGoal(Goal goal)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Add(goal);
				goalContext.SaveChanges();
				return goal.GoalId;
			}
		}

		[HttpPut]
		public void UpdateGoal(Goal goal)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Update(goal);
				goalContext.SaveChanges();
			}
		}

		[HttpDelete]
		public void DeleteGoal(Goal goal)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Remove(goal);
				goalContext.SaveChanges();
			}
		}

		[HttpGet]
		public Goal GetGoalById(long goalId)
		{
			using (var goalContext = new GoalContext())
			{
				return goalContext.Goals.Find(goalId);
			}
		}

		[HttpPost]
		public long AddNotification(Notification notification)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Add(notification);
				goalContext.SaveChanges();
				return notification.NotificationId;
			}
		}

		[HttpPut]
		public void UpdateNotification(Notification notification)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Update(notification);
				goalContext.SaveChanges();
			}
		}

		[HttpDelete]
		public void DeleteNotification(Notification notification)
		{
			using (var goalContext = new GoalContext())
			{
				goalContext.Remove(notification);
				goalContext.SaveChanges();
			}
		}

		[HttpGet]
		public Notification GetNotificationById(long notificationId)
		{
			using (var goalContext = new GoalContext())
			{
				return goalContext.Notifications.Find(notificationId);
			}
		}
	}
}