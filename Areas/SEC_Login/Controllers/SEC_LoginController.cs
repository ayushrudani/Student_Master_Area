using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.Areas.SEC_Login.Models;
using Student_Master_Areas.DAL;
using System.Data;

namespace Student_Master_Areas.Areas.SEC_Login.Controllers
{
    [Area("SEC_Login")]
    [Route("SEC_Login/{controller}/{action}")]
    public class SEC_LoginController : Controller
    {
        #region SEC_Login
        public IActionResult SEC_Login()
        {
            HttpContext.Session.Clear();
            return View();
        } 
        #endregion

        #region Login
        [HttpPost]
        public IActionResult Login(SEC_LoginModel sEC_LoginModel)
        {
            SEC_DAL sEC_DAL = new SEC_DAL();
            DataTable dt = sEC_DAL.Select_UserName_Password(sEC_LoginModel.UserName, sEC_LoginModel.Password);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                    HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                    HttpContext.Session.SetString("Password", dr["Password"].ToString());
                    HttpContext.Session.SetString("ImageURL", dr["ImageURL"].ToString());
                    HttpContext.Session.SetString("Is_Admin", dr["Is_Admin"].ToString());
                    break;
                }
            }
            else
            {
                Console.WriteLine("User Name And Password Not Match!!");
                TempData["message"] = "User Name And Password Not Match!!";
                return RedirectToAction("SEC_Login");
            }
            if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
            {
                if (HttpContext.Session.GetString("Is_Admin") != "False")
                {
                    return RedirectToAction("LOC_CountryList", "LOC_Country", new { area = "LOC_Country" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("SEC_Login");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SEC_Login", "SEC_Login");
        } 
        #endregion

    }
}
