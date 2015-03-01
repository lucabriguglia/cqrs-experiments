using System;

namespace Weapsy.Blog.Domain.Category
{
	public interface ICategoryRepository : IRepository<Category>
	{
		object GetByBlogIdAndTitle(Guid blogId, string title);
	}
}
