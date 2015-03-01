using System;

namespace Weapsy.Blog.Domain.Posts.Exceptions
{
    public class PostException : Exception
    {
        public PostException(string message) : base(message)
        {
        }
    }
}
