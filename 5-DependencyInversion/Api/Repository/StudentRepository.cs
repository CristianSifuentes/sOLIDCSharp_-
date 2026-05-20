using System.Collections.ObjectModel;

namespace DependencyInversion
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        void Add(Student student);
    }

    // DIP step 2:
    // StudentRepository is a low-level data component.
    // The controller does not need to know this concrete class exists; it only needs
    // an object that satisfies IStudentRepository.
    public sealed class StudentRepository : IStudentRepository
    {
        private static ObservableCollection<Student>? collection;

        public StudentRepository()
        {
            InitData();
        }

        private void InitData()
        {
            if (collection is null)
            {
                collection = new();
                collection.Add(new Student(1, "Pepito Pérez", new List<double>() { 3, 4.5 }));
                collection.Add(new Student(2, "Mariana Lopera", new List<double>() { 4, 5 }));
                collection.Add(new Student(3, "José Molina", new List<double>() { 2, 3 }));
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return collection ?? Enumerable.Empty<Student>();
        }

        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);

            InitData();
            collection!.Add(student);
        }
    }
}
