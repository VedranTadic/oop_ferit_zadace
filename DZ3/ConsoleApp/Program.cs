using System;
using System.IO;
using ClassLibrary;

namespace ConsoleApp;

public class Program
{
    public static void Main()
    {
        const string fileName = "shows.tv";
        const string outputFileName = "storage.tv";

        IPrinter printer = new ConsolePrinter();
	
        printer.Print($"Reading data from file {fileName}");
        Episode[] episodes = TvUtilities.LoadEpisodesFromFile(fileName);
        
        Season season = new Season(1, episodes);
        
        printer.Print($"Good season? Total viewers: {season.GetTotalViewers()}");
        printer.Print($"Watch whole season? Ends at: {season.GetBingeEnd()}");
        
        printer.Print(season.ToString());
        
        for (int i = 0; i < season.Length; i++)
        {
            season[i].AddView(TvUtilities.GenerateRandomScore());
        }
        printer.Print(season.ToString());
        
        printer = new FilePrinter(outputFileName);
        printer.Print(season.ToString());
    }
}