namespace ContactManager.Exceptions
{
    public class CsvException : Exception
    {
        public CsvException() { }
        public CsvException(string message) : base(message) { }
    }
}
