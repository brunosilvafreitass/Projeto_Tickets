using System;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Ticket.Core.Responses;

public class BaseResponse<TData>
{
    private readonly int _statusCode;

    [JsonConstructor]
    public BaseResponse() => _statusCode = Configuration.DefaultStatusCode;
    public BaseResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        _statusCode = code;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSucess => _statusCode is >= 200 and <= 299;
}
