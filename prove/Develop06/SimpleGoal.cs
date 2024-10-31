public class SimpleGoal : Goal
{
    private bool _isComplete;

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
    }
}