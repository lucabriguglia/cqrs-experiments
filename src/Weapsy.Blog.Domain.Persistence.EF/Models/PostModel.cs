using System;
using System.Collections.Generic;

namespace Weapsy.Blog.Domain.Persistence.EF.Models
{
    public class PostModel : IEntity
    {
        public Guid BlogId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Deleted { get; set; }
        public bool Published { get; set; }

        public virtual BlogModel Blog { get; set; }

        private List<PostCategoryModel> _postCategories;
        public virtual List<PostCategoryModel> PostCategories
        {
            get { return _postCategories ?? (_postCategories = new List<PostCategoryModel>()); }
            protected set { _postCategories = value; }
        }

        private List<PostTagModel> _postTags;
        public virtual List<PostTagModel> PostTags
        {
            get { return _postTags ?? (_postTags = new List<PostTagModel>()); }
            protected set { _postTags = value; }
        }

        private List<CommentModel> _comments;
        public virtual List<CommentModel> Comments
        {
            get { return _comments ?? (_comments = new List<CommentModel>()); }
            protected set { _comments = value; }
        }
    }
}