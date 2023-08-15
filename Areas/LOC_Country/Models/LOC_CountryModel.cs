using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Plese Enter Country Name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Plese Enter Country Code")]
        public string CountryCode { get; set; }

        public DateOnly Created { get; set; }

        public DateOnly Modified { get; set; }
    }
    public class LOC_CountryDropDownModel
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}
