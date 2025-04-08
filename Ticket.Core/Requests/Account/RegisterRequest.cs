using System.ComponentModel.DataAnnotations;

namespace Ticket.Core.Requests.Account;

public class RegisterRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters long.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

}
