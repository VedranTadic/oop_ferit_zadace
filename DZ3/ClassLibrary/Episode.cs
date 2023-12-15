using System.Globalization;

namespace ClassLibrary;

public class Episode
{
    private double _maxScore;
    private double _totalScore;
    private int _viewerCount;
    private Description _description;

    public Episode()
    {
        _viewerCount = 0;
        _totalScore = 0;
        _maxScore = 0;
        _description = new Description();
    }

    public Episode(int viewerCount, double totalScore, double maxScore, Description description)
    {
        _viewerCount = viewerCount;
        _totalScore = totalScore;
        _maxScore = maxScore;
        _description = description;
    }
    
    public double GetMaxScore()
    {
        return _maxScore;
    }
    public int GetViewerCount()
    {
        return _viewerCount;
    }
    public Description GetDescription()
    {
        return _description;
    }
    
    public void AddView(double score)
    {
        _viewerCount++;
        _totalScore += score;
        if (score > _maxScore)
            _maxScore = score;
    }

    public double GetAverageScore()
    {
        return _totalScore / _viewerCount;
    }
    
    public override string ToString()
    {
        return $"Viewers: {_viewerCount}, Total score: {_totalScore.ToString("F2", CultureInfo.InvariantCulture)}, Maximum score: {_maxScore.ToString("F2", CultureInfo.InvariantCulture)}, {_description}";
    }
    
    public static bool operator <(Episode a, Episode b)
    {
        return a.GetAverageScore() < b.GetAverageScore();
    }
    
    public static bool operator >(Episode a, Episode b)
    {
        return a.GetAverageScore() > b.GetAverageScore();
    }
}