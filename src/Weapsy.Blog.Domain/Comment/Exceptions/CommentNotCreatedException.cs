namespace Weapsy.Blog.Domain.Comment.Exceptions
{
	public class CommentNotCreatedException : CommentException
	{
		public CommentNotCreatedException(string message) : base(message)
		{
		}
	}
}
