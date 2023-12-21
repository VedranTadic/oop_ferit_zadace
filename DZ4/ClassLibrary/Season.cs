using System.Collections;
using System.Text;

namespace ClassLibrary;

public class Season : IEnumerable<Episode>
{
    private readonly int _number;
    private readonly List<Episode> _episodes;

    public Season(int number, List<Episode> episodes)
    {
        _number = number;
        _episodes = new List<Episode>();
        
        foreach (Episode episode in episodes) 
            _episodes.Add(new Episode(episode));
    }

    public Season(Season seasonCopy)
    {
        _number = seasonCopy._number;
        _episodes = new List<Episode>();
        
        foreach (Episode episodeCopy in seasonCopy._episodes) 
            _episodes.Add(new Episode(episodeCopy));
    }
    
    public IEnumerator<Episode> GetEnumerator()
    {
        return _episodes.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

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
            totalViewers += episode.GetViewerCount();

        return totalViewers;
    }

    private TimeSpan GetTotalDuration()
    {
        TimeSpan total = TimeSpan.Zero;
        foreach (Episode episode in _episodes) 
            total += episode.GetDescription().GetDuration();

        return total;
    }

    public DateTime GetBingeEnd()
    {
        return DateTime.Now.Add(GetTotalDuration());
    }

    public void Add(Episode episode)
    {
        _episodes.Add(episode);
    }

    public void Remove(string title)
    {
        for (int i = 0; i < _episodes.Count; i++)
            if (_episodes[i].GetDescription().GetTitle() == title)
            {
                _episodes.RemoveAt(i);
                return;
            }

        throw new TvException("No such episode found.", title);
    }

    public Episode this[int episodeIndex] => _episodes[episodeIndex];
    public override string ToString()
    {
        StringBuilder seasonOutput = new StringBuilder();
        seasonOutput.AppendLine($"Season {_number}");
        seasonOutput.AppendLine(
            "=======================================================================================================================");
        foreach (Episode episode in _episodes) 
            seasonOutput.AppendLine($"{episode}");
        seasonOutput.AppendLine("Report:");
        seasonOutput.AppendLine(
            "=======================================================================================================================");
        seasonOutput.AppendLine($"TotalViewers: {GetTotalViewers()}");
        seasonOutput.AppendLine($"Total duration: {GetTotalDuration()}");
        seasonOutput.AppendLine(
            "=======================================================================================================================");

        return seasonOutput.ToString();
    }
}