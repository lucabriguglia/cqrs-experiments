namespace Weapsy.Blog.Domain.Post.Exceptions
{
    public class PostNotPublishedException : PostException
    {
        public PostNotPublishedException(string message): base(message)
        {
        }
    }
}
