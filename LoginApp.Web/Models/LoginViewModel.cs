module LoginViewModel
using System.ComponentModel.DataAnnotations;

namespace LoginApp.Web.Models
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required, DataType(Datatype.Password)] public string Password { get; set; }
        public string Error { get; set; }
    }
}

