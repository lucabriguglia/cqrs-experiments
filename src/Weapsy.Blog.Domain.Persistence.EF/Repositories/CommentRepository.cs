using System;
using System.Data.Entity;
using System.Linq;
using Weapsy.Blog.Domain.Comment;
using Weapsy.Blog.Domain.Persistence.EF.MappingExtensions;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDbContext _context;
        private readonly IDbSet<CommentModel> _comments;

        public CommentRepository(IDbContext context)
        {
            _context = context;
            _comments = context.Set<CommentModel>();
        }

        public void Save(Comment.Comment comment)
        {
            using (_context)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var model = comment.ToModel();

                        if (comment.New)
                        {
                            _comments.Add(model);
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

        public Comment.Comment GetById(Guid id)
        {
            return _comments.FirstOrDefault(x => x.Id.Equals(id)).ToDomain();
        }
    }
}
