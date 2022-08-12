using System.Runtime.Serialization;

namespace ToDoApp.Data;

public class DbDeleteException: Exception
{
    public DbDeleteException()
    {
    }

    protected DbDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DbDeleteException(string? message) : base(message)
    {
    }

    public DbDeleteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}