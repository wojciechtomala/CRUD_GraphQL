namespace dotNetGraphQL.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public int StudentId { get; internal set; }
    }
}
