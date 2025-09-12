using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data;
using TMS.Models;

public class CustomerController : Controller
{
    private readonly TourismContext _context;

    public CustomerController(TourismContext context) => _context = context;

    //  Browse Packages
    public IActionResult Index()
    {
        var packages = _context.TourPackages.ToList();
        return View(packages);
    }

    // GET: Book Package
    [HttpGet]
    public IActionResult Book(int id)
    {
        var package = _context.TourPackages.FirstOrDefault(p => p.Id == id);
        if (package == null) return NotFound();

        ViewData["Package"] = package;

        return View(new Booking
        {
            TourPackageId = package.Id,
            BookingDate = DateTime.Today // Default to today
        });
    }

    // POST: Confirm Booking
    [HttpPost]
    public IActionResult Book(Booking booking)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (!userId.HasValue)
            return RedirectToAction("Login", "Account");

        var package = _context.TourPackages.FirstOrDefault(p => p.Id == booking.TourPackageId);
        if (package == null)
        {
            ModelState.AddModelError("", "Selected package does not exist.");
            ViewData["Package"] = package;
            return View(booking);
        }

        // Assign required fields
        booking.Id = 0; 
        booking.UserId = userId.Value;
        booking.AmountPaid = booking.Seats * package.Price;
        booking.ConfirmedOn = DateTime.Now;

        
        booking.TourPackage = null;

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return RedirectToAction("BookingConfirmation", new { id = booking.Id });
    }

    // GET: Booking Confirmation
    public IActionResult BookingConfirmation(int id)
    {
        var booking = _context.Bookings
            .Include(b => b.TourPackage)
            .FirstOrDefault(b => b.Id == id);

        if (booking == null) return NotFound();

        return View(booking);
    }

    // GET: Booking History
    public IActionResult BookingHistory()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (!userId.HasValue)
            return RedirectToAction("Login", "Account");

        var bookings = _context.Bookings
            .Include(b => b.TourPackage)
            .Where(b => b.UserId == userId.Value)
            .ToList();

        return View(bookings);
    }


    
    // POST: Cancel Booking
    [HttpPost]
    public IActionResult CancelBooking(int id)
    {
        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

        if (booking == null) return NotFound();

        // Check cancellation rule
        if (booking.BookingDate <= DateTime.Today.AddDays(2))
        {
            TempData["Error"] = "Cancellations are only allowed up to 2 days before the journey.";
            return RedirectToAction("BookingHistory");
        }

        // Update status
        booking.Status = BookingStatus.Cancelled;

        // Calculate refund (85%)
        var refundAmount = booking.AmountPaid * 0.85m;
        _context.SaveChanges();

        // Store refund safely in TempData (as string)
        TempData["Refund"] = refundAmount.ToString("F2");

        return RedirectToAction("BookingHistory");
    }



    // GET: Search Packages
    [HttpGet]
    public IActionResult Search(string query)
    {
        var packages = string.IsNullOrWhiteSpace(query)
            ? _context.TourPackages.ToList()
            : _context.TourPackages
                      .Where(p => p.Title.Contains(query) || p.Description.Contains(query))
                      .ToList();

        return View("Index", packages); 
    }



}
