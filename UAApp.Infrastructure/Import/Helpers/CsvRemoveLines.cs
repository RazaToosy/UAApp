using System.IO;
using System.Linq;

namespace UAApp.Infrastructure.Import.Helpers
{
    public class CsvRemoveLines
    {
        public CsvRemoveLines(string FileName, int NumberLinesToSkip)
        {
            if (!FileName.Contains(".processed"))
            {
                var newFileName = Path.Combine(Path.GetDirectoryName(FileName),
                    Path.GetFileNameWithoutExtension(FileName) + ".processed" + Path.GetExtension(FileName));
                File.WriteAllLines(newFileName, File.ReadAllLines(FileName).Skip(NumberLinesToSkip).ToArray());
                File.Delete(FileName);
            }
        }
    }
}
