using System;
using Autofac;
using System.Linq;
using Autofac.Core;
using Weapsy.Blog.Domain;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class EventHandlersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.As(type => type.GetInterfaces()
				.Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IEventHandler<>)))
				.Select(interfaceType => new KeyedService("eventHandler", interfaceType)));
		}
	}
}