using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace MvcMovie.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ReadExcelToDataTable(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    DataTable dt = new DataTable();

                    // Assuming the first row contains column headers
                    int colCount = worksheet.Dimension.End.Column;
                    for (int col = 1; col <= colCount; col++)
                    {
                        dt.Columns.Add(worksheet.Cells[1, col].Text);
                    }

                    // Start from the second row (skip headers)
                    int rowCount = worksheet.Dimension.End.Row;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int col = 1; col <= colCount; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dt.Rows.Add(dataRow);
                    }

                    return dt;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error, display a user-friendly message)
                throw new Exception("Error reading Excel file.", ex);
            }
        }
    }
}
