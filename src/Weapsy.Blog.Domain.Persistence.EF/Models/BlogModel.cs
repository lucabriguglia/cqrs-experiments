using System;
using System.Collections.Generic;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
    public class BlogModel : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        private ICollection<CategoryModel> _categories;
        public virtual ICollection<CategoryModel> Categories
        {
            get { return _categories ?? (_categories = new List<CategoryModel>()); }
            protected set { _categories = value; }
        }

        private ICollection<PostModel> _posts;
        public virtual ICollection<PostModel> Posts
        {
            get { return _posts ?? (_posts = new List<PostModel>()); }
            protected set { _posts = value; }
        }
    }
}
