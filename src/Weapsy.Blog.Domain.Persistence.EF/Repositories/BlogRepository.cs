using System;
using System.Data.Entity;
using System.Linq;
using Weapsy.Blog.Domain.Blog;
using Weapsy.Blog.Domain.Persistence.EF.MappingExtensions;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.Repositories
{
    public class BlogRepository : IBlogRepository
	{
        private readonly IDbContext _context;
        private readonly IDbSet<BlogModel> _blogs;

        public BlogRepository(IDbContext context)
        {
            _context = context;
            _blogs = context.Set<BlogModel>();
        }

        public void Save(Blog.Blog blog)
        {
            using (_context)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var model = blog.ToModel();

                        if (blog.New)
                        {
                            _blogs.Add(model);
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

        public Blog.Blog GetById(Guid id)
        {
            return _blogs.FirstOrDefault(x => x.Id.Equals(id)).ToDomain();
        }

	    public Blog.Blog GetByTitle(string title)
	    {
			return _blogs.FirstOrDefault(x => x.Title == title).ToDomain();
		}
	}
}
