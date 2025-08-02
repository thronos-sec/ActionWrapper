namespace ActionWrapper;

public static class ActionWrapper
{
    public static Action? Action { get; set; }

    public static void Execute()
    {
        Action?.Invoke();
    }
}
