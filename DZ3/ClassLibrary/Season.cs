using System.Globalization;
using System.Text;

namespace ClassLibrary;

public class Season
{
    private int _number;
    private Episode[] _episodes;
    
    public Season(int number, Episode[] episodes)
    {
        _number = number;
        _episodes = new Episode[episodes.Length];
        for (int i = 0; i < episodes.Length; i++)
        {
            _episodes[i] = episodes[i];
        }
    }
    
    public int Length => _episodes.Length;

    public Episode GetEpisode(int index)
    {
        return _episodes[index];
    }

    public void SetEpisode(Episode episode, int index)
    {
        _episodes[index] = episode;
    }

    public int GetTotalViewers()
    {
        int totalViewers = 0;
        foreach (Episode episode in _episodes)
        {
            totalViewers += episode.GetViewerCount();
        }

        return totalViewers;
    }

    private TimeSpan GetTotalDuration()
    {
        TimeSpan total = TimeSpan.Zero;
        foreach (Episode episode in _episodes)
        {
            total += episode.GetDescription().GetDuration();
        }
        
        return total;
    }

    public DateTime GetBingeEnd()
    {
        return DateTime.Now.Add(GetTotalDuration());
    }


    public Episode this[int episodeIndex] => _episodes[episodeIndex];

    public override string ToString()
    {
        StringBuilder seasonOutput = new StringBuilder();
        seasonOutput.AppendLine($"Season {_number}");
        seasonOutput.AppendLine("=======================================================================================================================");
        foreach (Episode episode in _episodes)
        {
            seasonOutput.AppendLine($"{episode}");
        }
        seasonOutput.AppendLine("Report:");
        seasonOutput.AppendLine("=======================================================================================================================");
        seasonOutput.AppendLine($"TotalViewers: {GetTotalViewers()}");
        seasonOutput.AppendLine($"Total duration: {GetTotalDuration().ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}");
        seasonOutput.AppendLine("=======================================================================================================================");
        
        return seasonOutput.ToString();
    }
}