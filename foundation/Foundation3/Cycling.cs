public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (GetSpeed() * Minutes) / 60; // distance in miles
    }

    public override double GetSpeed()
    {
        return _speed; // speed in mph
    }

    public override double GetPace()
    {
        return 60 / GetSpeed(); // pace in min/mile
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}