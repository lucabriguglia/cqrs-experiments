namespace Weapsy.Blog.Domain.Category.Exceptions
{
	public class CategoryAlreadyDeletedException : CategoryException
	{
		public CategoryAlreadyDeletedException(string message) : base(message)
		{
		}
	}
}
