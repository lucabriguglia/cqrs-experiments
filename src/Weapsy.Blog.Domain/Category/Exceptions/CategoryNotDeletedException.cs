namespace Weapsy.Blog.Domain.Category.Exceptions
{
	public class CategoryNotDeletedException : CategoryException
	{
		public CategoryNotDeletedException(string message) : base(message)
		{
		}
	}
}
