using System;

namespace Weapsy.Blog.Domain.Blog.Events
{
    public class BlogDeletedEvent : IDomainEvent
    {
		public Guid Id { get; private set; }

		public BlogDeletedEvent(Guid id)
		{
			Id = id;
		}
	}
}
