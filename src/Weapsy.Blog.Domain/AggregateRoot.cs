using System;
using System.Collections.Generic;

namespace Weapsy.Blog.Domain
{
    public class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public bool New { get; protected set; }

		private ICollection<IDomainEvent> _events;
		public ICollection<IDomainEvent> Events
		{
			get { return _events ?? (_events = new List<IDomainEvent>()); }
			protected set { _events = value; }
		}

		protected void MarkNew()
        {
            New = true;
        }

        protected void MarkOld()
        {
            New = false;
        }
    }
}
