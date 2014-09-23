using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Infrastructure.Import.XlsFile;

namespace UAApp.UnitTests
{
    [TestClass]
    public class XlsImport_ReturnsList
    {
        [TestMethod]
        public void AEAttendanceFromFileNameImportsIntoList()
        {
            string filename =
                @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\A+E\Sutton Commissioning A&E Attendances_20120503.xls";
            IImportData<ModelAttendance> fetchingService = new AEAttendancesIn<ModelAttendance>();

            var attendances = new List<ModelAttendance>(fetchingService.FetchList(filename));
            Assert.IsNotNull(attendances);
        }

        [TestMethod]
        public void DischargesFromFileNameImportsIntoList()
        {
            string filename =
                @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat\DischargesIn\Sutton Commissioning Discharges_20140728.xls";

            IImportData<ModelDischarge> fetchingService = new AEAttendancesIn<ModelDischarge>();

            var attendances = new List<ModelDischarge>(fetchingService.FetchList(filename));
            Assert.IsNotNull(attendances);
        }

    }
}
