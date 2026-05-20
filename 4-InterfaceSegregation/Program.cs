using InterfaceSegregation;

// ISP step 7:
// Program acts as the composition root.
// Each workflow receives the narrowest interface that describes what it needs.
// That is the practical test for Interface Segregation.
IDevelopActivities developer = new Developer();
ITestActivities tester = new Tester();
IWorkingActivities scrumMaster = new ScrumMaster();

RunPlanning(scrumMaster);
RunDevelopment(developer);
RunQualityGate(tester);

static void RunPlanning(IWorkingActivities collaborator)
{
    collaborator.Plan();
    collaborator.Communicate();
}

static void RunDevelopment(IDevelopActivities developer)
{
    developer.Develop();
}

static void RunQualityGate(ITestActivities tester)
{
    tester.Test();
}
