using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Task_Payroll.Models;

namespace Week2Task_Payroll.Logic.interfaces
{
    public interface IEmployeeLogic
    {
        string AddEmployee(Employee employee);
        Employee GetEmployee(string Id);

        List<Employee> GetEmployees();

        bool DeleteEmployee(string Id);
    }
}
