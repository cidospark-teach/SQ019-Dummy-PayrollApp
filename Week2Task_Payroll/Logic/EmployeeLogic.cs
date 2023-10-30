using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Task_Payroll.Data;
using Week2Task_Payroll.Logic.interfaces;
using Week2Task_Payroll.Models;

namespace Week2Task_Payroll.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly Context _ctx;
        public EmployeeLogic(Context ctx)
        {
            _ctx = ctx;
        }

        public string AddEmployee(Employee employee)
        {
            _ctx.Employees.Add(employee);
            return $"New employee added. Id {employee.Id}";
        }

        public bool DeleteEmployee(string Id)
        {
            var emp = GetEmployee(Id);
            if (emp != null)
            {
                _ctx.Employees.Remove(emp);
                return true ;
            }
            return false ;
        }

        public Employee GetEmployee(string Id)
        {
            var emp = _ctx.Employees.FirstOrDefault(x => x.Id == Id);
            if(emp == null) 
                return null;

            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return _ctx.Employees.ToList();
        }
    }
}
