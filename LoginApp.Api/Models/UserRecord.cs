namespace LoginApp.Api.Models
{
    public class UserRecord
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
