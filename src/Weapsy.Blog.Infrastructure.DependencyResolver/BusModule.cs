using System;
using Autofac;
using Weapsy.Blog.Bus;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Commands.Contracts;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Queries.Contracts;

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

			builder.RegisterType<CommandSender>().As<ICommandSender<ICommand>>();
			builder.RegisterType<EventPublisher>().As<IEventPublisher<IDomainEvent>>();
			builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
		}
	}
}