public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // speed in mph
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // pace in min/mile
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {GetDistance()} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}