using System;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
    public class PostCategoryModel : IEntity
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual PostModel Post { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}
