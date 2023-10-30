using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Task_Payroll.Data;
using Week2Task_Payroll.Logic;
using Week2Task_Payroll.Logic.interfaces;

namespace Week2Task_Payroll
{
    public static class GlobalConfig
    {
        public static IPayrollLogic _payrollLogic;
        public static IEmployeeLogic _employeeLogic;

        public static void Initiate()
        {
            var ctx = new Context();
            _payrollLogic = new PayrollLogic(ctx);
            _employeeLogic = new EmployeeLogic(ctx);
        }
    }
}
