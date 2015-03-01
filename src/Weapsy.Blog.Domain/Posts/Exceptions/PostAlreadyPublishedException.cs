namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostAlreadyPublishedException : PostException
    {
        public PostAlreadyPublishedException(string message): base(message)
        {
        }
    }
}
