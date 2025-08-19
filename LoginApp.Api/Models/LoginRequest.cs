namespace LoginApp.Api.Models
{
    public class LoginRequest
    {
        public class UsernamePassword
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
