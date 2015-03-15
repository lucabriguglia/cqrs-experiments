namespace Weapsy.Blog.Domain.Post.Exceptions
{
	public class PostNotDeletedException : PostException
	{
		public PostNotDeletedException(string message) : base(message)
		{
		}
	}
}
