using System.Collections.Generic;
using System.Linq;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
	public static class CommentMapper
	{
		public static Comment.Comment ToDomain(this CommentModel model)
		{
			var comment = new Comment.Comment();

			comment.GetType().GetProperty("PostId").SetValue(comment, model.PostId, null);
			comment.GetType().GetProperty("Id").SetValue(comment, model.Id, null);
			comment.GetType().GetProperty("Text").SetValue(comment, model.Text, null);
			comment.GetType().GetProperty("Approved").SetValue(comment, model.Approved, null);

			return comment;
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
