namespace OpenClose
{
    // OCP step 1:
    // Employee is the stable abstraction. It captures what all employees share:
    // identity, worked hours, contract type, and the ability to calculate salary.
    //
    // The system is "closed" around this contract: payroll code can depend on Employee
    // without asking which concrete employee type it received.
    public abstract class Employee
    {
        protected Employee(string fullname, int hoursWorked)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                throw new ArgumentException("An employee must have a fullname.", nameof(fullname));
            }

            if (hoursWorked < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hoursWorked), "Worked hours cannot be negative.");
            }

            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public string Fullname { get; }
        public int HoursWorked { get; }
        public abstract string ContractType { get; }

        // The open extension point:
        // every new employee type supplies its own salary algorithm here.
        public abstract decimal CalculateSalary();
    }
}
