using System;
using System.Collections.Generic;
using Weapsy.Blog.Domain.Post.Events;
using Weapsy.Blog.Domain.Post.Exceptions;

namespace Weapsy.Blog.Domain.Post
{
    public class Post : AggregateRoot
    {
        public Guid BlogId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public bool Deleted { get; private set; }
        public bool Published { get; private set; }
        public List<Guid> Categories { get; private set; }
        public List<string> Tags { get; private set; }

        public Post()
        {
            Id = Guid.Empty;
            Deleted = false;
            Categories = new List<Guid>();
            Tags = new List<string>();
        }

        private Post(Guid blogId, string title, string content, bool published, List<Guid> categories, List<string> tags) : this()
        {
            BlogId = blogId;
            Title = title;
            Content = content;
            Published = published;
            Categories = categories;
            Tags = tags;

            Id = Guid.NewGuid();
            MarkNew();

			Events.Add(new PostCreatedEvent(this));
		}

        public static Post CreateNew(Guid blogId, string title, string content, bool published, List<Guid> categories, List<string> tags)
        {
            return new Post(blogId, title, content, published, categories, tags);
        }

        public void Update(string title, string content, List<Guid> categories, List<string> tags)
        {
            IsPostCreated();

            Title = title;
            Content = content;
            Categories = categories;
            Tags = tags;

            MarkOld();

			Events.Add(new PostUpdatedEvent(this));
		}

        public void Publish()
        {
            IsPostCreated();

            if (Deleted)
            {
                throw new PostDeletedException("The Post is deleted and can not be published.");
            }

            if (Published)
            {
                throw new PostAlreadyPublishedException("The Post is already published.");
            }

            Published = true;

            MarkOld();

			Events.Add(new PostPublishedEvent(Id));
		}

        public void Unpublish()
        {
            IsPostCreated();

            if (!Published)
            {
                throw new PostNotPublishedException("The Post is not published.");
            }

            Published = false;

            MarkOld();

			Events.Add(new PostUnpublishedEvent(Id));
		}

        public void Delete()
        {
            IsPostCreated();

            if (Deleted)
            {
                throw new PostAlreadyDeletedException("The Post is already deleted.");
            }

            Deleted = true;
            Published = false;

            MarkOld();

			Events.Add(new PostDeletedEvent(Id));
		}

        public void Restore()
        {
            IsPostCreated();

            if (!Deleted)
            {
                throw new PostNotDeletedException("The Post is not deleted and the restore operation can not be executed.");
            }

            Deleted = false;

            MarkOld();

			Events.Add(new PostRestoredEvent(Id));
		}

        private void IsPostCreated()
        {
            if (Id == Guid.Empty)
            {
                throw new PostNotCreatedException("The Post is not created and no opperations can be executed on it.");
            }
        }
    }
}
