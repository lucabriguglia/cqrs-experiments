namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostNotDeletedException : PostException
    {
        public PostNotDeletedException(string message): base(message)
        {
        }
    }
}
