using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
    public static class CategoryMapper
    {
        public static Category.Category ToDomain(this CategoryModel model)
        {
            return Mapper.Map<CategoryModel, Category.Category>(model);
        }

        public static List<Category.Category> ToDomain(this List<CategoryModel> models)
        {
            return models.Select(model => model.ToDomain()).ToList();
        }

        public static CategoryModel ToModel(this Category.Category category)
        {
            return new CategoryModel
            {
                BlogId = category.BlogId,
                Id = category.Id,
                Title = category.Title
            };
        }

        public static List<CategoryModel> ToModels(this List<Category.Category> categories)
        {
            return categories.Select(entity => entity.ToModel()).ToList();
        }
    }
}
