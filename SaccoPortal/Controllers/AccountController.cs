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
    public async Task<IActionResult> Register(Register model)
    {
        if (ModelState.IsValid)
        {
#pragma warning disable IDE0090 // Use 'new(...)'
            User user = new User
            {
                UserId = Guid.NewGuid().ToString(), // Generate a new GUID for the user ID
                MemberId = model.MemberId, // Link to the existing member
                Email = model.Email // Set the Email
            };
#pragma warning restore IDE0090 // Use 'new(...)'

            var result = await _userManager.CreateAsync(user, model.Password); // Use CreateAsync method

            if (result.Succeeded)
            {
                // Optionally assign a default role here
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // In case of validation errors, re-fetch members for the view
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
            var user = await _userManager.FindByNameAsync(model.Username); // Use UserManager to find the user
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) // Check password
            {
                // Sign in the user (implement authentication logic here)
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(model);
    }
}
