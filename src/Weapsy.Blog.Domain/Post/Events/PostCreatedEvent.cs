namespace Weapsy.Blog.Domain.Post.Events
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
