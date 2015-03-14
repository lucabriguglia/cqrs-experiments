using System;
using Autofac;
using Weapsy.Blog.Bus;
using Weapsy.Blog.Bus.Contracts;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class BusModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterType<CommandSender>().As<ICommandSender>();
			builder.RegisterType<EventPublisher>().As<IEventPublisher>();
			builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
		}
	}
}