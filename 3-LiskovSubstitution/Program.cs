using Liskov;

// LSP step 7:
// Program composes the demo with different concrete employees.
// The payroll workflow below receives only Employee references, proving that subtypes
// can be substituted without special flags, casts, or type-check conditionals.
List<Employee> employees = new()
{
    new EmployeeFullTime("Pepito Pérez", 160, 10),
    new EmployeeContractor("Manuel Lopera", 180)
};

PayrollReportPrinter printer = new();
printer.PrintMonthlyPayroll(employees);
