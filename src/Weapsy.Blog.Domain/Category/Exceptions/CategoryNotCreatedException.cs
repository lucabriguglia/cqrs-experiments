namespace Weapsy.Blog.Domain.Category.Exceptions
{
	public class CategoryNotCreatedException : CategoryException
	{
		public CategoryNotCreatedException(string message) : base(message)
		{
		}
	}
}
