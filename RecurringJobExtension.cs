using System.Text.Json;

namespace Hangfire.RecurringJobs.Extensions;

public static class DynamicRecurringJob
{

    public delegate void DynamicAction(string destination, string? stateSerialized);
    private static DynamicAction? Action { get; set; }

    public static void SetAction(DynamicAction action)
    {
        if (Action == null)
        {
            Action = action;
        }
    }

    public static void AddOrUpdate(string recurringJobId, string cronExpression, string destination, object? state = null, JsonSerializerOptions? serializerOptions = null)
    {
        string objectJson = JsonSerializer.Serialize(state, serializerOptions);
        RecurringJob.AddOrUpdate(recurringJobId, () => DynamicExecution(destination, objectJson), cronExpression);
    }

    private static void DynamicExecution(string destination, string stateSerialized)
    {
        Action?.Invoke(destination, stateSerialized);
    }
}

