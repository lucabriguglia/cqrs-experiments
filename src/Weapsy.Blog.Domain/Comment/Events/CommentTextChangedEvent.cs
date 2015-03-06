using System;

namespace Weapsy.Blog.Domain.Comment.Events
{
    public class CommentTextChangedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }

        public CommentTextChangedEvent(Guid id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
