using SingleResponsability;
using System.Text;

// Composition root:
// Program is the one place where we wire the small responsibilities together.
// This keeps the domain classes clean and makes each part easy to replace in tests or demos.
FakeStorage<Student> storage = new();
StudentSeedData.LoadInto(storage);

IStudentRepository studentRepository = new StudentRepository(storage);
IStudentReportFormatter formatter = new StudentCsvFormatter();
ITextFileWriter fileWriter = new TextFileWriter(AppDomain.CurrentDomain.BaseDirectory, Encoding.Unicode);

StudentExporter exporter = new(studentRepository, formatter, fileWriter);
ExportResult result = exporter.Export("Students.csv");

Console.WriteLine("Single Responsibility Principle demonstration");
Console.WriteLine($"Students exported: {result.StudentCount}");
Console.WriteLine($"File created at: {result.FilePath}");
Console.WriteLine("Each class now has one clear reason to change.");
