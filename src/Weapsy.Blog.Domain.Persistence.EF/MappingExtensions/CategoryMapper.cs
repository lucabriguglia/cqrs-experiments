using System.Collections.Generic;
using System.Linq;
using Weapsy.Blog.Domain.Persistence.EF.Models;

namespace Weapsy.Blog.Domain.Persistence.EF.MappingExtensions
{
	public static class CategoryMapper
    {
        public static Category.Category ToDomain(this CategoryModel model)
        {
			var category = new Category.Category();

			category.GetType().GetProperty("BlogId").SetValue(category, model.BlogId, null);
			category.GetType().GetProperty("Id").SetValue(category, model.Id, null);
			category.GetType().GetProperty("Title").SetValue(category, model.Title, null);

			return category;
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
