using System.Globalization;

namespace ClassLibrary;
public static class TvUtilities
{
    private static readonly Random RandomScore = new Random();
    public static Episode[] LoadEpisodesFromFile(string fileName)
    {
        string[] episodeInputs = File.ReadAllLines(fileName);

        Episode[] episodes = new Episode[episodeInputs.Length];
        
        for (int i = 0; i < episodes.Length; i++)
        {
            episodes[i] = Parse(episodeInputs[i]);
        }

        return episodes;
    }

    private static Episode Parse(string episodeInput)
    {
        string[] episodeInputParts = episodeInput.Split(',');

        return new Episode(
            int.Parse(episodeInputParts[0]),
            double.Parse(episodeInputParts[1], CultureInfo.InvariantCulture),
            double.Parse(episodeInputParts[2], CultureInfo.InvariantCulture),
            new Description(
                int.Parse(episodeInputParts[3]),
                TimeSpan.TryParseExact(episodeInputParts[4], @"hh\:mm\:ss", CultureInfo.InvariantCulture, out TimeSpan timeSpan) ? timeSpan : TimeSpan.FromMinutes(int.Parse(episodeInputParts[4])), 
                episodeInputParts[5]
                )
            );
    }

    public static void Sort(Episode[] episodes)
    {
        for (int i = 0; i < episodes.Length - 1; i++)
        {
            int maxIndex = i;
            
            for (int j = i + 1; j < episodes.Length; j++)
            {
                if (episodes[j] > episodes[maxIndex])
                {
                    maxIndex = j;
                }
            }

            (episodes[maxIndex], episodes[i]) = (episodes[i], episodes[maxIndex]);
        }
    }

    public static double GenerateRandomScore()
    {
        return Math.Round(RandomScore.NextDouble() * 10, 2);
    }

}