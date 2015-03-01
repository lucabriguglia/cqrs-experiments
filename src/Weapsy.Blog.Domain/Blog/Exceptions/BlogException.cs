using System;

namespace Weapsy.Blog.Domain.Blog.Exceptions
{
    public class BlogException : Exception
    {
        public BlogException(string message) : base(message)
        {
        }
    }
}
