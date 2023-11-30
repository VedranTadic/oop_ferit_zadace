namespace ClassLibrary;

public class Description
{
    private int _number;
    private TimeSpan _duration;
    private string _title;

    public Description()
    {
        _number = 0;
        _duration = new TimeSpan();
        _title = "Not specified";
    }

    public Description(int number, TimeSpan duration, string title)
    {
        _number = number;
        _duration = duration;
        _title = title;
    }

    public override string ToString()
    {
        return $"Episode: {_number}, Duration: {_duration}, Title: {_title}";
    }

    public void SetNumber(int number) => _number = number;
    public void SetDuration(TimeSpan duration) => _duration = duration;
    public void SetTitle(string title) => _title = title;
}