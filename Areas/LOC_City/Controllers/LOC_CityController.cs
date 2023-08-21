using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.Areas.LOC_City.Models;
using System.Data.SqlClient;
using System.Data;
using Student_Master_Areas.Areas.LOC_State.Models;
using Student_Master_Areas.DAL;
using Student_Master_Areas.BAL;

namespace Student_Master_Areas.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [CheckAdmin]
    [Area("LOC_City")]
    [Route("LOC_City/{controller}/{action}")]
    public class LOC_CityController : Controller
    {

        #region #CityList
        public IActionResult LOC_CityList()
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            DataTable dt = lOC_DAL.LOC_CityList();
            if (dt.Rows.Count == 0)
            {
                ViewBag.City = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region #SetStateDropDownList
        public void SetStateDropDownList()
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            DataTable dt = lOC_DAL.Set_State_DropDownList();
            List<LOC_StateDropDownModel> stateDropDownModelList = new List<LOC_StateDropDownModel>();
            foreach (DataRow data in dt.Rows)
            {
                LOC_StateDropDownModel stateDropDownModel = new LOC_StateDropDownModel();
                stateDropDownModel.StateID = Convert.ToInt32(data["StateID"]);
                stateDropDownModel.StateName = data["StateName"].ToString();
                stateDropDownModelList.Add(stateDropDownModel);
            }
            ViewBag.stateDropDownModel = stateDropDownModelList;
        }
        #endregion

        #region #CityAddEditView
        public IActionResult LOC_CityAddEdit()
        {
            SetStateDropDownList();
            return View();
        }
        #endregion

        #region #CityAddEditData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LOC_CityAddEdit(LOC_CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                LOC_DAL lOC_DAL = new LOC_DAL();
                if (cityModel.CityID == null)
                {
                    TempData["message"] = lOC_DAL.LOC_City_Insert(cityModel);
                }
                else
                {
                    TempData["message"] = lOC_DAL.LOC_City_Update(cityModel);
                }
                return RedirectToAction("LOC_CityList");
            }
            else
            {
                SetStateDropDownList();
                return View();
            }
        }
        #endregion

        #region #CityEdit
        [HttpGet]
        public IActionResult LOC_CityEdit(int id)
        {
            LOC_DAL loc_DAL = new LOC_DAL();
            DataTable dt = loc_DAL.LOC_City_SelectByPKID(id);
            LOC_CityModel cityModel = new LOC_CityModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    cityModel.CityID = Convert.ToInt32(dataRow[0]);
                    cityModel.StateID = Convert.ToInt32(dataRow[1]);
                    cityModel.CityName = dataRow[3].ToString();
                    cityModel.CityCode = dataRow[4].ToString();
                }
            }
            ViewBag.ID = id;
            SetStateDropDownList();
            return View("LOC_CityAddEdit", cityModel);
        }
        #endregion

        #region #CityDelete
        public IActionResult LOC_CityDelete(int id)
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            TempData["message"] = lOC_DAL.LOC_City_Delete(id);
            return RedirectToAction("LOC_CityList");
        }
        #endregion

        #region #Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("LOC_CityList");
        }
        #endregion
    }
}
