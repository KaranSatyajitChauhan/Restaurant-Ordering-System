using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Application.Model;
using System.Text;
using Week_6_Class_2_DW4.Models;
using static Application.Model.LoginDto;

namespace Week_6_Class_2_DW4.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public SignUpModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var requestBody = new SignUpDto
                {
                    UserName = UserName,
                    Password = Password,
                    Email = Email
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Assuming your API URL for signup is something like this:
                var response = await _httpClient.PostAsync("http://localhost:5094/api/auth/signup", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var successResponse = JsonConvert.DeserializeObject<SignUpResponse>(responseString);

                    SuccessMessage = "User registered successfully!";
                    return RedirectToPage("/Login"); // Redirect to login page
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<SignUpResponse>(errorContent);
                    ErrorMessage = $"Error: {errorResponse?.error}";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error calling the API: {ex.Message}";
                return Page();
            }
        }
    }
}
