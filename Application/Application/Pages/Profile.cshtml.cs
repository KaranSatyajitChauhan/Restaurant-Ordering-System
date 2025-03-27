using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class ProfileModel : PageModel
{
    [BindProperty]
    public string FullName { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Phone { get; set; }

    public void OnGet()
    {
        // Load user data (example)
        FullName = "John Doe";
        Email = "user@example.com";
        Phone = "+1234567890";
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Save logic here
        TempData["Message"] = "Profile updated!";
        return RedirectToPage();
    }
}