namespace Weapsy.Blog.Domain.Post.Exceptions
{
	public class PostNotCreatedException : PostException
	{
		public PostNotCreatedException(string message) : base(message)
		{
		}
	}
}
