namespace Weapsy.Blog.Domain.Comment.Exceptions
{
    public class CommentAlreadyApprovedException : CommentException
	{
        public CommentAlreadyApprovedException(string message) : base(message)
        {
        }
    }
}
