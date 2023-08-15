using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Enter State Code")]
        public string StateCode { get; set; }

        public string? CountryName { get; set; }

        [Required(ErrorMessage = "Please Choose Country Name")]
        public int CountryID { get; set; }

        public DateOnly Created { get; set; }

        public DateOnly Modified { get; set; }
    }
    public class LOC_StateDropDownModel
    {
        public int StateID { get; set; }

        public string StateName { get; set; }
    }
}
