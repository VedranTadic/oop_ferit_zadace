using System.Runtime.Serialization;

namespace ClassLibrary;

public class TvException : Exception
{
    public string? Title { get; }
    
    public TvException()
    {
    }

    public TvException(string message) : base(message)
    {
    }

    public TvException(string message, string title = "Not specified") : base(message)
    {
        Title = title;
    }
}