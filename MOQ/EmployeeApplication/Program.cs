using EmployeeApplication.Model;
using System;

namespace EmployeeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var ed = new EmployeeDetails();
            String name = ed.GetEmployeeName(2);
            Console.WriteLine(name);

            var pf = new EmployeePFDetails(new EmployeeDetails());  //dependency injection

            pf.GetEmployerContribution(2);
        }
    }
}
