using Supabase.Postgrest.Models;

namespace Dashboard;

public class Idea : BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public Status Status { get; set; } = Status.New;
}

public enum Status
{
    New,
    Active,
    Completed,
    Cancelled,
}
