using System;

namespace Weapsy.Blog.Domain.Post.Exceptions
{
	public class PostException : Exception
	{
		public PostException(string message) : base(message)
		{
		}
	}
}
