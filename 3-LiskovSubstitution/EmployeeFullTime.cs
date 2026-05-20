namespace Liskov
{
    // LSP step 3:
    // Overtime is not part of the base Employee contract because not every employee has it.
    // This capability is modeled separately so only valid subtypes implement it.
    public interface IOvertimeEligible
    {
        int ExtraHours { get; }
        decimal CalculateOvertimePay();
    }

    // LSP step 4:
    // EmployeeFullTime can replace Employee because it honors the base contract completely.
    // It also adds a valid extra capability: overtime eligibility.
    public sealed class EmployeeFullTime : Employee, IOvertimeEligible
    {
        private const decimal HourValue = 50M;
        private const decimal OvertimeHourValue = 75M;

        public EmployeeFullTime(string fullname, int hoursWorked, int extraHours)
            : base(fullname, hoursWorked)
        {
            if (extraHours < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(extraHours), "Extra hours cannot be negative.");
            }

            ExtraHours = extraHours;
        }

        public override string ContractType => "Full time";
        public int ExtraHours { get; }

        public override decimal CalculateSalary()
        {
            return (HourValue * HoursWorked) + CalculateOvertimePay();
        }

        public decimal CalculateOvertimePay()
        {
            return OvertimeHourValue * ExtraHours;
        }
    }
}
