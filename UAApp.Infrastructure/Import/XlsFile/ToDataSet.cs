using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace UAApp.Infrastructure.Import.XlsFile
{
    public class ToDataSet
    {

        public DataSet Parse(string fileName)
        {
            string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=\"Excel 8.0; HDR=Yes; IMEX=1\";", fileName);
            //string connectionString = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;IMEX=1;FMT=Delimited""", Path.GetDirectoryName(fileName));
            //string connectionString = string.Format("provider=Microsoft.ACE.OLEDB.12.0; data source={0};Extended Properties=\"Excel 12.0 Xml; HDR=Yes; IMEX=1\";", fileName);

            DataSet data = new DataSet();

                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM [{0}]", GetFirstSheet(connectionString));
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);

                    //con.Open();
                    //var query = "SELECT * FROM [" + Path.GetFileName(fileName) + "]";
                    //using (var adapter = new OleDbDataAdapter(query, con))
                    //{
                    //    adapter.Fill(data);
                    //}
                }

            return data;
        }

        private string GetFirstSheet(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null) return null;
            return dt.Rows[0]["TABLE_NAME"].ToString();
        }

        private string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }
    }
}
