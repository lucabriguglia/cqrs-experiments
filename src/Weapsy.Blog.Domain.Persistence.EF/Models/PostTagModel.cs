using System;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
    public class PostTagModel : IEntity
    {
        public Guid PostId { get; set; }
        public string TagName { get; set; }

        public virtual PostModel Post { get; set; }
    }
}
