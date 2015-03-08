using System;
using Autofac;
using System.Linq;
using Autofac.Core;
using Weapsy.Blog.Queries.Handlers.Contracts;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class QueryHandlersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.As(type => type.GetInterfaces()
				.Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IQueryHandler<,>)))
				.Select(interfaceType => new KeyedService("queryHandler", interfaceType)));
		}
	}
}