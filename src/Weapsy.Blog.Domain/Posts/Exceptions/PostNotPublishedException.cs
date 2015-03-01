namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostNotPublishedException : PostException
    {
        public PostNotPublishedException(string message): base(message)
        {
        }
    }
}
