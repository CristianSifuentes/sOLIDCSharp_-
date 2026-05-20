namespace InterfaceSegregation
{
    // ISP step 6:
    // This role demonstrates interface composition.
    // A SoftwareArchitect genuinely participates in planning, design, development guidance,
    // and testing strategy, so implementing the composed interface is honest here.
    public sealed class SoftwareArchitect : IActivitiesComplete
    {
        public void Plan()
        {
            Console.WriteLine("Architect: I align technical decisions with business goals.");
        }

        public void Communicate()
        {
            Console.WriteLine("Architect: I translate architecture trade-offs for the team.");
        }

        public void Design()
        {
            Console.WriteLine("Architect: I design the system boundaries and integration strategy.");
        }

        public void Develop()
        {
            Console.WriteLine("Architect: I build reference implementations for complex decisions.");
        }

        public void Test()
        {
            Console.WriteLine("Architect: I define quality attributes and validation strategy.");
        }
    }
}
