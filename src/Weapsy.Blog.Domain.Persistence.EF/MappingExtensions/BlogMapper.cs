using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
    public static class BlogMapper
    {
        public static Blog.Blog ToDomain(this BlogModel model)
        {
            return Mapper.Map<BlogModel, Blog.Blog>(model);
        }

        public static List<Blog.Blog> ToDomain(this List<BlogModel> models)
        {
            return models.Select(model => model.ToDomain()).ToList();
        }

        public static BlogModel ToModel(this Blog.Blog blog)
        {
            return new BlogModel
            {
                Id = blog.Id,
                Title = blog.Title
            };
        }

        public static List<BlogModel> ToModel(this List<Blog.Blog> blogs)
        {
            return blogs.Select(entity => entity.ToModel()).ToList();
        }
    }
}
