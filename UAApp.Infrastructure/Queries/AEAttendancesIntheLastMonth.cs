using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Enums;
using UAApp.Core.Interfaces;
using UAApp.Core.Models.Queries;

namespace UAApp.Infrastructure.Queries
{
    public class AEAttendancesIntheLastMonth
    {
        public IList<ModelLastMonthAttendances> ReturnAttendancesInTheLastMonth(IContext Context, String OrganisationCode)
        {
            var admissions = (from a in Context.Attendances
                              join p in Context.Patients
                                  on a.NHSNo equals p.NHSNo
                              where a.DateOfArrival > DateTime.Now.AddDays(-34)
                              where p.OrganisationCode == OrganisationCode
                              select new ModelLastMonthAttendances
                              {
                                  Age = p.Age.GetValueOrDefault(),
                                  ArrivalMode = a.ArrivalMode,
                                  AttendanceDisposal =    (DischargeCodes)Convert.ToInt32(a.AttendanceDisposal),
                                  CallingName = p.CallingName,
                                  County = p.County,
                                  DateOfArrival = a.DateOfArrival.GetValueOrDefault(),
                                  DateOfBirth = p.DateOfBirth.GetValueOrDefault(),
                                  DiagnosisDescription = a.DiagnosisDescription,
                                  EmisNo = p.EmisNo.GetValueOrDefault(),
                                  FamilyName = p.FamilyName,
                                  Gender = p.Gender,
                                  HomeTelephone = p.HomeTelephone,
                                  HouseNameFlatNumber = p.HouseNameFlatNumber,
                                  Locality = p.Locality,
                                  MobileTelephone = p.MobileTelephone,
                                  NHSNo = p.NHSNo,
                                  Notes = string.Empty,
                                  NumberAndStreet = p.NumberAndStreet,
                                  OrganisationName = p.OrganisationName,
                                  PostCode = p.PostCode,
                                  PresentedWith = a.PresentedWith,
                                  TimeOfArrival = a.TimeOfArrival,
                                  Title = p.Title,
                                  Town = p.Town,
                                  UsualGP = p.UsualGP,
                                  WorkTelephone = p.WorkTelephone
                              }).ToList();

            return admissions;
        }
    }
}
