using JobListings.Data;
using JobListings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobListings.Controllers;

public class JobListingsController : Controller
{
   private readonly ApplicationDbContext _context;
   private readonly UserManager<ApplicationUser> _userManager;

   public JobListingsController(
      ApplicationDbContext context,
      UserManager<ApplicationUser> userManager
      )
   {
      _context = context;
      _userManager = userManager;
   }
   
   // GET: JobListings
   [AllowAnonymous]
   public async Task<IActionResult> Index()
   {
      var jobListings = await _context.JobListings
         .Where(j => j.IsActive)
         .OrderByDescending(j => j.PostedDate)
         .ToListAsync();
      
      return View(jobListings);
   }
   
   // GET: JobListings/Details/5
   [AllowAnonymous]
   public async Task<IActionResult> Details(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      var jobListing = await _context.JobListings
         .FirstOrDefaultAsync(m => m.Id == id);

      if (jobListing == null)
      {
         return NotFound();
      }
      
      return View(jobListing);
   }
   
   // GET: JobListings/Create
   [Authorize(Roles = "Company")]
   public IActionResult Create()
   {
      return View();
   }
   
   // POST: JobListings/Create
   [Authorize(Roles = "Company")]
   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Create(
      [Bind("Title, Location, Description, Salary, JobType")] JobListing jobListing)
   {
      var user = await _userManager.GetUserAsync(User);
      jobListing.CompanyId = user.Id;
      jobListing.PostedDate = DateTime.Now;
      jobListing.IsActive = true;
      
      if (ModelState.IsValid)
      {
         _context.Add(jobListing);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }
      return View(jobListing);
   }
   
   // GET: JobListings/Edit/2
   [Authorize(Roles = "Company")]
   public async Task<IActionResult> Edit(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      var jobListing = await _context.JobListings.FindAsync(id);
      if (jobListing == null)
      {
         return NotFound();
      }
      return View(jobListing);
   }
   
   // POST: JobListing/Edit/2
   [Authorize(Roles = "Company")]
   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Edit(int id,
      [Bind("Id, Title, Company, Location, Description, Salary, PostedDate, JobType, IsActive")] JobListing jobListing)
   {
      if (id != jobListing.Id)
      {
         return NotFound();
      }

      if (ModelState.IsValid)
      {
         try
         {
            _context.Update(jobListing);
            await _context.SaveChangesAsync();
         }
         catch(DbUpdateConcurrencyException)
         {
            if (!JobListingExists(jobListing.Id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return RedirectToAction(nameof(Index));
      }
      return View(jobListing);
   }
   
   // GET: JobListings/Delete/5
   [Authorize(Roles = "Company")]
   public async Task<IActionResult> Delete(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      var jobListing = await _context.JobListings.FirstOrDefaultAsync(m => m.Id == id);
      if (jobListing == null)
      {
         return NotFound();
      }
      return View(jobListing);
   }
   
   // POST: JobListings/Delete/5
   [Authorize(Roles = "Company")]
   [HttpPost, ActionName("Delete")]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> DeleteConfirmed(int id)
   {
      var jobListing = await _context.JobListings.FindAsync(id);
      if (jobListing != null)
      {
         _context.JobListings.Remove(jobListing);
         await _context.SaveChangesAsync();
      }

      return RedirectToAction(nameof(Index));

   }

   public bool JobListingExists(int id)
   {
      return _context.JobListings.Any(e => e.Id == id);
   }
}
