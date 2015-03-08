using System;
using Autofac;
using Weapsy.Blog.Commands.Handlers;
using Weapsy.Blog.Commands.Handlers.Contracts;
using System.Linq;
using Autofac.Core;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class CommandHandlersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterAssemblyTypes(typeof(AddCommentCommandHandler).Assembly)
				.As(type => type.GetInterfaces()
				.Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>)))
				.Select(interfaceType => new KeyedService("commandHandler", interfaceType)));
		}
	}
}