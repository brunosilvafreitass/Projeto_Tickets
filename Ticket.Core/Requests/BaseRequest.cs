using System.Text.Json.Serialization;

namespace Ticket.Core.Requests;

public abstract class BaseRequest
{
    [JsonIgnore]
    public string UserId { get; set; } = string.Empty;
}
