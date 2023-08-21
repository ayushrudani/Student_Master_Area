using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Student_Master_Areas.Areas.MST_Branch.Models;
using Student_Master_Areas.DAL;
using Student_Master_Areas.Areas.MST_Branch.Models;
using Student_Master_Areas.BAL;

namespace Student_Master_Areas.Areas.MST_Branch.Controllers
{
    [CheckAccess]
    [CheckAdmin]
    [Area("MST_Branch")]
    [Route("MST_Branch/{controller}/{action}")]
    public class MST_BranchController : Controller
    {

        #region #BranchList
        public IActionResult MST_BranchList()
        {
            MST_DAL mst_dal = new MST_DAL();
            DataTable dt = mst_dal.MST_BranchList();
            return View(dt);
        }
        #endregion

        #region #BranchAddEditView
        public IActionResult MST_BranchAddEdit()
        {
            return View();
        }
        #endregion

        #region #BranchAddEditData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MST_BranchAddEdit(MST_BranchModel branchModel)
        {

            if (ModelState.IsValid)
            {
                MST_DAL MST_DAL = new MST_DAL();

                if (branchModel.BranchID == null)
                {
                    TempData["message"] = MST_DAL.MST_Branch_Insert(branchModel);
                }
                else
                {
                    TempData["message"] = MST_DAL.MST_Branch_Update(branchModel);
                }
                return RedirectToAction("MST_BranchList");
            }
            else
            {
                return View("MST_BranchAddEdit");
            }
        }
        #endregion

        #region #BranchEdit
        [HttpGet]
        public IActionResult MST_BranchEdit(int id)
        {

            MST_BranchModel branchModel = new MST_BranchModel();
            MST_DAL MST_DAL = new MST_DAL();
            DataTable dtBranch = MST_DAL.MST_Branch_SelectByPK(id);
            foreach (DataRow dataRow in dtBranch.Rows)
            {
                branchModel.BranchID = Convert.ToInt32(dataRow[0]);
                branchModel.BranchName = dataRow[1].ToString();
                branchModel.BranchCode = dataRow[2].ToString();
            }

            ViewBag.ID = id;
            return View("MST_BranchAddEdit", branchModel);
        }
        #endregion

        #region #BranchDelete
        public IActionResult MST_BranchDelete(int id)
        {

            MST_DAL MST_DAL = new MST_DAL();
            TempData["message"] = MST_DAL.MST_Branch_Delete(id); ;
            return RedirectToAction("MST_BranchList");
        }
        #endregion

        #region #Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("MST_BranchList");
        }
        #endregion
    }
}
