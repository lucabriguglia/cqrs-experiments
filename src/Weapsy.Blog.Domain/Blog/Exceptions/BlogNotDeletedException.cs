namespace Weapsy.Blog.Domain.Blog.Exceptions
{
    public class BlogNotDeletedException : BlogException
    {
        public BlogNotDeletedException(string message): base(message)
        {
        }
    }
}
