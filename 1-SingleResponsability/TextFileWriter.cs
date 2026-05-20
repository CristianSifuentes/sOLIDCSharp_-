using System.Text;

namespace SingleResponsability
{
    public interface ITextFileWriter
    {
        string Write(string fileName, string content);
    }

    // SRP step 6:
    // File writing is infrastructure.
    // Encoding, base path, and disk APIs belong here, not in repository or formatting classes.
    public sealed class TextFileWriter : ITextFileWriter
    {
        private readonly string basePath;
        private readonly Encoding encoding;

        public TextFileWriter(string basePath, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(basePath))
            {
                throw new ArgumentException("A base path is required.", nameof(basePath));
            }

            this.basePath = basePath;
            this.encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public string Write(string fileName, string content)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("A file name is required.", nameof(fileName));
            }

            ArgumentNullException.ThrowIfNull(content);

            string fullPath = Path.Combine(basePath, fileName);
            File.WriteAllText(fullPath, content, encoding);

            return fullPath;
        }
    }
}
