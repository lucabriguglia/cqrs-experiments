using System;

namespace Weapsy.Blog.Domain.Blog.Events
{
	public class BlogTitleChangedEvent : IDomainEvent
	{
		public Guid Id { get; private set; }
		public string Title { get; private set; }

		public BlogTitleChangedEvent(Guid id, string title)
		{
			Id = id;
			Title = title;
		}
	}
}
