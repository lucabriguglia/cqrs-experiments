using System;

namespace Weapsy.Blog.Domain.Category.Events
{
	public class CategoryDeletedEvent : IDomainEvent
	{
		public Guid Id { get; private set; }

		public CategoryDeletedEvent(Guid id)
		{
			Id = id;
		}
	}
}
