using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.BAL;
using Student_Master_Areas.DAL;
using System.Data;

namespace Student_Master_Areas.Controllers
{
    [CheckUser]
    public class GetUserDetailsController : Controller
    {
        public IActionResult GetUserDetails(int id)
        {
            MST_DAL mST_DAL = new MST_DAL();
            DataTable dt = mST_DAL.MST_Student_SelectByPK(id);
            return View(dt);
        }
    }
}
