using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.SEC_Login.Models
{
    public class SEC_LoginModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ImageURL { get; set; }

        public int StudentID { get; set; }

        public int is_Admin  { get; set; }
    }
}
