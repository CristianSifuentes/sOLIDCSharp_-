using System.Text;

namespace SingleResponsability
{
    public interface IStudentReportFormatter
    {
        string Format(IEnumerable<Student> students);
    }

    // SRP step 5:
    // Formatting is its own responsibility because presentation rules change independently.
    // Examples: CSV delimiter changes, columns are renamed, average grade is added, JSON is required.
    public sealed class StudentCsvFormatter : IStudentReportFormatter
    {
        public string Format(IEnumerable<Student> students)
        {
            ArgumentNullException.ThrowIfNull(students);

            StringBuilder csv = new();
            csv.AppendLine("Id;Fullname;Grades;Average");

            foreach (Student student in students)
            {
                csv.AppendLine(
                    string.Join(
                        ";",
                        student.Id,
                        Escape(student.Fullname),
                        string.Join("|", student.Grades),
                        student.Grades.Average().ToString("0.00")));
            }

            return csv.ToString();
        }

        private static string Escape(string value)
        {
            // CSV has a tiny but important rule: values containing separators or quotes must be quoted.
            // Keeping that rule here prevents file storage and repository code from learning CSV details.
            if (!value.Contains(';') && !value.Contains('"') && !value.Contains(Environment.NewLine))
            {
                return value;
            }

            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
    }
}
