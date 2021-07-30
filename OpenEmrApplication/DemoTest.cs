using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using Newtonsoft.Json;

namespace OpenEmrApplication
{
    class DemoTest
    {
        [Test]
        public void JSONRead()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\OpenEmrApplication\TestData\data.json");
            string text = reader.ReadToEnd();
            //Console.WriteLine(text);

            dynamic json = JsonConvert.DeserializeObject(text);
            Console.WriteLine(json["browser"]);
            Console.WriteLine(json["url"]);
        }

        [Test]
        public void ExcelRead()
        {
            XLWorkbook book = new XLWorkbook(@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\OpenEmrApplication\TestData\OpenEMRData.xlsx");
            IXLWorksheet sheet = book.Worksheet("InvalidCredentialTest");
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
                    string cellValue = Convert.ToString(range.Cell(i, j).Value);
                    Console.WriteLine(cellValue);

                    //load temp object
                    temp[j - 1] = cellValue;
                }
                //add it to main object
                main[i-2] = temp;
            }
            
            book.Dispose();
        }
        //john,john123
        //peter,peter123
        //mark,mark123

        //how many testcase? --> hew many temp object and size of main object
        //how many parameter in each testcase? --> size of tempobject
        public static object[] ValidDate()
        {
            object[] temp1 = new object[2];
            temp1[0] = "john";
            temp1[1] = "john123";

            object[] temp2 = new object[2];
            temp2[0] = "peter";
            temp2[1] = "peter123";

            object[] temp3 = new object[2];
            temp3[0] = "mark";
            temp3[1] = "mark123";

            object[] main = new object[3];
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }

        [Test, TestCaseSource("ValidDate")]
        public void ValidTest(string username, string password)
        {
            Console.WriteLine(username + password);
        }
    }
}
