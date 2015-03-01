using System;

namespace Weapsy.Blog.Domain.Posts
{
	public interface IPostRepository : IRepository<Post>
	{
		Post GetByBlogIdAndTitle(Guid blogId, string title);
	}
}
