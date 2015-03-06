using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
    public class CommentDisapprovedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }

        public CommentDisapprovedEvent(Guid id)
        {
            Id = id;
        }
    }
}
