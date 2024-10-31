public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;

    public ChecklistGoal(int target)
    {
        _target = target;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_target},{_amountCompleted}";
    }
}