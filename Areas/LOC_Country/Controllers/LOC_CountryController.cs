using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.Areas.LOC_Country.Models;
using Student_Master_Areas.BAL;
using Student_Master_Areas.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Student_Master_Areas.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [CheckAdmin]
    [Area("LOC_Country")]
    [Route("LOC_Country/{controller}/{action}")]
    public class LOC_CountryController : Controller
    {
        #region #CountryList
        public IActionResult LOC_CountryList()
        {
            LOC_DAL LOC_Country_DAL = new LOC_DAL();
            DataTable dtCountryList = LOC_Country_DAL.LOC_CountryList();
            return View(dtCountryList);
        }
        #endregion

        #region #CountryAddEditView
        public IActionResult LOC_CountryAddEdit()
        {
            return View();
        } 
        #endregion

        #region #CountryAddEditData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LOC_countryAddEdit(LOC_CountryModel countryModel)
        {

            if (ModelState.IsValid)
            {
                LOC_DAL lOC_DAL = new LOC_DAL();

                if (countryModel.CountryID == null)
                {   
                    TempData["message"] = lOC_DAL.LOC_Country_Insert(countryModel);
                }
                else
                {   
                    TempData["message"] = lOC_DAL.LOC_Country_Update(countryModel);
                }
                return RedirectToAction("LOC_CountryList");
            }
            else
            {
                return View("LOC_CountryAddEdit");
            }
        }
        #endregion

        #region #CountryEdit
        [HttpGet]
        public IActionResult LOC_CountryEdit(int id)
        {
            
            LOC_CountryModel countryModel = new LOC_CountryModel();
            LOC_DAL loc_DAL = new LOC_DAL();
            DataTable dtCountry = loc_DAL.LOC_Country_SelectByPK(id);
            foreach (DataRow dataRow in dtCountry.Rows)
            {
                countryModel.CountryID = Convert.ToInt32(dataRow[0]);
                countryModel.CountryName = dataRow[1].ToString();
                countryModel.CountryCode = dataRow[2].ToString();
            }
           
            ViewBag.ID = id;
            return View("LOC_CountryAddEdit", countryModel);
        }
        #endregion

        #region #CountryDelete
        public IActionResult LOC_CountryDelete(int id)
        {
           
            LOC_DAL lOC_DAL = new LOC_DAL();
            TempData["message"] = lOC_DAL.LOC_Country_Delete(id); ;
            return RedirectToAction("LOC_CountryList");
        } 
        #endregion

        #region #Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("LOC_CountryList");
        } 
        #endregion
    }
}
