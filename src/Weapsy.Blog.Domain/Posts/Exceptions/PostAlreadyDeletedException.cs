namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostAlreadyDeletedException : PostException
    {
        public PostAlreadyDeletedException(string message): base(message)
        {
        }
    }
}
