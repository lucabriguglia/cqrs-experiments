using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
    public static class CommentMapper
    {
        public static Comment.Comment ToDomain(this CommentModel model)
        {
            return Mapper.Map<CommentModel, Comment.Comment>(model);
        }

        public static List<Comment.Comment> ToDomain(this List<CommentModel> models)
        {
            return models.Select(model => model.ToDomain()).ToList();
        }

        public static CommentModel ToModel(this Comment.Comment comment)
        {
            return new CommentModel
            {
                Id = comment.Id,
                Text = comment.Text,
                Approved = comment.Approved,
                Deleted = comment.Deleted
            };
        }

        public static List<CommentModel> ToModel(this List<Comment.Comment> comments)
        {
            return comments.Select(entity => entity.ToModel()).ToList();
        }
    }
}
