using System;
using Weapsy.Blog.Domain.Comment.Events;
using Weapsy.Blog.Domain.Comment.Exceptions;

namespace Weapsy.Blog.Domain.Comment
{
    public class Comment : AggregateRoot
    {
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public bool Approved { get; private set; }
        public bool Deleted { get; private set; }

        public Comment()
        {
            Id = Guid.Empty;
            Deleted = false;
        }

        private Comment(Guid postId, string text, bool approved)
        {
            PostId = postId;
            Text = text;
            Approved = approved;

            Id = Guid.NewGuid();
            MarkNew();

			Events.Add(new CommentCreatedEvent());
		}

        public static Comment CreateNew(Guid postId, string text, bool approved)
        {
            return new Comment(postId, text, approved);
        }

        public void Update(string text)
        {
            Text = text;

            MarkOld();

			Events.Add(new CommentUpdatedEvent());
		}

		public void Approve()
        {
            if (Deleted)
            {
	            throw new CommentDeletedException("The Comment is deleted and can not be approved.");
            }

            if (Approved)
            {
	            throw new CommentAlreadyApprovedException("The Comment is already approved.");
            }

            Approved = true;

            MarkOld();

			Events.Add(new CommentApprovedEvent());
		}

		public void Disapprove()
		{
			if (Deleted)
			{
				throw new CommentDeletedException("The Comment is deleted and can not be disapproved.");
			}

			if (!Approved)
			{
				throw new CommentNotApprovedException("The Comment is already not approved.");
			}

			Approved = false;

			MarkOld();

			Events.Add(new CommentDisapprovedEvent());
		}

		public void Delete()
		{
			if (Deleted)
			{
				throw new CommentAlreadyDeletedException("The Comment is already deleted.");
			}

			Deleted = true;
			Approved = false;

			MarkOld();

			Events.Add(new CommentDeletedEvent());
		}

		public void Restore()
		{
			if (!Deleted)
			{
				throw new CommentNotDeletedException("The Comment is not deleted and the restore operation can not be executed.");
			}

			Deleted = false;

			MarkOld();

			Events.Add(new CommentRestoredEvent());
		}
	}
}
