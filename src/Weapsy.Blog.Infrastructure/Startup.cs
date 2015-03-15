using System;
using System.Collections.Generic;
using System.Linq;

namespace Weapsy.Blog.Infrastructure
{
	public static class Startup
	{
		public static void Initialise()
		{
			foreach (var task in TypeHelper.GetStartupTasks())
			{
				task.Execute();
			}
		}
	}
}
