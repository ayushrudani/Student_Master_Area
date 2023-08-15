using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Student_Master_Areas.Areas.LOC_State.Models;
using Student_Master_Areas.Areas.LOC_Country.Models;
using Student_Master_Areas.DAL;

namespace Student_Master_Areas.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("LOC_State/{controller}/{action}")]
    public class LOC_StateController : Controller
    {

        #region #StateList
        public IActionResult LOC_StateList()
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            DataTable dt = lOC_DAL.LOC_StateList();
            if (dt.Rows.Count == 0)
            {
                ViewBag.State = "NULL";
            }
            return View(dt);
        }
        #endregion

        #region #SetCountryDropDownList
        public void SetCountryDropDownList()
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            DataTable dt = lOC_DAL.Set_Country_DropDownList();
            List<LOC_CountryDropDownModel> countryDropDownModelList = new List<LOC_CountryDropDownModel>();
            foreach (DataRow data in dt.Rows)
            {
                LOC_CountryDropDownModel countryDropDownModel = new LOC_CountryDropDownModel();
                countryDropDownModel.CountryID = Convert.ToInt32(data["CountryID"]);
                countryDropDownModel.CountryName = data["CountryName"].ToString();
                countryDropDownModelList.Add(countryDropDownModel);
            }

            ViewBag.countryDropDownModel = countryDropDownModelList;
        }
        #endregion

        #region #StateAddEditView
        public IActionResult LOC_StateAddEdit()
        {
            SetCountryDropDownList();
            return View();
        }
        #endregion

        #region #StateAddEditData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LOC_StateAddEdit(LOC_StateModel stateModel)
        {
            if (ModelState.IsValid)
            {
                LOC_DAL lOC_DAL = new LOC_DAL();
                if (stateModel.StateID == null)
                {
                    TempData["message"] = lOC_DAL.LOC_State_Insert(stateModel);
                }
                else
                {
                    TempData["message"] = lOC_DAL.LOC_State_Update(stateModel);
                }
                return RedirectToAction("LOC_StateList");
            }
            else
            {
                SetCountryDropDownList();
                return View();
            }
        }
        #endregion

        #region #StateEdit
        [HttpGet]
        public IActionResult LOC_StateEdit(int id)
        {
            LOC_DAL loc_DAL = new LOC_DAL();
            DataTable dt = loc_DAL.LOC_State_SelectByPKID(id);
            LOC_StateModel stateModel = new LOC_StateModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    stateModel.StateID = Convert.ToInt32(dataRow[0]);
                    stateModel.CountryID = Convert.ToInt32(dataRow[1]);
                    stateModel.StateName = dataRow[2].ToString();
                    stateModel.StateCode = dataRow[3].ToString();
                }
            }
            ViewBag.ID = id;
            SetCountryDropDownList();
            return View("LOC_StateAddEdit", stateModel);
        }
        #endregion

        #region #StateDelete
        public IActionResult LOC_StateDelete(int id)
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            TempData["message"] = lOC_DAL.LOC_State_Delete(id);
            return RedirectToAction("LOC_StateList");
        } 
        #endregion

        #region #Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("LOC_StateList");
        }
        #endregion

    }
}
