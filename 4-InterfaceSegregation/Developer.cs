namespace InterfaceSegregation
{
    // ISP step 3:
    // Developer implements only the capabilities it actually owns.
    // There are no fake Test, Plan, or Design methods throwing exceptions.
    public sealed class Developer : IDevelopActivities
    {
        public void Develop()
        {
            Console.WriteLine("Developer: I build the requested functionality.");
        }
    }
}
