using System.Text.Json;

namespace Hangfire.RecurringJobs.Extensions;

public static class DynamicRecurringJob
{

    public delegate void DynamicAction(string? stateSerialized);
    private static DynamicAction? Action { get; set; }

    public static void SetAction(DynamicAction action)
    {
        if (Action == null)
        {
            Action = action;
        }
    }

    public static void AddOrUpdate(string recurringJobId, string cronExpression, object? state = null, JsonSerializerOptions? serializerOptions = null)
    {
        string objectJson = JsonSerializer.Serialize(state, serializerOptions);
        RecurringJob.AddOrUpdate(recurringJobId, () => DynamicExecution(objectJson), cronExpression);
    }

    private static void DynamicExecution(string? stateSerialized = null)
    {
        
        Action?.Invoke(stateSerialized);
    }
}

