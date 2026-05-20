namespace SingleResponsability
{
    // SRP step 4:
    // Demo data is a separate reason to change.
    // If tomorrow we want 100 students, random students, or production data,
    // the repository and exporter should not be edited.
    public static class StudentSeedData
    {
        public static void LoadInto(FakeStorage<Student> storage)
        {
            ArgumentNullException.ThrowIfNull(storage);

            storage.Add(new Student(1, "Pepito Pérez", new[] { 3.0, 4.5 }));
            storage.Add(new Student(2, "Mariana Lopera", new[] { 4.0, 5.0 }));
            storage.Add(new Student(3, "José Molina", new[] { 2.0, 3.0 }));
        }
    }
}
