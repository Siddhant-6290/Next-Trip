using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data;
using TMS.Models;

public class AdminController : Controller
{
    private readonly TourismContext _context;

    public AdminController(TourismContext context) => _context = context;

    // Admin Dashboard
    public IActionResult Index()
    {
        return View();
    }

    // Manage Packages
    public IActionResult ManagePackages()
    {
        var packages = _context.TourPackages.ToList();
        return View(packages);
    }

    // Create/Edit/Delete Package actions
    public IActionResult CreatePackage() => View(new TourPackage());

    [HttpPost]
    public IActionResult CreatePackage(TourPackage package)
    {
        if (!ModelState.IsValid) return View(package);

        _context.TourPackages.Add(package);
        _context.SaveChanges();
        return RedirectToAction("ManagePackages");
    }

    public IActionResult EditPackage(int id)
    {
        var package = _context.TourPackages.Find(id);
        if (package == null) return NotFound();
        return View(package);
    }

    [HttpPost]
    public IActionResult EditPackage(TourPackage package)
    {
        if (!ModelState.IsValid) return View(package);

        _context.TourPackages.Update(package);
        _context.SaveChanges();
        return RedirectToAction("ManagePackages");
    }

    public IActionResult DeletePackage(int id)
    {
        var package = _context.TourPackages.Find(id);
        if (package != null)
        {
            _context.TourPackages.Remove(package);
            _context.SaveChanges();
        }
        return RedirectToAction("ManagePackages");
    }

    // Customer Details
    public IActionResult CustomerDetails()
    {
        var customers = _context.Users.Where(u => u.Role == "Customer").ToList();
        return View(customers);
    }
}
