using System;
using Autofac;
using System.Linq;
using Autofac.Core;
using Weapsy.Blog.Commands.Validators;
using FluentValidation;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class ValidatorsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterAssemblyTypes(typeof(CreateBlogCommandValidator).Assembly)
				.As(type => type.GetInterfaces()
				.Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(AbstractValidator<>)))
				.Select(interfaceType => new KeyedService("validator", interfaceType)));
		}
	}
}