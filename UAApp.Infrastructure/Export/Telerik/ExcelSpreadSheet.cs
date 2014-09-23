using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Csv;
using Telerik.Windows.Documents.Spreadsheet.Model;
using UAApp.Core.Interfaces;
using UAApp.Core.Models;
using UAApp.Core.Models.Queries;
using UAApp.Infrastructure.Export.Telerik.WorkSheets;

namespace UAApp.Infrastructure.Export.Telerik
{
    public class ExcelSpreadSheet : IExport
    {
        private Workbook _workbook;

        public ExcelSpreadSheet()
        {
            WorkbookFormatProvidersManager.RegisterFormatProvider(new PdfFormatProvider());
            WorkbookFormatProvidersManager.RegisterFormatProvider(new XlsxFormatProvider());
        }

        public void CreateWorkBook()
        {
            _workbook = new Workbook();
        }

        public void CreateNewWorksheet<T>(IList<T> entities, String TitleOfWorkSheet) where T : class
        {
            Type typeOfEntity = typeof(T);
            if (typeOfEntity == typeof (ModelLastMonthAttendances))
            {
                var newWorkSheet = new AttendancesWorkSheet(_workbook, TitleOfWorkSheet);
                newWorkSheet.PopulateWorkSheet(entities as List<ModelLastMonthAttendances>);
                _workbook = newWorkSheet.WorkBook;
            }
            else if (typeOfEntity == typeof(ModelLastMonthsDischarges))
            {
                var newWorkSheet = new DischargeWorkSheet(_workbook,TitleOfWorkSheet);
                newWorkSheet.PopulateWorkSheet(entities as List<ModelLastMonthsDischarges>);
                _workbook = newWorkSheet.WorkBook;
            }
         }

        public void SaveWorkBook(string selectedFormat, string LocationToSave)
        {
            IWorkbookFormatProvider formatProvider = GetFormatProvider(selectedFormat);

            if (formatProvider == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = String.Format("{0} files|*{1}|All files (*.*)|*.*", selectedFormat,
                formatProvider.SupportedExtensions.First());
            dialog.FileName = LocationToSave;

            using (var stream = dialog.OpenFile())
            {
                formatProvider.Export(_workbook, stream);
            }

        }

        private IWorkbookFormatProvider GetFormatProvider(string extension)
        {
            IWorkbookFormatProvider formatProvider;
            switch (extension)
            {
                case "Xlsx":
                    formatProvider = WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider");
                    break;
                case "Csv":
                    formatProvider = WorkbookFormatProvidersManager.GetProviderByName("CsvFormatProvider");
                    (formatProvider as CsvFormatProvider).Settings.HasHeaderRow = true;
                    break;
                case "Txt":
                    formatProvider = WorkbookFormatProvidersManager.GetProviderByName("TxtFormatProvider");
                    break;
                case "Pdf":
                    formatProvider = WorkbookFormatProvidersManager.GetProviderByName("PdfFormatProvider");
                    break;
                default:
                    formatProvider = null;
                    break;
            }

            return formatProvider;
        }
    }
}
