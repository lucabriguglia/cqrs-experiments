using System.Collections.Generic;
using System.Linq;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
	public static class BlogMapper
	{
		public static Blog.Blog ToDomain(this BlogModel model)
		{
			var blog = new Blog.Blog();

			blog.GetType().GetProperty("Id").SetValue(blog, model.Id, null);
			blog.GetType().GetProperty("Title").SetValue(blog, model.Title, null);

			return blog;
		}

		public static List<Blog.Blog> ToDomain(this List<BlogModel> models)
		{
			return models.Select(model => model.ToDomain()).ToList();
		}

		public static BlogModel ToModel(this Blog.Blog blog)
		{
			return new BlogModel
			{
				Id = blog.Id,
				Title = blog.Title
			};
		}

		public static List<BlogModel> ToModel(this List<Blog.Blog> blogs)
		{
			return blogs.Select(entity => entity.ToModel()).ToList();
		}
	}
}
