using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Task_Payroll.Models.Dto
{
    public class PayrollDto
    {
        public string EmployeeName { get; set; }
        public string ActiveStatus { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PayDate { get; set; }
        public string RegularHours { get; set; }
        public string OvertimeHours { get; set; }
        public string RegularRate { get; set; }
        public string OvertimeRate { get; set; }
        public string GrossPay { get; set; }
        public string NetPay { get; set; }
        public string Medicare { get; set; }
        public string Rent { get; set; }
        public string Food { get; set; }
    }

}
