using Supabase.Postgrest.Models;

namespace Dashboard;

public class Prompt : BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// The name/key that will be used to know what is this prompt about and will be human readable for peopel to recognize it
    /// </summary>
    public string KeyName { get; set; } = string.Empty;
    /// <summary>
    /// The main content of the prompt that will be sent to the AI agent to receive the responses
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// A short description of what does the prompt do
    /// </summary>
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public class PromptKeys
{
    public const string GetDailyNews = "get_daily_news";
    public const string CreateNewIdea = "create_new_idea";
}