using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BpkbMvc.Models
{
    public class LoginModel
    {
        [StringLength(20)]
        [DisplayName("Username")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
