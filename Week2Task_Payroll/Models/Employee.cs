using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Task_Payroll.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Status { get; set; }

    }
}
