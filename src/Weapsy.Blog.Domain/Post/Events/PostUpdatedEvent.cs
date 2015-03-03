namespace Weapsy.Blog.Domain.Post.Events
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
