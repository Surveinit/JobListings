using Microsoft.EntityFrameworkCore;
using JobListings.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobListings.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {
   } 
   
   public DbSet<JobListing> JobListings { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       base.OnModelCreating(modelBuilder);
       modelBuilder.Entity<JobListing>()
           .HasOne(j => j.Company)
           .WithMany(c => c.JobListings)
           .HasForeignKey(j => j.CompanyId)
           .OnDelete(DeleteBehavior.Cascade);
           // .Property(j => j.Salary)
           // .HasColumnType("decimal(18,2)");
      
      // Seed Data
      modelBuilder.Entity<JobListing>().HasData(
          new JobListing
          {
            Id = 1,
            Title = "Software Development",
            Location = "Osaka, Japan",
            Description = "Develop Robust web application using ASP.NET Core MVC",
            Salary = 5794140,
            PostedDate = new DateTime(2025, 7, 15),
            JobType = "Full-time",
            IsActive = true
          },
          new JobListing
          {
              Id = 2,
              Title = "C# Development",
              Location = "Tokyo, Japan",
              Description = "Develop Robust low level systems using C#",
              Salary = 4282500,
              PostedDate = new DateTime(2026, 8, 8),
              JobType = "Full-time",
              IsActive = true   
          }
      );
   }
   
}