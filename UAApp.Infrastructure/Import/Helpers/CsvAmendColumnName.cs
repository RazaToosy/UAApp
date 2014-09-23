using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UAApp.Infrastructure.Import.Helpers
{
    public class CsvAmendColumnName
    {

        private List<string> _csvContent;
        private String _filename;

        public CsvAmendColumnName(String FileName)
        {
            _csvContent = new List<string>(File.ReadAllLines(FileName).ToList());
            _filename = FileName;
        }

        public void RemoveSpaces()
        {
            var line = _csvContent[0].Replace(" ", string.Empty);
            save(line);
        }

        public void AmendColumName( String FindString, String ReplaceString)
        {
            var line = _csvContent[0].Replace(FindString, ReplaceString);
            save(line);
        }

        public void RemoveTrialingComma()
        {
            var line = _csvContent[0];
            if (line.EndsWith(",")) line = line.Remove(line.Length - 1);
            save(line);
        }

        private void save( String line)
        {
            _csvContent.RemoveAt(0);
            _csvContent.Insert(0, line);
            File.WriteAllLines(_filename, _csvContent.ToArray());
        }

    }
}
