using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
    public class CommentDeletedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }

        public CommentDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
