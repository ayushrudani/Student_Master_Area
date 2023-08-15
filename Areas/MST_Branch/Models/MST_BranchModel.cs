using System.ComponentModel.DataAnnotations;

namespace Student_Master_Areas.Areas.MST_Branch.Models
{
    public class MST_BranchModel
    {
        public int? BranchID { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string BranchCode { get; set; }

        public DateOnly Created { get; set; }

        public DateOnly Modified { get; set; }
    }
    public class LOC_BranchDropDownModel
    {
        public int? BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
