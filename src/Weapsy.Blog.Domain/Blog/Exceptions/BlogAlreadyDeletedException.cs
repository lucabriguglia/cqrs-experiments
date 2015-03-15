namespace Weapsy.Blog.Domain.Blog.Exceptions
{
	public class BlogAlreadyDeletedException : BlogException
	{
		public BlogAlreadyDeletedException(string message) : base(message)
		{
		}
	}
}
