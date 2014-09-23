using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAApp.Core.Interfaces
{
    public interface IExport
    {
        void CreateWorkBook();
        void CreateNewWorksheet<T>(IList<T> entities, String TitleOfWorkSheet) where T : class;
        void SaveWorkBook(String selectedFormat, String LocationToSave);
    }
}
