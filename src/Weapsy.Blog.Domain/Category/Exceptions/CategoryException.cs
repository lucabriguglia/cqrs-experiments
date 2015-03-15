using System;

namespace Weapsy.Blog.Domain.Category.Exceptions
{
	public class CategoryException : Exception
	{
		public CategoryException(string message) : base(message)
		{
		}
	}
}
