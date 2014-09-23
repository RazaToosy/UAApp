using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;

namespace UAApp.Infrastructure.Import.XlsFile
{
    public class DischargesIn<T> : IImportData<T> where T : class, new()
    {

        public IList<T> FetchList(string FileName)
        {
            var discharges = new ToDataSet().Parse(FileName);

            List<ModelDischarge> attendances = discharges.Tables[0].AsEnumerable()
                .Select(row => new ModelDischarge
                {
                    EpisodeId = row.Field<string>(0),
                    OrganisationCode = row.Field<string>(1),
                    OrganisationName = row.Field<string>(2),
                    PBCConsortiaName = row.Field<string>(3),
                    TypeOfAdmission = row.Field<string>(4),
                    DischargeWardCode = row.Field<string>(5),
                    DischargeWard = row.Field<string>(6),
                    DischargeHospitalSite = row.Field<string>(7),
                    DischargeSpeciality = row.Field<string>(8),
                    NHSNo = row.Field<string>(9),
                    PASHospitalNumber = row.Field<string>(10),
                    PatientName = row.Field<string>(11),
                    DateOfBirth = row.Field<DateTime>(12),
                    AdmissionDate = row.Field<DateTime>(13),
                    DischargeDate = row.Field<DateTime>(14),
                    DishDeceasedFlag = row.Field<string>(15)
                }
                ).ToList();

            return attendances as IList<T>;
        }
    }
}
