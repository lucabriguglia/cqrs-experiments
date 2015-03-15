namespace Weapsy.Blog.Domain.Blog.Exceptions
{
	public class BlogNotCreatedException : BlogException
	{
		public BlogNotCreatedException(string message) : base(message)
		{
		}
	}
}
