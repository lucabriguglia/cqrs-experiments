using System;
using System.Threading.Tasks;
using Weapsy.Blog.Domain;
using Weapsy.Blog.Domain.Category.Events;

namespace Weapsy.Blog.EventHandlers
{
	public class CategoryCreatedEventHandler : IEventHandler<CategoryCreatedEvent>
	{
		public Task Execute(CategoryCreatedEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}