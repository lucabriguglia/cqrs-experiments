using System;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Category.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CategoryCreatedEventHandler : IEventHandler<CategoryCreatedEvent>
	{
		public void Execute(CategoryCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}