using System.Collections.Generic;

namespace Weapsy.Blog.Domain
{
	public interface IAggregateRoot
	{
		ICollection<IDomainEvent> Events { get; }
	}
}
