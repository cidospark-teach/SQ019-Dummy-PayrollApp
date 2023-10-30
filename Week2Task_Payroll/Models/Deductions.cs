using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Task_Payroll.Models
{
    public static class Deductions
    {
        public static Dictionary<string, int> DeductionSchemes = 
            new Dictionary<string, int>
            {
                { "medicare", 2 },
                { "rent", 5 },
                { "food", 3 },
            };      
    }
}
