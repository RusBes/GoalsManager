using System;

namespace GoalsManager.Extensions
{
	public static class DateTimeExtensions
	{
		public static string ToDateTimeLocalInputFormat(this DateTime date) 
		{
			//2018-06-12T19:30
			return date.ToString("yyyy-MM-ddTHH:mm");
		}
	}
}
