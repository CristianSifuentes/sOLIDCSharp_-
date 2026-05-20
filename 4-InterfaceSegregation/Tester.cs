namespace InterfaceSegregation
{
    // ISP step 4:
    // Tester receives a testing contract instead of the whole activities catalog.
    // The role is now precise: it can test without pretending to develop.
    public sealed class Tester : ITestActivities
    {
        public void Test()
        {
            Console.WriteLine("Tester: I validate behavior, detect defects, and protect quality.");
        }
    }
}
