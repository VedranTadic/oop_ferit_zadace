using System;
using System.IO;

namespace ClassLibrary;

public class ConsolePrinter : IPrinter
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}