using Ticket.Core.Requests.Account;
using Ticket.Core.Responses;

namespace Ticket.Core.Handlers;

public interface IAccountHandler
{
    Task<BaseResponse<string>> LoginAsync(LoginRequest request);
    Task<BaseResponse<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}
