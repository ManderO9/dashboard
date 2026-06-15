using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Dashboard;

public class City : BaseModel
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

}
