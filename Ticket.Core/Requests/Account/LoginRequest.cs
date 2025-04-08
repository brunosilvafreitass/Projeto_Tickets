using System.ComponentModel.DataAnnotations;

namespace Ticket.Core.Requests.Account;

public class LoginRequest : BaseRequest
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = string.Empty;
}
