namespace Week_6_Class_2_DW4.Models
{
    public class LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            this.email=email;
            this.password=password;
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}
