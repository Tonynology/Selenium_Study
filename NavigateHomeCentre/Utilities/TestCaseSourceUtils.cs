using System;
using System.Collections.Generic;
using System.Text;
using AutomationWrapper.Utilities;

namespace NavigateHomeCentre.Utilities
{
    class TestCaseSourceUtils
    {

        public static object[] VerifyEmptySignData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeCentre\TestData\HomeCentreData.xlsx",
                "LoginTest");
            return main;
        }

        public static object[] VerifySignUpData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeCentre\TestData\HomeCentreData.xlsx",
                "SignUpTest");
            return main;
        }
        public static object[] VerifyPlaceOrderData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray(
                @"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\NavigateHomeCentre\TestData\HomeCentreDataxlsx.xlsx",
                "OrderTest");
            return main;
        }
    }
}