using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplication.Model
{
    public class EmployeePFDetails
    {
        private IEmployeeDetails _empdetails;

        public EmployeePFDetails(IEmployeeDetails details)
        {
            this._empdetails = details;
        }

        public bool IsPFEligible(int empId)
        {
            if (_empdetails.GetEmployeeSalary(empId) > 2000)
                return true;
            else
                return false;
        }
        
        public double GetEmployerContribution(int empId)
        {
            double contribution = _empdetails.GetEmployeeSalary(empId) * .12;
            return contribution;
        }

        public string GetCompanyName()
        {
            return _empdetails.CompanyName;
        }

        public void PrintCompanyDetail()
        {
            Console.WriteLine("Company Name " + _empdetails.CompanyName + _empdetails.UniqueCode);
        }
    }
}
