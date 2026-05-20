namespace OpenClose
{
    // OCP step 5:
    // PayrollReportPrinter is closed for modification with respect to employee types.
    // It does not contain if/switch/type checks for FullTime, PartTime, or Contractor.
    // Polymorphism selects the correct salary formula at runtime.
    public sealed class PayrollReportPrinter
    {
        public void PrintMonthlyPayroll(IEnumerable<Employee> employees)
        {
            ArgumentNullException.ThrowIfNull(employees);

            Console.WriteLine("Open/Closed Principle payroll demonstration");
            Console.WriteLine("--------------------------------------------");

            foreach (Employee employee in employees)
            {
                decimal salary = employee.CalculateSalary();

                Console.WriteLine(
                    $"Employee: {employee.Fullname} | Contract: {employee.ContractType} | Hours: {employee.HoursWorked} | Salary: {salary:C1}");
            }
        }
    }
}
