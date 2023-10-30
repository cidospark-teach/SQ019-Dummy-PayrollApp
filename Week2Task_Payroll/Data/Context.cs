using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Task_Payroll.Models;

namespace Week2Task_Payroll.Data
{
    public class Context
    {
        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public IList<Salary> Salaries { get; set; } = new List<Salary>();
    }
}
