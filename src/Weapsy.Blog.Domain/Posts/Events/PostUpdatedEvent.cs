namespace Weapsy.Blog.Domain.Posts.Events
{
    public class PostUpdatedEvent : IDomainEvent
    {
		public Post Post { get; private set; }

		public PostUpdatedEvent(Post post)
		{
			Post = post;
		}
	}
}
