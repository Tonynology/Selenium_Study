﻿using AutomationWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Utilities
{
    class TestCaseSourceUtils
    {
        public static object ExelUtils { get; private set; }

        //admin, pass, English (Indian), OpenEMR
        //physicion, physician, English (Indian), OpenEMR

        public static object[] ValidCredentialData()
        {
            object[] temp1 = new object[4];
            temp1[0] = "admin";
            temp1[1] = "pass";
            temp1[2] = "English (Indian)";
            temp1[3] = "OpenEMR";

            object[] temp2 = new object[4];
            temp2[0] = "physician";
            temp2[1] = "physician";
            temp2[2] = "English (Indian)";
            temp2[3] = "OpenEMR";

            object[] temp3 = new object[4];
            temp3[0] = "receptionist";
            temp3[1] = "receptionist";
            temp3[2] = "English (Indian)";
            temp3[3] = "OpenEMR";

            object[] main = new object[3];
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }

        public static object[] InvalidCredentialData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray
                (@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\OpenEmrApplication\TestData\OpenEMRData.xlsx", 
                "InvalidCredentialTest");
            return main;
        }
        public static object[] AddPatientData()
        {
            object[] main = ExcelUtils.GetSheetIntoTwoDimObjectArray
                (@"C:\Users\Tony\Desktop\Soller.edu\Soller.edu_2\Selenium Testing\OpenEmrApplication\TestData\OpenEMRData.xlsx", 
                "AddPatientTest");
            return main;
        }
    }
}
