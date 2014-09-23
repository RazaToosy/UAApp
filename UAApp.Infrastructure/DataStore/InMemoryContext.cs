using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Infrastructure.Import.CsvFile;
using UAApp.Infrastructure.Import.Helpers;
using UAApp.Infrastructure.Import.XlsFile;

namespace UAApp.Infrastructure.DataStore
{
    public class InMemoryContext : IContext
    {
        private List<ModelAttendance> _attendances;
        private List<ModelDischarge> _discharges;
        private List<ModelPatient> _patients;
        private List<ModelSollisEntry> _sollisEntries;
        private List<ModelSurgery> _surgeries;

        public InMemoryContext()
        {
            _attendances = new List<ModelAttendance>();
            _discharges = new List<ModelDischarge>();
            _patients = new List<ModelPatient>();
            _sollisEntries = new List<ModelSollisEntry>();
            _surgeries = new List<ModelSurgery>();
        }

        public IList<ModelAttendance> Attendances
        {
            get { return _attendances; }
        }

        public IList<ModelDischarge> Discharges
        {
            get { return _discharges; }
        }

        public IList<ModelPatient> Patients
        {
            get { return _patients; }
        }

        public IList<ModelSollisEntry> SollisEntries
        {
            get { return _sollisEntries; }
        }

        public IList<ModelSurgery> Surgeries
        {
            get { return _surgeries; }
        }


        public void AddEntities<T>(IList<T> Entities) where T : class
        {
            //var list =Entities as List<IEntity>;

            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) _attendances.AddRange(Entities as List<ModelAttendance>);
            else if (typeOfEntity == typeof(ModelDischarge)) _discharges.AddRange(Entities as List<ModelDischarge>);
            else if (typeOfEntity == typeof(ModelPatient)) _patients.AddRange(Entities as List<ModelPatient>);
            else if (typeOfEntity == typeof(ModelSollisEntry)) _sollisEntries.AddRange(Entities as List<ModelSollisEntry>);
            else if (typeOfEntity == typeof(ModelSurgery)) _surgeries.AddRange(Entities as List<ModelSurgery>);
        }

        public void AddEntity<T>(T Entity) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) _attendances.Add(Entity as ModelAttendance);
            else if (typeOfEntity == typeof(ModelDischarge)) _discharges.Add(Entity as ModelDischarge);
            else if (typeOfEntity == typeof(ModelPatient)) _patients.Add(Entity as ModelPatient);
            else if (typeOfEntity == typeof(ModelSollisEntry)) _sollisEntries.Add(Entity as ModelSollisEntry);
            else if (typeOfEntity == typeof(ModelSurgery)) _surgeries.Add(Entity as ModelSurgery);
        }

        public T findEntity<T>(Func<T, int> predicate) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) return _attendances.Find(predicate as Predicate<ModelAttendance>) as T;
            if (typeOfEntity == typeof(ModelDischarge)) return _discharges.Find(predicate as Predicate<ModelDischarge>) as T;
            if (typeOfEntity == typeof(ModelPatient)) return _patients.Find(predicate as Predicate<ModelPatient>) as T;
            if (typeOfEntity == typeof(ModelSollisEntry)) return _sollisEntries.Find(predicate as Predicate<ModelSollisEntry>) as T;
            if (typeOfEntity == typeof(ModelSurgery)) return _surgeries.Find(predicate as Predicate<ModelSurgery>) as T;

            return null;
        }

        public IList<T> findEntities<T>(Func<T, int> predicate) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) return _attendances.FindAll(predicate as Predicate<ModelAttendance>).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelDischarge)) return _discharges.FindAll(predicate as Predicate<ModelDischarge>).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelPatient)) return _patients.FindAll(predicate as Predicate<ModelPatient>).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelSollisEntry)) return _sollisEntries.FindAll(predicate as Predicate<ModelSollisEntry>).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelSurgery)) return _surgeries.FindAll(predicate as Predicate<ModelSurgery>).ToList() as List<T>;

            return null;
        }

        public IList<T> removeDuplicates<T>(IList<T> Entities) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) return _attendances.GroupBy(x => x.AandEUniqueId).Select(y => y.First()).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelDischarge)) return _discharges.GroupBy(x => x.EpisodeId).Select(y => y.First()).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelPatient)) return _patients.GroupBy(x => x.NHSNo).Select(y => y.First()).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelSollisEntry)) return _sollisEntries.GroupBy(x => x.NHSNumber).Select(y => y.First()).ToList() as List<T>;
            if (typeOfEntity == typeof(ModelSurgery)) return _surgeries.GroupBy(x => x.OrganisationCode).Select(y => y.First()).ToList() as List<T>;
            
            return null;
        }

        public T findById<T>(int id) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) return _attendances.FirstOrDefault(x => id == x.ModelAttendanceId) as T;
            if (typeOfEntity == typeof(ModelDischarge)) return _discharges.FirstOrDefault(x => id == x.ModelDischargeId) as T; ;
            if (typeOfEntity == typeof(ModelPatient)) return _patients.FirstOrDefault(x => id == x.ModelPatientId) as T;
            if (typeOfEntity == typeof(ModelSollisEntry)) return _sollisEntries.FirstOrDefault(x => id == x.ModelSolisEntityId) as T;
            if (typeOfEntity == typeof(ModelSurgery)) return _surgeries.FirstOrDefault(x => id == x.ModelSurgeryId) as T;

            return null;
        }

        public IList<T> reIndexList<T>(IList<T> Entities) where T : class
        {
            Type typeOfEntity = typeof(T);

            if (typeOfEntity == typeof(ModelAttendance)) { int index = 1; _attendances.ForEach(i => { i.ModelAttendanceId = index; index++; }); return _attendances.ToList() as List<T>; }
            if (typeOfEntity == typeof(ModelDischarge)) { int index = 1; _discharges.ForEach(i => { i.ModelDischargeId = index; index++; }); return _discharges.ToList() as List<T>; }
            if (typeOfEntity == typeof(ModelPatient)) { int index = 1; _patients.ForEach(i => { i.ModelPatientId = index; index++; }); return _patients.ToList() as List<T>; }
            if (typeOfEntity == typeof(ModelSollisEntry)) { int index = 1; _sollisEntries.ForEach(i => { i.ModelSolisEntityId = index; index++; }); return _sollisEntries.ToList() as List<T>; }
            if (typeOfEntity == typeof(ModelSurgery)) { int index = 1; _surgeries.ForEach(i => { i.ModelSurgeryId = index; index++; }); return _surgeries.ToList() as List<T>; }

            return null;

        }

        public void populateContext(String Source)
        {
            //This is where you import the data
            //Loop through folder from root (source) and work out which has which
            //For each file populate the repository accordingly.
            //Only time when can use this.methods otherwise go through IRepository.
            DirectoryInfo DirInfo = new DirectoryInfo(Source);

            var allfiles = System.IO.Directory.GetFiles(Source, "*.*", System.IO.SearchOption.AllDirectories).ToList();

            var aeAttendanceFiles =
               allfiles.Where(f => Path.GetFileName(f).StartsWith("Sutton Commissioning A&E Attendances")).ToList();
            aeAttendanceFiles.ForEach(f => AddEntities(new AEAttendancesIn<ModelAttendance>().FetchList(f)));
            _attendances = removeDuplicates(Attendances).ToList();
            _attendances = reIndexList(Attendances).ToList();

            var dischargeFiles = allfiles.Where(f => Path.GetFileName(f).StartsWith("Sutton Commissioning Discharges")).ToList();
            dischargeFiles.ForEach(f => AddEntities(new DischargesIn<ModelDischarge>().FetchList(f)));
            _discharges = removeDuplicates(Discharges).ToList();
            _discharges = reIndexList(Discharges).ToList();

            allfiles.Where(f => Path.GetFileName(f).StartsWith("Demographics")).ToList().ForEach(f=> new CsvRemoveLines(f, 9));
            var patientFiles = Directory.GetFiles(Source, "Demographics*.*", SearchOption.AllDirectories).ToList();
            patientFiles.ForEach(f =>
            {
                new CsvAmendColumnName(f).RemoveTrialingComma();
                AddEntities(new CsvIn<ModelPatient>().FetchList(f));
            });
            _patients = reIndexList(Patients).ToList();
            _patients = _patients.Select(x =>
            {
                if (x.NHSNo !=null)  x.NHSNo = new string(x.NHSNo.ToList().Where(c => c != ' ').ToArray());
                return x;
            }).ToList();

            allfiles.Where(f => Path.GetFileName(f).StartsWith("DES")).ToList().ForEach(f => new CsvRemoveLines(f, 3));
            var sollisFiles = Directory.GetFiles(Source, "DES*.*", SearchOption.AllDirectories).ToList();
            sollisFiles.ForEach(f =>
            {
                new CsvAmendColumnName(f).RemoveTrialingComma();
                AddEntities(new CsvIn<ModelSollisEntry>().FetchList(f));
            });
            _sollisEntries = reIndexList(SollisEntries).ToList();

            var surgeryFiles = allfiles.Where(f => Path.GetFileName(f).StartsWith("Surgeries")).ToList();
            surgeryFiles.ForEach(f =>
            {
                new CsvAmendColumnName(f).RemoveTrialingComma();
                AddEntities(new CsvIn<ModelSurgery>().FetchList(f));
            });
            _surgeries = reIndexList(Surgeries).ToList();
        }
    }
}

