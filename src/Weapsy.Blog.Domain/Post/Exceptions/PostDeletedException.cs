namespace Weapsy.Blog.Domain.Post.Exceptions
{
    public class PostDeletedException : PostException
    {
        public PostDeletedException(string message): base(message)
        {
        }
    }
}
