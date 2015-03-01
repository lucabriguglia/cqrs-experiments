namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostDeletedException : PostException
    {
        public PostDeletedException(string message): base(message)
        {
        }
    }
}
