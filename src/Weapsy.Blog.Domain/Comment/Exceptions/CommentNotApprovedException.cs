namespace Weapsy.Blog.Domain.Comment.Exceptions
{
	public class CommentNotApprovedException : CommentException
	{
		public CommentNotApprovedException(string message) : base(message)
		{
		}
	}
}
