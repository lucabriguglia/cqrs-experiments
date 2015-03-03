using System;

namespace Weapsy.Blog.Domain.Post
{
	public interface IPostRepository : IRepository<Post>
	{
		Post GetByBlogIdAndTitle(Guid blogId, string title);
	}
}
