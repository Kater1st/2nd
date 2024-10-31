public class EternalGoal : Goal
{
    private int _eventCount;

    public override void RecordEvent()
    {
        _eventCount++;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points},{_eventCount}";
    }
}