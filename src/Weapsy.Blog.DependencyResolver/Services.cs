using Microsoft.Framework.DependencyInjection;
using Weapsy.Blog.Bus;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Domain.Blog;
using Weapsy.Blog.Domain.Category;
using Weapsy.Blog.Domain.Comment;
using Weapsy.Blog.Domain.Persistence.EF;
using Weapsy.Blog.Domain.Persistence.EF.Repositories;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.DependencyResolver
{
	public static class Services
	{
		public static void RegisterBlogServices(IServiceCollection services)
		{
			// bus
			services.AddTransient<ICommandSender, CommandSender>();
			services.AddTransient<IEventPublisher, EventPublisher>();
			services.AddTransient<IQueryDispatcher, QueryDispatcher>();

			// domain
			services.AddTransient<IDbContext, BlogContext>();
			services.AddTransient<IBlogRepository, BlogRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<IPostRepository, PostRepository>();
		}
	}
}
