using System;
using System.Data.Entity;
using System.Linq;
using Weapsy.Blog.Domain.Category;
using Weapsy.Blog.Domain.Persistence.EF.MappingExtensions;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly IDbContext _context;
		private readonly IDbSet<CategoryModel> _categories;

		public CategoryRepository(IDbContext context)
		{
			_context = context;
			_categories = context.Set<CategoryModel>();
		}

		public void Save(Category.Category category)
		{
			using (_context)
			{
				using (var dbContextTransaction = _context.Database.BeginTransaction())
				{
					try
					{
						var model = category.ToModel();

						if (category.New)
						{
							_categories.Add(model);
						}
						else
						{
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

		public Category.Category GetById(Guid id)
		{
			return _categories.FirstOrDefault(x => x.Id.Equals(id)).ToDomain();
		}

		public object GetByBlogIdAndTitle(Guid blogId, string title)
		{
			return _categories.FirstOrDefault(x => x.BlogId.Equals(blogId) && x.Title == title).ToDomain();
		}
	}
}
