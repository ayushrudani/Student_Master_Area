using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.MST_Student.Models
{
    public class MST_StudentModel
    {
        public int? StudentID { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public int? BranchID { get; set; }
        public string? BranchName { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public int? CityID { get; set; }
        public string? CityName { get; set; }

        public string? StateName { get; set; }

        public string? CountryName { get; set; }

        [Required(ErrorMessage = "Please Enter Student Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNoStudent")]

        public string MobileNoStudent { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNoFather")]

        public string MobileNoFather { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter BirthDate")]

        public string BirthDate { get; set; }

        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter IsActive")]

        public string IsActive { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public DateOnly Created { get; set; }

        public DateOnly Modified { get; set; }

        public string? StudentNameSearch { get; set; }

        public string? NewPassword { get; set; }

    }
}
