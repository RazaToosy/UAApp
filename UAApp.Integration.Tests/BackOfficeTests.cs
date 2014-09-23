using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAApp.Core.Interfaces;
using UAApp.Core.Models.Queries;
using UAApp.Infrastructure.Export.Telerik;
using UAApp.Infrastructure.Queries;
using UAApp.Infrastructure.TheBrain;

namespace UAApp.Integration.Tests
{
    [TestClass]
    public class BackOfficeTests
    {
        [TestMethod]
        public void PopulateInMemoryContext_IsNotNull()
        {
            string Source = @"C:\MyDropBox\Dropbox\dev\UnplannedAdmissions\dat";

            var theContext = new CreateContext(Source).TheData;

            theContext.Surgeries.ToList().ForEach(s =>
            {
                var workBook = new ExcelSpreadSheet();
                workBook.CreateWorkBook();

                var attendances =
                    new List<ModelLastMonthAttendances>(
                        new AEAttendancesIntheLastMonth().ReturnAttendancesInTheLastMonth(theContext, s.OrganisationCode));
                workBook.CreateNewWorksheet(attendances,string.Format("Attendances to A&E since {0}",DateTime.Now.AddDays(-34).ToLongDateString()));

                var admissions =
                    new List<ModelLastMonthAttendances>(new AdmissionsInTheLastMonth().ReturnAdmissionsInTheLastMonth(theContext, s.OrganisationCode));
                workBook.CreateNewWorksheet(admissions, string.Format("Admissions in to Hospital since {0}", DateTime.Now.AddDays(-34).ToLongDateString()));

                var discharges =
                    new List<ModelLastMonthsDischarges>(
                        new DischargesIntheLastMonth().ReturnDischargesInLastMonth(theContext, s.OrganisationCode));
                workBook.CreateNewWorksheet(discharges, string.Format("Discharged from Hospital since {0}", DateTime.Now.AddDays(-34).ToLongDateString()));

                workBook.SaveWorkBook("Xlsx", Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    string.Format("{0}.Xlsx", s.OrganisationName)));

            });






            Assert.IsNotNull(theContext);

        }
    }
}
