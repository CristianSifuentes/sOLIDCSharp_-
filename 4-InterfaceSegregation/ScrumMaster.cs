namespace InterfaceSegregation
{
    // ISP step 5:
    // ScrumMaster coordinates work and communication.
    // The class is not forced to develop, test, or design because those are separate capabilities.
    public sealed class ScrumMaster : IWorkingActivities
    {
        public void Plan()
        {
            Console.WriteLine("Scrum Master: I plan user stories and help the team focus.");
        }

        public void Communicate()
        {
            Console.WriteLine("Scrum Master: I remove blockers and keep communication flowing.");
        }
    }
}
