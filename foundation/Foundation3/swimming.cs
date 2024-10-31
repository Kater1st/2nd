public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // distance in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // speed in kph
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // pace in min/km
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}