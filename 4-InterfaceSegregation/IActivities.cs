namespace InterfaceSegregation
{
    // ISP step 1:
    // The original IActivities interface was a "fat interface":
    // Plan, Comunicate, Design, Develop, and Test were forced onto every role.
    //
    // Interface Segregation says clients should depend only on the methods they use.
    // So we split the broad contract into small capability interfaces.

    public interface IWorkingActivities
    {
        void Plan();
        void Communicate();
    }

    public interface IDesignActivities
    {
        void Design();
    }

    public interface IDevelopActivities
    {
        void Develop();
    }

    public interface ITestActivities
    {
        void Test();
    }

    // ISP step 2:
    // This composed interface is optional.
    // It is useful for a future role that truly performs every activity, such as an architect
    // or technical lead. Existing roles are not forced to implement it.
    public interface IActivitiesComplete :
        IWorkingActivities,
        IDesignActivities,
        IDevelopActivities,
        ITestActivities
    {
    }
}
