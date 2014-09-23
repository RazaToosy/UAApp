using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAApp.Infrastructure.Import.Helpers;

namespace UAApp.UnitTests
{
    [TestClass]
    public class CsvHelpers_AmendsFiles
    {
        [TestMethod]
        public void ChangeColumnName_IsNotNull()
        {
            string FileName = @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\Patients\Park Road Centre\Demographics of Unplanned Admission DES.csv";

            string FindString = "House Name / Flat Number";

            string ReplaceString = "House NameFlat Number";

            var amend = new CsvAmendColumnName(FileName);
            amend.AmendColumName(FindString,ReplaceString);

            Assert.IsNotNull(amend);
        }
    }
}
