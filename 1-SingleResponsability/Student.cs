namespace SingleResponsability
{
    // SRP step 1:
    // Student represents the business concept "student".
    // It does not know where it is stored, how it is exported, or which file format is used.
    // Its only reason to change should be a change in the student data model itself.
    public sealed class Student
    {
        public int Id { get; }
        public string Fullname { get; }
        public IReadOnlyList<double> Grades { get; }

        public Student(int id, string fullname, IEnumerable<double> grades)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                throw new ArgumentException("A student must have a fullname.", nameof(fullname));
            }

            ArgumentNullException.ThrowIfNull(grades);

            Id = id;
            Fullname = fullname;
            Grades = grades.ToList().AsReadOnly();
        }
    }
}
