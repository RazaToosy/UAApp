using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Infrastructure.Import.CsvFile;
using UAApp.Infrastructure.Import.Helpers;

namespace UAApp.UnitTests
{
    [TestClass]
    public class CsvImport_ReturnsList
    {
        [TestMethod]
        public void ImportSollisData_ReturnList()
        {
            string FileName = @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\Sollis\Park Road Centre\Des.processed.csv";

            new CsvRemoveLines(FileName, 3);
            IImportData<ModelSollisEntry> fetchingService = new CsvIn<ModelSollisEntry>();
            var sollisEntries = new List<ModelSollisEntry>(fetchingService.FetchList(FileName));

            Assert.IsNotNull(sollisEntries);

        }

        [TestMethod]
        public void ImportPatientData_ReturnList()
        {
            //string FileName = @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\Patients\Park Road Centre\Demographics of Unplanned Admission DES.csv";

           // new CsvRemoveLines(FileName, 9);
            string FileName = @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\Patients\Park Road Centre\Demographics of Unplanned Admission DES.processed.csv";
            new CsvAmendColumnName(FileName).RemoveTrialingComma();

            IImportData<ModelPatient> fetchingService = new CsvIn<ModelPatient>();
            var patientEntries = new List<ModelPatient>(fetchingService.FetchList(FileName));
            Assert.IsNotNull(patientEntries);

        }
    }
}
