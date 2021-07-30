using AutomationWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeLane.Utilities
{
    class TestCaseSourceUtils
    {
        public static object[] VerifyEmptySignData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeLane\TestData\HomeLaneData.xlsx",
                "SignUpTest");
            return main;
        }
        public static object[] VerifyEmptyLoginData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeLane\TestData\HomeLaneData.xlsx",
                "LoginTest");
            return main;
        }
        public static object[] VerifyPlaceOrderTest()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeLane\TestData\HomeLaneData.xlsx",
                "OrderTest");
            return main;
        }
    }
}
