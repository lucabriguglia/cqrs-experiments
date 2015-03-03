using System;

namespace Weapsy.Blog.Domain.Category.Events
{
    public class CategoryRestoredEvent : IDomainEvent
    {
		public Guid Id { get; private set; }

		public CategoryRestoredEvent(Guid id)
		{
			Id = id;
		}
	}
}
