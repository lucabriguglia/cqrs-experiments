using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapsy.Blog.Commands.Contracts;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Infrastructure
{
	public class TypeHelper
	{
		public static List<IStartupTask> GetStartupTasks()
		{
			var startupTasks = new List<IStartupTask>();

			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.ToLowerInvariant().Contains("weapsy")))
			{
				var iStartUpTaskQuery = from t in assembly.GetTypes()
										where t.IsClass && t.GetInterface(typeof(IStartupTask).FullName) != null
										select t;

				startupTasks.AddRange(iStartUpTaskQuery.Select(type => (IStartupTask)Activator.CreateInstance(type)));
			}

			return startupTasks;
		}

		public static IEnumerable<Type> GetCommands()
		{
			return typeof(ICommand)
				.Assembly
				.GetExportedTypes()
				.Where(t => t.IsClass && t.GetInterface(typeof(ICommand).FullName) != null)
				.ToList();
		}

		public static IEnumerable<Type> GetEvents()
		{
			return typeof(IDomainEvent)
				.Assembly
				.GetExportedTypes()
				.Where(t => t.IsClass && t.GetInterface(typeof(IDomainEvent).FullName) != null)
				.ToList();
		}
	}
}
