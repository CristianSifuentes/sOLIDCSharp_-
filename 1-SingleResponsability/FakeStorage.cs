namespace SingleResponsability
{
    // SRP step 2:
    // FakeStorage simulates a persistence mechanism.
    // It is generic on purpose: it stores items, but it does not understand students,
    // CSV, console messages, or application workflows.
    public sealed class FakeStorage<T>
    {
        private readonly List<T> items;

        public FakeStorage()
        {
            items = new List<T>();
        }

        public T Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            items.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            items.Remove(item);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            // Returning a copy protects the storage boundary.
            // Callers can read the data without accidentally mutating our internal list.
            return items.ToList();
        }
    }
}
