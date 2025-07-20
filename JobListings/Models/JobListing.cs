namespace JobListings.Models;
using System.ComponentModel.DataAnnotations;

public class JobListing
{
   [Key]
   public int JobListingId { get; set; }

   [Required] [StringLength(100)] public string Title { get; set; } = String.Empty;
   [Required] [StringLength(50)] public string Company { get; set; } = String.Empty;
   [Required] [StringLength(100)] public string Location { get; set; } = String.Empty;
   [Required] public string Description { get; set; } = String.Empty;
   [Required] [Range(0, Double.MaxValue)] public decimal Salary { get; set; }
   [Required] public DateTime PostedDate { get; set; } = DateTime.Now;
   [Required] [StringLength(50)] public string JobType { get; set; } = String.Empty;
   public bool IsActive { get; set; } = true;
}
