using System;
using System.Collections.Generic;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
    public class CategoryModel : IEntity
    {
        public Guid BlogId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual BlogModel Blog { get; set; }

        private ICollection<PostCategoryModel> _postCategories;
        public virtual ICollection<PostCategoryModel> PostCategories
        {
            get { return _postCategories ?? (_postCategories = new List<PostCategoryModel>()); }
            protected set { _postCategories = value; }
        }
    }
}