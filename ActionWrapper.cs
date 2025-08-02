namespace ActionWrapper;

public static class ActionWrapper
{
    private static Action? Action { get; set; }

    public static void Execute()
    {
        Action?.Invoke();
    }
}
