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
    public class PayrollLogic : IPayrollLogic
    {
        private readonly Context _ctx;
        public PayrollLogic(Context ctx)
        {
            _ctx = ctx;
        }

        public string AddSalaray(Salary salary)
        {
            // calculate gross pay
            salary.GrossPay = this.CalculateGrossPay(salary.RegularRate, 
                                                     salary.OvertimeRate, 
                                                     salary.RegularHour, 
                                                     salary.OvertimeHour);
            // calculate deductions
            salary.MedicareDeduction = CalculateDeduction(Deductions.DeductionSchemes["medicare"], 
                                                          salary.GrossPay);
            salary.RentDeduction = CalculateDeduction(Deductions.DeductionSchemes["rent"],
                                                          salary.GrossPay);
            salary.FoodDeduction = CalculateDeduction(Deductions.DeductionSchemes["food"],
                                                          salary.GrossPay);

            decimal totalDeductions = salary.MedicareDeduction + salary.RentDeduction + salary.FoodDeduction;
            salary.NetPay = CalculateNet(salary.GrossPay, totalDeductions);

            _ctx.Salaries.Add(salary);
            return $"New deduction added. Id {salary.Id}";
        }

        public decimal CalculateDeduction(decimal percentage, decimal gross)
        {
            return (percentage / 100) * gross;
        }

        public decimal CalculateGrossPay(decimal regRate, decimal overtimeRate, int regHour, int overtimeHour)
        {
            var regularPay = regHour * regRate;
            var overtimePay = 0.0M;
            if(overtimeHour > 0)
            {
                overtimePay = overtimeHour* overtimeRate;

                regularPay += overtimePay;
            }

            return regularPay;
        }

        public decimal CalculateNet(decimal gross, decimal totalDeductions)
        {
            return gross - totalDeductions;
        }

        public bool DeleteSalary(string Id)
        {
            var salary = GetSalary(Id);
            if (salary == null)
                return false;

            _ctx.Salaries.Remove(salary);
            return true;
        }

        public List<Salary> GetSalaries()
        {
            return _ctx.Salaries.ToList();
        }

        public Salary GetSalary(string Id)
        {
            var salary = _ctx.Salaries.FirstOrDefault(x => x.Id == Id);

            return salary ?? null;
        }
    }
}
