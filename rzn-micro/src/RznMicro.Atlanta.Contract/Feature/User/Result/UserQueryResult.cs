using RznMicro.Atlanta.Enumerable;
using System.Text.Json.Serialization;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public record UserQueryResult
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("dateBirth")]
    public DateTime DateBirth { get; set; }

    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("gender")]
    public GenderEnum? Gender { get; set; }
}
