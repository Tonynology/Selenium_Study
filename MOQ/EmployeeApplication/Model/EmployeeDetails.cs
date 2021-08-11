using EmployeeApplication.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployeeApplication.Model
{
    public class EmployeeDetails : IEmployeeDetails
    {
        public string CompanyName { get; set; } = "Sollers";
        public int UniqueCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetEmployeeCompleteDetail(int empId)
        {
            
        }

        public string GetEmployeeName(int empId)
        {
            var emps = new EmployeeEntity().employees.Where(e => e.EmpId == empId);
            var emp = emps.SingleOrDefault();
            return emp.Name;
        }

        public String GetEmployeeRole(int empId)
        {
            var emps = new EmployeeEntity().employees.Where(e => e.EmpId == empId);
            var emp = emps.SingleOrDefault();
            return emp.Role;
        }

        public double GetEmployeeSalary(int empId)
        {
            var emps = new EmployeeEntity().employees.Where(e => e.EmpId == empId);
            var emp = emps.SingleOrDefault();
            return emp.Salary;
        }
    }
}
