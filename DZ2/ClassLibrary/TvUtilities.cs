using System.Globalization;

namespace ClassLibrary;
public static class TvUtilities
{
    private static readonly Random RandomScore = new Random();
    public static Episode Parse(string episodeInput)
    {
        string[] episodeInputParts = episodeInput.Split(',');
        
        return new Episode(int.Parse(episodeInputParts[0]), double.Parse(episodeInputParts[1], CultureInfo.InvariantCulture), double.Parse(episodeInputParts[2],CultureInfo.InvariantCulture),
            new Description(int.Parse(episodeInputParts[3]), TimeSpan.Parse(episodeInputParts[4]), episodeInputParts[5]));
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
        return (double)Math.Round((decimal)RandomScore.NextDouble() * 10, 2);
    }
}