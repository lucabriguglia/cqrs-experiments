namespace Weapsy.Blog.Domain.Blog
{
	public interface IBlogRepository : IRepository<Blog>
	{
		Blog GetByTitle(string title);
	}
}
