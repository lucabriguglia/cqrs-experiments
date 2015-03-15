namespace Weapsy.Blog.Domain.Comment.Exceptions
{
	public class CommentAlreadyDeletedException : CommentException
	{
		public CommentAlreadyDeletedException(string message) : base(message)
		{
		}
	}
}
