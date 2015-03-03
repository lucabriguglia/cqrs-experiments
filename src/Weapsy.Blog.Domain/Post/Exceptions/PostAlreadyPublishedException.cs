namespace Weapsy.Blog.Domain.Post.Exceptions
{
    public class PostAlreadyPublishedException : PostException
    {
        public PostAlreadyPublishedException(string message): base(message)
        {
        }
    }
}
