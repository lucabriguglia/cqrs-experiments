namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostNotCreatedException : PostException
    {
        public PostNotCreatedException(string message) : base(message)
        {
        }
    }
}
