namespace ActionWrapper;

public class ActionWrapper
{
    private readonly Action _action;

    public ActionWrapper(Action action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
    }

    public void Execute()
    {
        _action();
    }
}
