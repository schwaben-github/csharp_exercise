using ExcelDataReader;
using ExcelDataReader.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation8
{
    internal class ExcelLib
    {
        private static List<DataCollection> dataCol = new List<DataCollection>();

        public static DataTable ExcelToDataTable(string fileName)
        {
            // open file and return as stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            // create openxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            
            // Set the First Row as Column Name
            // IsFirstRowAsColumnNames is deprecated!
            // excelReader.IsFirstRowAsColumnNames = true;

            // Return as DataSet
            DataSet result = excelReader.AsDataSet();
            // Get all the tables
            DataTableCollection table = result.Tables;
            // Store it in DataTable
            DataTable resultTable = table["Sheet1"];

            // return
            return resultTable;
        }

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            // Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    // Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                IEnumerable<string> enumerable()
                {
                    foreach (var colData in dataCol)
                    {
                        if (colData.colName == columnName && colData.rowNumber == rowNumber)
                        {
                            yield return colData.colValue;
                        }
                    }
                }
                // Retriving Data using LINQ to reduce much of iterations
                string data = enumerable().SingleOrDefault();

                //var datas = dataCollections.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public class DataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }
    }
}
