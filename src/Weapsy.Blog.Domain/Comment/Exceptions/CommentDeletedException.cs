namespace Weapsy.Blog.Domain.Comment.Exceptions
{
	public class CommentDeletedException : CommentException
	{
		public CommentDeletedException(string message) : base(message)
		{
		}
	}
}
