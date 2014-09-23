using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAApp.Core.Interfaces
{
    public interface IWorkSheet<T> where T:class
    {
        void PopulateWorkSheet(List<T> entities);
    }
}
