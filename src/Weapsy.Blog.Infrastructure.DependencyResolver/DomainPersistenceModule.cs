using System;
using Autofac;
using Weapsy.Blog.Domain.Blog;
using Weapsy.Blog.Domain.Persistence.EF.Repositories;
using Weapsy.Blog.Domain.Category;
using Weapsy.Blog.Domain.Comment;
using Weapsy.Blog.Domain.Post;
using Weapsy.Blog.Domain.Persistence.EF;

namespace Weapsy.Blog.Infrastructure.DependencyResolver
{
	public class DomainPersistenceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			builder.RegisterType<BlogContext>().As<IDbContext>();
			builder.RegisterType<BlogRepository>().As<IBlogRepository>();
			builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
			builder.RegisterType<CommentRepository>().As<ICommentRepository>();
			builder.RegisterType<PostRepository>().As<IPostRepository>();
		}
	}
}