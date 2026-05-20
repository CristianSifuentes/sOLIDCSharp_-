namespace Liskov
{
    // LSP step 5:
    // A contractor is an Employee, but not an overtime-eligible employee.
    // The class does not inherit fake overtime state and does not throw NotImplementedException.
    // That honesty is what makes substitution reliable.
    public sealed class EmployeeContractor : Employee
    {
        private const decimal HourValue = 40M;

        public EmployeeContractor(string fullname, int hoursWorked)
            : base(fullname, hoursWorked)
        {
        }

        public override string ContractType => "Contractor";

        public override decimal CalculateSalary()
        {
            return HourValue * HoursWorked;
        }
    }
}
