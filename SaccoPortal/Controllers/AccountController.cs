using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaccoPortal.Models;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager; // Add UserManager
    private readonly SaccoPortalContext _context;

    public AccountController(UserManager<User> userManager, SaccoPortalContext context)
    {
        _userManager = userManager; // Initialize UserManager
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        // Pass a list of members to the view
        var members = _context.Members.ToList();
        ViewBag.Members = members; // Provide members for selection
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Create a new user with MemberId and Email
            User user = new User
            {
                UserId = Guid.NewGuid().ToString(),  // Generate a new GUID for the user ID
                MemberId = model.MemberId,           // Link to the existing member using MemberId
                Email = model.Email                  // Set the Email
            };

            // Use CreateAsync to register the user and hash the password
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally assign a default role here
                return RedirectToAction("Login");
            }

            // Add any errors encountered during user creation
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If registration fails, re-fetch members for selection in the view
        var members = _context.Members.ToList();
        ViewBag.Members = members;
        return View(model);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        if (ModelState.IsValid)
        {
            // Use MemberId to find the user instead of Username
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.MemberId == model.MemberId);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Sign in the user (you can implement your authentication logic here)
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(model);
    }
}
