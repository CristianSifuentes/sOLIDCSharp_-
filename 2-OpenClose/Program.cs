using OpenClose;

// OCP step 6:
// Program is the composition root for this small demo.
// It creates concrete employees, but the payroll process receives only Employee abstractions.
List<Employee> employees = new()
{
    new EmployeeFullTime("Pepito Pérez", 160),
    new EmployeePartTime("Manuel Lopera", 180),

    // OCP demonstration:
    // ContractorEmployee was added as a new feature without changing EmployeeFullTime,
    // EmployeePartTime, or PayrollReportPrinter.
    new ContractorEmployee("Ana Contreras", 120)
};

PayrollReportPrinter printer = new();
printer.PrintMonthlyPayroll(employees);
