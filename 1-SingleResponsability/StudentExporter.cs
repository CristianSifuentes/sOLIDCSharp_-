namespace SingleResponsability
{
    public sealed record ExportResult(string FilePath, int StudentCount);

    // SRP step 7:
    // StudentExporter owns the application use case: "export the current students".
    // It coordinates specialized objects, but it does not steal their responsibilities.
    public sealed class StudentExporter
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStudentReportFormatter formatter;
        private readonly ITextFileWriter fileWriter;

        public StudentExporter(
            IStudentRepository studentRepository,
            IStudentReportFormatter formatter,
            ITextFileWriter fileWriter)
        {
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            this.formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            this.fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        }

        public ExportResult Export(string fileName)
        {
            List<Student> students = studentRepository.GetAll().ToList();
            string report = formatter.Format(students);
            string filePath = fileWriter.Write(fileName, report);

            return new ExportResult(filePath, students.Count);
        }
    }
}
