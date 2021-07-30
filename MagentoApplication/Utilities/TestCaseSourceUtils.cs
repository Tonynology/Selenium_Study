using AutomationWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagentoApplication.Utilities
{
    class TestCaseSourceUtils
    {
        public static object[] ValidCredentialData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray
                (@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\MagentoApplication\TestData\MagentoData.xlsx",
                "ValidLoginTest");
            return main;
        }
        public static object[] InvalidCredentialData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray
                (@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\MagentoApplication\TestData\MagentoData.xlsx",
                "InvalidLoginTest");
            return main;
        }
    }
}
