namespace OpenClose
{
    // OCP step 3:
    // A part-time employee extends the same contract, but owns a different salary rule.
    // Payroll orchestration does not need to know about the extra compensation formula.
    public sealed class EmployeePartTime : Employee
    {
        private const decimal HourValue = 20000M;
        private const int StandardMonthlyHours = 160;
        private const decimal EffortCompensationPerExtraHour = 5000M;

        public EmployeePartTime(string fullname, int hoursWorked)
            : base(fullname, hoursWorked)
        {
        }

        public override string ContractType => "Part time";

        public override decimal CalculateSalary()
        {
            decimal salary = HourValue * HoursWorked;

            if (HoursWorked > StandardMonthlyHours)
            {
                int extraHours = HoursWorked - StandardMonthlyHours;
                salary += EffortCompensationPerExtraHour * extraHours;
            }

            return salary;
        }
    }
}
