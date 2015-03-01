using System;

namespace Weapsy.Blog.Domain.Persistence.EF
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Save(T aggregate);
        T GetById(Guid id);
    }
}
