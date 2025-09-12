using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using TMS.Data;
using TMS.Models;

public class AccountController : Controller
{
    private readonly TourismContext _context;

    public AccountController(TourismContext context)
    {
        _context = context;
    }

    //  REGISTER 
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            //  Check if email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(user);
            }

            //  Default role
            user.Role = "Customer";

            
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        return View(user);
    }

    //  LOGIN 
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            //  Save session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetString("UserName", user.Name);

            //  Redirect by role
            return user.Role == "Admin"
                ? RedirectToAction("Index", "Admin")
                : RedirectToAction("Index", "Customer");
        }

        ViewBag.Error = "Invalid email or password.";
        return View();
    }

    //  LOGOUT 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
