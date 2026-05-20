namespace OpenClose
{
    // OCP step 4:
    // This is a new requirement implemented by adding code, not rewriting existing code.
    // A contractor has a different hourly value, but still satisfies the Employee contract.
    public sealed class ContractorEmployee : Employee
    {
        private const decimal HourValue = 45000M;
        private const decimal RiskAndToolsAllowance = 150000M;

        public ContractorEmployee(string fullname, int hoursWorked)
            : base(fullname, hoursWorked)
        {
        }

        public override string ContractType => "Contractor";

        public override decimal CalculateSalary()
        {
            return (HourValue * HoursWorked) + RiskAndToolsAllowance;
        }
    }
}
