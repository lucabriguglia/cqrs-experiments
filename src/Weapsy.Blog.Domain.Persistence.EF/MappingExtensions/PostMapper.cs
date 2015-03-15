using System.Collections.Generic;
using System.Linq;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
	public static class PostMapper
	{
		public static Post.Post ToDomain(this PostModel model)
		{
			var post = new Post.Post();

			post.GetType().GetProperty("BlogId").SetValue(post, model.BlogId, null);
			post.GetType().GetProperty("Id").SetValue(post, model.Id, null);
			post.GetType().GetProperty("Title").SetValue(post, model.Title, null);
			post.GetType().GetProperty("Content").SetValue(post, model.Content, null);
			post.GetType().GetProperty("Deleted").SetValue(post, model.Deleted, null);
			post.GetType().GetProperty("Published").SetValue(post, model.Published, null);

			foreach (var postCategoryModel in model.PostCategories)
			{
				post.Categories.Add(postCategoryModel.CategoryId);
			}

			foreach (var postTagModel in model.PostTags)
			{
				post.Tags.Add(postTagModel.TagName);
			}

			return post;
		}

		public static List<Post.Post> ToDomain(this List<PostModel> models)
		{
			return models.Select(model => model.ToDomain()).ToList();
		}

		public static PostModel ToModel(this Post.Post post)
		{
			var model = new PostModel
			{
				BlogId = post.BlogId,
				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
				Deleted = post.Deleted,
				Published = post.Published
			};

			foreach (var categoryId in post.Categories)
			{
				var postCategoryModel = new PostCategoryModel
				{
					PostId = post.Id,
					CategoryId = categoryId
				};

				model.PostCategories.Add(postCategoryModel);
			}

			foreach (var tag in post.Tags)
			{
				var postTagModel = new PostTagModel
				{
					PostId = post.Id,
					TagName = tag
				};

				model.PostTags.Add(postTagModel);
			}

			return model;
		}

		public static List<PostModel> ToModel(this List<Post.Post> posts)
		{
			return posts.Select(entity => entity.ToModel()).ToList();
		}
	}
}
