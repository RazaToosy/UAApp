using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UAApp.Core.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void AddEntities(IList<T> Entities);
        void AddEntity(T Entity);
        IList<T> findEntities(Expression<Func<T, int>> predicate);
        T findEntity(Func<T, int> predicate);
        T FindById(int Id);
    }
}
