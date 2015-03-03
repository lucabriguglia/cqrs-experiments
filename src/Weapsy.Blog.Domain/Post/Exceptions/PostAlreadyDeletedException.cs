namespace Weapsy.Blog.Domain.Post.Exceptions
{
    public class PostAlreadyDeletedException : PostException
    {
        public PostAlreadyDeletedException(string message): base(message)
        {
        }
    }
}
