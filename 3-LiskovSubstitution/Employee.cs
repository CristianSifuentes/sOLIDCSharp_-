namespace Liskov
{
    // LSP step 1:
    // Employee is the base contract that every employee subtype must be able to honor.
    // The contract contains only concepts that are true for all employees:
    // identity, worked hours, contract type, and salary calculation.
    //
    // This is the scientific core of LSP:
    // any Employee reference must be replaceable by EmployeeFullTime or EmployeeContractor
    // without changing the correctness of the payroll algorithm.
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

        // LSP step 2:
        // Salary calculation is a valid promise for every employee subtype.
        // The caller does not pass flags and does not ask for concrete types.
        public abstract decimal CalculateSalary();
    }
}
