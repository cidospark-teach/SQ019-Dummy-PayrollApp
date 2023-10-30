// See https://aka.ms/new-console-template for more information
using Week2Task_Payroll;
using Week2Task_Payroll.Commons;
using Week2Task_Payroll.Models;
using Week2Task_Payroll.Models.Dto;

GlobalConfig.Initiate();

Console.WriteLine("Week 2 Task - Mini Payroll Project");
Console.WriteLine();

Console.WriteLine("Welcome!");

bool condition = true;
while(condition){
    Console.WriteLine();
    Console.WriteLine("What's employee's first name.");
    string fname = Console.ReadLine();
    Console.WriteLine("What's employee's last name.");
    string lname = Console.ReadLine();
    Console.WriteLine("What is employee's start date?.");
    string startDate = Console.ReadLine();
    Console.WriteLine("What is employee's end date?.");
    string endDate = Console.ReadLine();

    var emp = new Employee
    {
        FirstName = fname,
        LastName = lname,
        StartDate = startDate,
        EndDate = endDate,
        Status = true
    };
    var addEmpResult = GlobalConfig._employeeLogic.AddEmployee(emp);
    Console.WriteLine(addEmpResult);

    Console.WriteLine();
    Console.WriteLine($"Enter the following details for {emp.FirstName}");
    Console.Write("Regular hours: \t");
    var regHours = int.Parse(Console.ReadLine());
    Console.Write("Overtime hours: \t");
    var overtimeHour = int.Parse(Console.ReadLine());
    Console.Write("Regular rate: \t");
    var regRate = decimal.Parse(Console.ReadLine());
    Console.Write("Overtime rate: \t");
    var overtimeRate = decimal.Parse(Console.ReadLine());

    var salary = new Salary
    {
        EmployeeId = emp.Id,
        RegularHour = regHours,
        OvertimeHour = overtimeHour,
        RegularRate = regRate,
        OvertimeRate = overtimeRate
    };
    var addSalaryResult = GlobalConfig._payrollLogic.AddSalaray(salary);
    Console.WriteLine(addSalaryResult);

    Console.WriteLine("Do you wish to continue? Y/N");
    var ans = Console.ReadLine().ToUpper();
    if(ans.Equals("N"))
        condition = false;
}

Console.WriteLine();
Console.WriteLine("Would you like to print your payroll? Y/N");
var answer = Console.ReadLine().ToUpper();
if (answer.Equals("N"))
    Environment.Exit(0);

var employees = GlobalConfig._employeeLogic.GetEmployees();
var salaries = GlobalConfig._payrollLogic.GetSalaries();
var payrolls = employees.Join(salaries, x => x.Id, y => y.EmployeeId,(x, y) => new PayrollDto
{
    EmployeeName = $"{x.LastName} {x.FirstName}",
    ActiveStatus = x.Status.ToString(),
    StartDate = x.StartDate,
    EndDate = x.EndDate,
    PayDate = $"{y.PayDay}",
    RegularHours = y.RegularHour.ToString(),
    OvertimeHours = y.OvertimeHour.ToString(),
    RegularRate = y.RegularRate.ToString(),
    OvertimeRate = y.OvertimeRate.ToString(),
    GrossPay = y.GrossPay.ToString(),
    NetPay = y.NetPay.ToString(),
    Medicare = y.MedicareDeduction.ToString(),
    Rent = y.RentDeduction.ToString(),
    Food = y.FoodDeduction.ToString(),
});

Console.WriteLine();

var headers = new string[] { "Employee Name", "Status", "Start Date", "End Date", "Reg Hrs", "Overtime Hrs", 
    "Reg Rate", "Overtime Rate", "Gross", "Net", "Medicare", "Rent", "Food" };

Helper.PrintLine(Console.WindowWidth - 2);
Helper.PrintRow(Console.WindowWidth - 2, headers);
Helper.PrintLine(Console.WindowWidth - 2);
foreach(var row in payrolls)
{
    Helper.PrintRow(Console.WindowWidth - 2, row.EmployeeName, 
                                             row.ActiveStatus, 
                                             row.StartDate, 
                                             row.EndDate, 
                                             row.RegularHours, 
                                             row.OvertimeHours, 
                                             row.RegularRate, 
                                             row.OvertimeRate, 
                                             row.GrossPay, 
                                             row.NetPay,  
                                             row.Medicare, 
                                             row.Rent, 
                                             row.Food);
    Helper.PrintLine(Console.WindowWidth - 2);
}


Console.WriteLine();

