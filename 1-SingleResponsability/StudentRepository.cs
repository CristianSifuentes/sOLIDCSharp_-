namespace SingleResponsability
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }

    // SRP step 3:
    // StudentRepository is the student-specific access point.
    // Its single job is to answer student data requests by delegating persistence details
    // to FakeStorage<Student>. It no longer formats CSV or writes files.
    public sealed class StudentRepository : IStudentRepository
    {
        private readonly FakeStorage<Student> storage;

        public StudentRepository(FakeStorage<Student> storage)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public IEnumerable<Student> GetAll()
        {
            return storage.GetAll();
        }
    }
}
