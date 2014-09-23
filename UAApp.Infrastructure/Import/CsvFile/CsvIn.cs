using System.Collections.Generic;
using System.Linq;
using LINQtoCSV;
using UAApp.Core.Interfaces;

namespace UAApp.Infrastructure.Import.CsvFile
{
    public class CsvIn<T> : IImportData<T> where T:  class, new()
    {
        public IList<T> FetchList(string FileName)
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            CsvContext cc = new CsvContext();
            IEnumerable<T> iEnumeraableEntities = cc.Read<T>(FileName, inputFileDescription);
            return new List<T>(iEnumeraableEntities.ToList());
        }
    }
}
