using System;

namespace Weapsy.Blog.Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Save(T aggregateRoot);
        T GetById(Guid id);
    }
}