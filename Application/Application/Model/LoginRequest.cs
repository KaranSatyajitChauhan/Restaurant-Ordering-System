namespace Week_6_Class_2_DW4.Models
{
    public class LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            this.Email = email;
            this.Password=password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
