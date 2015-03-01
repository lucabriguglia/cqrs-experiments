using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Weapsy.Blog.Domain.Persistence.EF.Models;
using Weapsy.Blog.Domain.Posts;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
    public static class PostMapper
    {
        public static Post ToDomain(this PostModel model)
        {
            var post = Mapper.Map<PostModel, Post>(model);

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

        public static List<Post> ToDomain(this List<PostModel> models)
        {
            return models.Select(model => model.ToDomain()).ToList();
        }

        public static PostModel ToModel(this Post post)
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

        public static List<PostModel> ToModel(this List<Post> posts)
        {
            return posts.Select(entity => entity.ToModel()).ToList();
        }
    }
}
