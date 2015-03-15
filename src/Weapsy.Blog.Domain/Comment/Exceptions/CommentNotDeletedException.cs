namespace Weapsy.Blog.Domain.Comment.Exceptions
{
	public class CommentNotDeletedException : CommentException
	{
		public CommentNotDeletedException(string message) : base(message)
		{
		}
	}
}
