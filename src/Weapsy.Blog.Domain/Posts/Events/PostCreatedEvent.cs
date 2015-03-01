namespace Weapsy.Blog.Domain.Posts.Events
{
	public class PostCreatedEvent : IDomainEvent
    {
		public Post Post { get; private set; }

		public PostCreatedEvent(Post post)
		{
			Post = post;
		}
	}
}
