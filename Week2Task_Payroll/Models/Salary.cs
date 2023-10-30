using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Task_Payroll.Models
{
    public class Salary : BaseEntity
    {
        public string EmployeeId { get; set; }
        public decimal PayDay { get; set; }
        public int RegularHour { get; set; }
        public int OvertimeHour { get; set; }
        public decimal RegularRate { get; set; }
        public decimal OvertimeRate { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal MedicareDeduction { get; set; }
        public decimal RentDeduction { get; set; }
        public decimal FoodDeduction { get; set; }

    }
}
