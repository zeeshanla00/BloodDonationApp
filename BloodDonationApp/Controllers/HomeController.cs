using BloodDonationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BloodDonationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext donorDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly EmailService _emailService;


        public HomeController(AppDbContext donorDB, EmailService emailService)
        {
            this.donorDB = donorDB;
            _emailService = emailService;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                //await emailSender.SendEmailAsync(email, subject, message);
                var dnrData = await donorDB.Donors.ToListAsync();
                return View(dnrData);

            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Donor dnr)
        {
            if (ModelState.IsValid)
            {
                await donorDB.Donors.AddAsync(dnr);
                await donorDB.SaveChangesAsync();
                TempData["message"] = "Created Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(dnr);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || donorDB.Donors == null)
            {
                return NotFound();
            }
            var dnrData = await donorDB.Donors.FirstOrDefaultAsync(x => x.Id == id);
            if (dnrData == null)
            {
                return NotFound();
            }
            return View(dnrData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || donorDB.Donors == null)
            {
                return NotFound();
            }
            var dnrData = await donorDB.Donors.FindAsync(id);
            if (dnrData == null)
            {
                return NotFound();
            }
            return View(dnrData);

        }
        [HttpPost]

        public async Task<IActionResult> Edit(int? id, Donor dnr)
        {
            if (id != dnr.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                donorDB.Update(dnr);
                await donorDB.SaveChangesAsync();
                TempData["message"] = "Updated Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(dnr);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var dnrData = await donorDB.Donors.FirstOrDefaultAsync(x => x.Id == id);
            return View(dnrData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dnrData = await donorDB.Donors.FindAsync(id);
            if (dnrData != null)
            {
                donorDB.Donors.Remove(dnrData);
            }
            await donorDB.SaveChangesAsync();
            TempData["message"] = "Deleted Successfully";
            return RedirectToAction("Index", "Home");

        }

        public IActionResult RequestDonation(int id)
        {
            var donor = donorDB.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            // Send email to donor
            _emailService.SendDonationRequestEmail(donor.Email);


            // Redirect to a view with a confirmation message
            //return RedirectToAction("Confirmation", new { id = donor.Id });
            return RedirectToAction("Confirmation");
        }

        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}