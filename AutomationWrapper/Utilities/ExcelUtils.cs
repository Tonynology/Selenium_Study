using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWrapper.Utilities
{
    public class ExcelUtils
    {
        public static object[] GetSheetIntoTwoDimObjectArray(string fileDetail, string sheetname)
        {
            XLWorkbook book = new XLWorkbook(fileDetail);
            IXLWorksheet sheet = book.Worksheet(sheetname);
            IXLRange range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            object[] main = new object[rowCount - 1];

            for (int i = 2; i <= rowCount; i++)
            {
                //create temp object
                object[] temp = new object[colCount];

                for (int j = 1; j <= colCount; j++)
                {
                    //load temp object
                    temp[j - 1] = Convert.ToString(range.Cell(i, j).Value);
                }
                //add it to main object
                main[i - 2] = temp;
            }
            book.Dispose();
            return main;
        }


    }
}
