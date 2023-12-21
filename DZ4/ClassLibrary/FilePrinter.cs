using System.IO;

namespace ClassLibrary;

public class FilePrinter : IPrinter
{
    private readonly string _outputFileName;

    public FilePrinter(string outputFileName)
    {
        _outputFileName = outputFileName;
    }

    public void Print(string message)
    {
        File.AppendAllText(_outputFileName, message);
    }
}