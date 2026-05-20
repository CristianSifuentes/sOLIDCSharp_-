namespace Liskov
{
    // LSP step 6:
    // This class is the substitution test.
    // It uses the base Employee contract and trusts every subtype to behave correctly.
    // No "is EmployeeFullTime" checks are necessary for salary calculation.
    public sealed class PayrollReportPrinter
    {
        public void PrintMonthlyPayroll(IEnumerable<Employee> employees)
        {
            ArgumentNullException.ThrowIfNull(employees);

            Console.WriteLine("Liskov Substitution Principle payroll demonstration");
            Console.WriteLine("---------------------------------------------------");

            foreach (Employee employee in employees)
            {
                decimal salary = employee.CalculateSalary();

                Console.WriteLine(
                    $"Employee: {employee.Fullname} | Contract: {employee.ContractType} | Hours: {employee.HoursWorked} | Salary: {salary:C1}");

                // Optional capability check:
                // This does not protect salary calculation. It only prints extra information
                // when an employee truthfully supports overtime.
                if (employee is IOvertimeEligible overtimeEligible)
                {
                    Console.WriteLine(
                        $"  Overtime: {overtimeEligible.ExtraHours} hours | Pay: {overtimeEligible.CalculateOvertimePay():C1}");
                }
            }
        }
    }
}
