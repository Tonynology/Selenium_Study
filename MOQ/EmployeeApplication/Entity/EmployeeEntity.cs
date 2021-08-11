using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplication.Entity
{
    public class EmployeeEntity
    {
        public List<Employee> employees = new List<Employee>()
        {
            new Employee(){Name="John", EmpId=1, Salary=2000, Role="Senior Executive"},
            new Employee(){Name="Peter", EmpId=2, Salary=5000, Role="PM"},
            new Employee(){Name="Mark", EmpId=3, Salary=4000, Role="TL"}
        };
    }
}
