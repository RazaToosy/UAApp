using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;

namespace UAApp.Infrastructure.DataStore
{
    public class InMemoryRepository<T> : IRepository<T> where T:class
    {
        private InMemoryContext _inMemoryContext;

        public InMemoryRepository(InMemoryContext theInMemoryContext)
        {
            _inMemoryContext = theInMemoryContext;
        }
        public void AddEntities(IList<T> Entities)
        {
            _inMemoryContext.AddEntities(Entities);
        }

        public void AddEntity(T Entity)
        {
            _inMemoryContext.AddEntity(Entity);
        }

        public IList<T> findEntities(Expression<Func<T, int>> predicate)
        {
            return _inMemoryContext.findEntities(predicate as Func<T,int>);
        }

        public T findEntity(Func<T, int> predicate)
        {
            return _inMemoryContext.findEntity(predicate);
        }

        public T FindById(int Id)
        {
            return _inMemoryContext.findById<T>(Id);
        }
    }
}
