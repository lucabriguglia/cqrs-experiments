using System;

namespace Weapsy.Blog.Domain.Blog.Events
{
    public class BlogCreatedEvent : IDomainEvent
    {
		public Guid Id { get; private set; }
	    public string Title { get; private set; }

		public BlogCreatedEvent(Guid id, string title)
		{
			Id = id;
			Title = title;
		}
	}
}
