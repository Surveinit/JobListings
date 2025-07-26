using Microsoft.AspNetCore.Identity;

namespace JobListings.Models;

public class ApplicationUser : IdentityUser
{
    // Fields
    public string CompanyName { get; set; }
    public int EstablishmentYear { get; set; }
}