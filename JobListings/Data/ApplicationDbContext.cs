using Microsoft.EntityFrameworkCore;
using JobListings.Models;
namespace JobListings.Data;

public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {
   } 
   
   public DbSet<JobListing> JobListings { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<JobListing>().Property(j => j.Salary).HasColumnType("decimal(18,2)");
      
      // Seed Data
      modelBuilder.Entity<JobListing>().HasData(
          new JobListing
          {
            Id = 1,
            Title = "Software Development",
            Company = "Toyota",
            Location = "Osaka, Japan",
            Description = "Develop Robust web application using ASP.NET Core MVC",
            Salary = 5794140,
            PostedDate = DateTime.Now.AddDays(-5),
            JobType = "Full-time",
            IsActive = true
          },
          new JobListing
          {
              Id = 2,
              Title = "C# Development",
              Company = "Honda",
              Location = "Tokyo, Japan",
              Description = "Develop Robust low level systems using C#",
              Salary = 4282500,
              PostedDate = DateTime.Now.AddDays(-3),
              JobType = "Full-time",
              IsActive = true   
          }
      );
   }
   
}