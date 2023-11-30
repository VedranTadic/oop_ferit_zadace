using System;
using System.IO;
using ClassLibrary;

namespace ConsoleApp;

public class Program
{
    public static void Main()
    {
        Description description = new Description(1, TimeSpan.FromMinutes(45), "Pilot");
        Console.WriteLine(description);
        
        Episode episode = new Episode(10, 88.64, 9.78, description);
        Console.WriteLine(episode);
        
        const string filename = "shows.tv";
        string[] episodeInputs = File.ReadAllLines(filename);
        
        Episode[] episodes = new Episode[episodeInputs.Length];
        
        for (int i = 0; i < episodes.Length; i++)
        {
            episodes[i] = TvUtilities.Parse(episodeInputs[i]);
        }
        
        Console.WriteLine("Episodes:");
        Console.WriteLine(string.Join<Episode>(Environment.NewLine, episodes));

        TvUtilities.Sort(episodes);
        
        Console.WriteLine("Sorted episodes:");
        string sortedEpisodesOutput = string.Join<Episode>(Environment.NewLine, episodes);
        Console.WriteLine(sortedEpisodesOutput);
        
        File.WriteAllText("sorted.tv",sortedEpisodesOutput);
    }
}