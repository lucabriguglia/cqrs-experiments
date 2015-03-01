using System;

namespace Weapsy.Blog.Domain.Comment.Exceptions
{
    public class CommentException : Exception
    {
        public CommentException(string message) : base(message)
        {
        }
    }
}
