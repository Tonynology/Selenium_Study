using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplication.Model
{
    public interface IEmployeeDetails
    {
        string GetEmployeeName(int empId);
        double GetEmployeeSalary(int empId);
        String GetEmployeeRole(int empId);
        void GetEmployeeCompleteDetail(int empId);

        String CompanyName { get; set; }

        int UniqueCode { get; set; }
    }
}
