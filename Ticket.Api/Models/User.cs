using System;
using Microsoft.AspNetCore.Identity;

namespace Ticket.Api.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
