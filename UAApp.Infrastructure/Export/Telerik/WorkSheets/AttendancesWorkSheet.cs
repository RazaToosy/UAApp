using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Telerik.Windows.Documents.Spreadsheet.Model;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Core.Models.Queries;

namespace UAApp.Infrastructure.Export.Telerik.WorkSheets
{
    public class AttendancesWorkSheet : IWorkSheet<ModelLastMonthAttendances>
    {
        private Workbook _workBook;
        private readonly ThemableColor _workSheetBackgroud = new ThemableColor(Color.FromArgb(255, 44, 62, 80));
        private readonly ThemableColor _workSheetforegroud = new ThemableColor(Color.FromArgb(255, 255, 255, 255));
        private string _titleOfWorkSheet;

        public AttendancesWorkSheet(Workbook WorkBook, String TitleOfWorkSheet)
        {
            _workBook = WorkBook;
            _titleOfWorkSheet = TitleOfWorkSheet;
        }

        public Workbook WorkBook
        {
            get { return _workBook; }
            set { _workBook = value; }
        }

        public void PopulateWorkSheet( List<ModelLastMonthAttendances> entities)
        {
            _workBook.Sheets.Add(SheetType.Worksheet);

            Worksheet worksheet = _workBook.Worksheets[_workBook.Worksheets.Count-1];

            CellIndex firstUsedCellIndex = new CellIndex(0, 0);
            worksheet.Cells[firstUsedCellIndex].SetValue(_titleOfWorkSheet);
            worksheet.Cells[firstUsedCellIndex].SetFontSize(20);
            worksheet.Cells[firstUsedCellIndex].SetHorizontalAlignment(RadHorizontalAlignment.Center);
            worksheet.Cells[0, 0, 0, 26].MergeAcross();

            worksheet.Cells[0, 0, 1, 26].SetFill(new GradientFill(GradientType.Horizontal, _workSheetBackgroud, _workSheetBackgroud));
            worksheet.Cells[0, 0, 1, 26].SetForeColor(_workSheetforegroud);

            worksheet.Cells[1, 0].SetValue("Notes");
            worksheet.Cells[1, 1].SetValue("Surgery Name");
            worksheet.Cells[1, 2].SetValue("Emis No");
            worksheet.Cells[1, 3].SetValue("Usual GP");
            worksheet.Cells[1, 4].SetValue("NHS No");
            worksheet.Cells[1, 5].SetValue("Title");
            worksheet.Cells[1, 6].SetValue("Family Name");
            worksheet.Cells[1, 7].SetValue("Calling Name");
            worksheet.Cells[1, 8].SetValue("Date of Arrival");
            worksheet.Cells[1, 9].SetValue("Time of Arrival");
            worksheet.Cells[1, 10].SetValue("Arrival Mode");
            worksheet.Cells[1, 11].SetValue("Presented With");
            worksheet.Cells[1, 12].SetValue("Diagnosis Description");
            worksheet.Cells[1, 13].SetValue("Attendance Disposal");
            worksheet.Cells[1, 14].SetValue("Age");
            worksheet.Cells[1, 15].SetValue("Date of Birth");
            worksheet.Cells[1, 16].SetValue("Gender");
            worksheet.Cells[1, 17].SetValue("House Name Flat Number");
            worksheet.Cells[1, 18].SetValue("Number and Street");
            worksheet.Cells[1, 19].SetValue("Locality");
            worksheet.Cells[1, 20].SetValue("Town");
            worksheet.Cells[1, 21].SetValue("County");
            worksheet.Cells[1, 22].SetValue("PostCode");
            worksheet.Cells[1, 23].SetValue("Home Telephone");
            worksheet.Cells[1, 24].SetValue("Mobile Telephone"); 
            worksheet.Cells[1, 25].SetValue("Work Telephone");

            worksheet.Columns[0].SetWidth(new ColumnWidth(200, true));
            worksheet.Columns[8].SetWidth(new ColumnWidth(100, true));
            worksheet.Columns[9].SetWidth(new ColumnWidth(100, true));
            worksheet.Columns[11].SetWidth(new ColumnWidth(200, true));
            worksheet.Columns[13].SetWidth(new ColumnWidth(100, true));

            int currentRow = 2;
            entities.ForEach(e =>
            {
                worksheet.Cells[currentRow, 0].SetValue(e.Notes);
                worksheet.Cells[currentRow, 1].SetValue(e.OrganisationName);
                worksheet.Cells[currentRow, 2].SetValue(e.EmisNo);
                worksheet.Cells[currentRow, 3].SetValue(e.UsualGP);
                worksheet.Cells[currentRow, 4].SetValue(e.NHSNo);
                worksheet.Cells[currentRow, 5].SetValue(e.Title);
                worksheet.Cells[currentRow, 6].SetValue(e.FamilyName);
                worksheet.Cells[currentRow, 7].SetValue(e.CallingName);
                worksheet.Cells[currentRow, 8].SetValue(e.DateOfArrival.ToShortDateString());
                worksheet.Cells[currentRow, 9].SetValue(e.TimeOfArrival);
                worksheet.Cells[currentRow, 10].SetValue(e.ArrivalMode);
                worksheet.Cells[currentRow, 11].SetValue(e.PresentedWith);
                worksheet.Cells[currentRow, 12].SetValue(e.DiagnosisDescription);
                worksheet.Cells[currentRow, 13].SetValue(e.AttendanceDisposal.ToString());
                worksheet.Cells[currentRow, 14].SetValue(e.Age);
                worksheet.Cells[currentRow, 15].SetValue(e.DateOfBirth.ToShortDateString());
                worksheet.Cells[currentRow, 16].SetValue(e.Gender);
                worksheet.Cells[currentRow, 17].SetValue(e.HouseNameFlatNumber);
                worksheet.Cells[currentRow, 18].SetValue(e.NumberAndStreet);
                worksheet.Cells[currentRow, 19].SetValue(e.Locality);
                worksheet.Cells[currentRow, 20].SetValue(e.Town);
                worksheet.Cells[currentRow, 21].SetValue(e.County);
                worksheet.Cells[currentRow, 22].SetValue(e.PostCode);
                worksheet.Cells[currentRow, 23].SetValue(e.HomeTelephone);
                worksheet.Cells[currentRow, 24].SetValue(e.MobileTelephone);
                worksheet.Cells[currentRow, 25].SetValue(e.WorkTelephone);
                currentRow++;
            });

        }
    }
}
