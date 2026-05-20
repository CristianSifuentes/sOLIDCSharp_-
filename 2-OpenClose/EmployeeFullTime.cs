namespace OpenClose
{
    // OCP step 2:
    // A full-time employee is an extension of the Employee abstraction.
    // Its salary rule lives here, where the domain knowledge belongs.
    public sealed class EmployeeFullTime : Employee
    {
        private const decimal HourValue = 30000M;

        public EmployeeFullTime(string fullname, int hoursWorked)
            : base(fullname, hoursWorked)
        {
        }

        public override string ContractType => "Full time";

        public override decimal CalculateSalary()
        {
            return HourValue * HoursWorked;
        }
    }
}
