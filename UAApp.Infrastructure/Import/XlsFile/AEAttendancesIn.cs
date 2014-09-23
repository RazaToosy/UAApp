using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;

namespace UAApp.Infrastructure.Import.XlsFile
{
    public class AEAttendancesIn<T> : IImportData<T> where T : class, new()
    {

        public IList<T> FetchList(string FileName)
        {
            var dsAttendances = new ToDataSet().Parse(FileName);

            var attendances = dsAttendances.Tables[0].AsEnumerable()
                .Select(row => new ModelAttendance
                    {
                        AandEDepartment = row.Field<string>(0) ?? "Null",
                        AandEDepartementName = row.Field<string>(1) ?? "Null",
                        AandEUniqueId = row.Field<string>(2) ?? "Null",
                        PasId = row.Field<string>(3) ?? "Null",
                        PatientName = row.Field<string>(4) ?? "Null",
                        DateOfBirth = row.Field<DateTime>(5),
                        PhoneNo = row.Field<string>(6) ?? "Null",
                        NHSNo = row.Field<string>(7) ?? "Null",
                        GPCode = row.Field<string>(8) ?? "Null",
                        OrganisationCode = row.Field<string>(9) ?? "Null",
                        OrgainsationName = row.Field<string>(10) ?? "Null",
                        DateOfArrival = row.Field<DateTime>(11),
                        TimeOfArrival = row.Field<string>(12) ?? "Null",
                        SourceOfReferralCode = row.Field<string>(13) ?? "Null",
                        ArrivalMode = row.Field<string>(14) ?? "Null",
                        PresentedWith = row.Field<string>(15) ?? "Null",
                        DiagnosisCode = row.Field<string>(16) ?? "Null",
                        DiagnosisDescription = row.Field<string>(17) ?? "Null",
                        InvestigationCodeOne = row.Field<string>(18) ?? "Null",
                        InvestigationCodeTwo = row.Field<string>(19) ?? "Null",
                        TreatmentCodeOne = row.Field<string>(20) ?? "Null",
                        TreatmentCodeTwo = row.Field<string>(21) ?? "Null",
                        TreatmentCodeThree = row.Field<string>(22) ?? "Null",
                        HRG = row.Field<string>(23) ?? "Null",
                        AttendanceDisposal = row.Field<string>(24) ?? "1"
                    }
                ).ToList();

            return attendances as IList<T>;
        }

        private object ConvertFromOATime(double value)
        {
            if ((value >= 0.0) && (value < 60.0))
            {
                value++;
            }
            //if (date1904)
            //{
            //    Value += 1462.0;
            //}

            // added to fix out of range problem, sdh, 20140826
            if (value < 657435.0)
            {
                value = 657435.0;
            }
            else if (value > 2958465.99999999)
            {
                value = 2958465.99999999;
            }
            return DateTime.FromOADate(value);
        }


    }


}
