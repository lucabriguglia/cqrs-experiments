using System;
using System.Data.Entity;
using System.Linq;
using Weapsy.Blog.Domain.Persistence.EF.MappingExtensions;
using Weapsy.Blog.Domain.Persistence.EF.Models;
using Weapsy.Blog.Domain.Post;

namespace Weapsy.Blog.Domain.Persistence.EF.Repositories
{
	public class PostRepository : IPostRepository
	{
		private readonly IDbContext _context;
		private readonly IDbSet<PostModel> _posts;
		private readonly IDbSet<PostCategoryModel> _postCategories;
		private readonly IDbSet<PostTagModel> _postTags;

		public PostRepository(IDbContext context)
		{
			_context = context;
			_posts = context.Set<PostModel>();
			_postCategories = context.Set<PostCategoryModel>();
			_postTags = context.Set<PostTagModel>();
		}

		public void Save(Post.Post post)
		{
			using (_context)
			{
				using (var dbContextTransaction = _context.Database.BeginTransaction())
				{
					try
					{
						var model = post.ToModel();

						if (post.New)
						{
							_posts.Add(model);
						}
						else
						{
							foreach (var postCategoryModel in _postCategories.Where(x => x.PostId == post.Id).ToList())
							{
								_postCategories.Remove(postCategoryModel);
							}

							foreach (var postTagModel in _postTags.Where(x => x.PostId == post.Id).ToList())
							{
								_postTags.Remove(postTagModel);
							}

							_context.Entry(model).State = EntityState.Modified;
						}

						_context.SaveChanges();

						dbContextTransaction.Commit();
					}
					catch (Exception)
					{
						dbContextTransaction.Rollback();
					}
				}
			}
		}

		public Post.Post GetById(Guid id)
		{
			return _posts
				.Include("PostCategories")
				.Include("PostTags")
				.FirstOrDefault(x => x.Id.Equals(id))
				.ToDomain();
		}

		public Post.Post GetByBlogIdAndTitle(Guid blogId, string title)
		{
			return _posts
				.Include("PostCategories")
				.Include("PostTags")
				.FirstOrDefault(x => x.BlogId.Equals(blogId) && x.Title == title)
				.ToDomain();
		}
	}
}