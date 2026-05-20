using System.Text;

namespace DependencyInversion
{
    public interface ILogbook
    {
        void Add(string description);
    }

    // DIP step 3:
    // Logbook is a low-level component because it performs file I/O.
    // It implements ILogbook, so the API can depend on the logging contract instead
    // of depending on this concrete file-writing class.
    public sealed class Logbook : ILogbook
    {
        public void Add(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("A log description is required.", nameof(description));
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logbook.txt");
            File.AppendAllText(path, $"{DateTimeOffset.UtcNow:u} | {description}{Environment.NewLine}", Encoding.Unicode);
        }
    }
}
