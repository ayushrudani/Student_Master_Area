using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please Enter City Code")]
        public string CityCode { get; set; }

        public string? StateName { get; set; }
        public string? CountryName { get; set; }

        [Required(ErrorMessage = "Please Choose State Name")]
        public int StateID { get; set; }
        public DateOnly Created { get; set; }

        public DateOnly Modified { get; set; }
    }
    public class LOC_CityDropDownModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }

}
