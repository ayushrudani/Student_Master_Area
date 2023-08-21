using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Student_Master_Areas.Areas.LOC_City.Models;
using Student_Master_Areas.Areas.MST_Branch.Models;
using Student_Master_Areas.DAL;
using Student_Master_Areas.Areas.MST_Student.Models;
using Student_Master_Areas.BAL;

namespace Student_Master_Areas.Areas.MST_Student.Controllers
{
    [CheckAccess]
    [CheckAdmin]
    [Area("MST_Student")]
    [Route("MST_Student/{controller}/{action}")]
    public class MST_StudentController : Controller
    {

        #region #DateFromater
        public string dateFormate(String input)
        {
            string[] ans = new string[3];
            ans = input.Split(' ');
            return ans[0];
        }
        #endregion

        #region #SetCityDropDownList
        public void SetCityDropDownList()
        {
            LOC_DAL lOC_DAL = new LOC_DAL();
            DataTable dt = lOC_DAL.Set_City_DropDownList();
            List<LOC_CityDropDownModel> cityDropDownModelList = new List<LOC_CityDropDownModel>();
            foreach (DataRow data in dt.Rows)
            {
                LOC_CityDropDownModel cityDropDownModel = new LOC_CityDropDownModel();
                cityDropDownModel.CityID = Convert.ToInt32(data["CityID"]);
                cityDropDownModel.CityName = data["CityName"].ToString();
                cityDropDownModelList.Add(cityDropDownModel);
            }

            ViewBag.cityDropDownModel = cityDropDownModelList;
        }
        #endregion

        #region #SetBranchDropDownList
        public void SetBranchDropDownList()
        {
            MST_DAL mST_DAL = new MST_DAL();
            DataTable dt = mST_DAL.Set_Branch_DropDownList();
            List<LOC_BranchDropDownModel> branchDropDownModelList = new List<LOC_BranchDropDownModel>();
            foreach (DataRow data in dt.Rows)
            {
                LOC_BranchDropDownModel branchDropDownModel = new LOC_BranchDropDownModel();
                branchDropDownModel.BranchID = Convert.ToInt32(data["BranchID"]);
                branchDropDownModel.BranchName = data["BranchName"].ToString();
                branchDropDownModelList.Add(branchDropDownModel);
            }

            ViewBag.branchDropDownModel = branchDropDownModelList;
        }
        #endregion

        #region #StudentList
        public IActionResult MST_StudentList()
        {
            SetBranchDropDownList();
            SetCityDropDownList();
            MST_DAL mST_DAL = new MST_DAL();
            DataTable dt = mST_DAL.MST_StudentList();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Student = "NULL";
            }
            else
            {
                List<MST_StudentModel> studentModelList = new List<MST_StudentModel>();
                foreach(DataRow data in dt.Rows)
                {
                    MST_StudentModel studentModel = new MST_StudentModel();
                    studentModel.StudentID = Convert.ToInt32(data["StudentID"]);
                    studentModel.BranchName = data["BranchName"].ToString();
                    studentModel.CityName = data["CityName"].ToString();
                    studentModel.StudentName = data["StudentName"].ToString();
                    studentModel.Email = data["Email"].ToString();
                    studentModelList.Add(studentModel);
                }
                ViewBag.studentList = studentModelList;
            }
            return View();
        }
        #endregion

        #region #StudentProfile
        public IActionResult MST_StudentProfile(int id)
        {
            MST_DAL mST_DAL = new MST_DAL();
            DataTable dt = mST_DAL.MST_Student_SelectByPK(id);
            MST_StudentModel studentModel = new MST_StudentModel();
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow data in dt.Rows)
                {
                    studentModel.StudentID = Convert.ToInt32(data["StudentID"]);
                    studentModel.BranchID = Convert.ToInt32(data["BranchID"]);
                    studentModel.BranchName = data["BranchName"].ToString();
                    studentModel.CityID = Convert.ToInt32(data["CityID"]);
                    studentModel.CityName = data["CityName"].ToString();
                    studentModel.StateName = data["StateName"].ToString();
                    studentModel.CountryName = data["CountryName"].ToString();
                    studentModel.StudentName = data["StudentName"].ToString();
                    studentModel.MobileNoStudent = data["MobileNoStudent"].ToString();
                    studentModel.Email = data["Email"].ToString();
                    studentModel.MobileNoFather = data["MobileNoFather"].ToString();
                    studentModel.Address = data["Address"].ToString();
                    studentModel.BirthDate = Convert.ToDateTime(data["BirthDate"]);
                    studentModel.Age = Convert.ToInt32(data["Age"]);
                    studentModel.IsActive = data["IsActive"].ToString();
                    studentModel.Gender = data["Gender"].ToString();
                    studentModel.Password = data["Password"].ToString();
                    studentModel.Created = System.DateOnly.Parse(dateFormate(data["Created"].ToString()));
                    studentModel.Modified = System.DateOnly.Parse(dateFormate(data["Modified"].ToString()));
                }
            }
            SetBranchDropDownList();
            SetCityDropDownList();
            ViewBag.ID = id;
            return View(studentModel);

        }
        #endregion

        #region #StudentAddEditView
        public IActionResult MST_StudentAddEdit()
        {
            SetBranchDropDownList();
            SetCityDropDownList();
            return View();
        }
        #endregion

        #region #StudentAddEditData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MST_StudentAddEdit(MST_StudentModel studentModel)
        {

            if (ModelState.IsValid)
            {
                MST_DAL mST_DAL = new MST_DAL();
                if(studentModel.StudentID == null)
                {
                    TempData["message"] = mST_DAL.MST_Student_Insert(studentModel);
                    return RedirectToAction("MST_StudentList");
                }
                else
                {
                    mST_DAL.MST_Student_Update(studentModel);
                    return RedirectToAction("MST_StudentProfile", new { id = studentModel.StudentID });
                }
            }
            else if(studentModel.StudentID == null)
            {
                SetBranchDropDownList();
                SetCityDropDownList();
                return View("MST_StudentAddEdit");
            }
            else
            {
                return RedirectToAction("MST_StudentProfile", new { id = studentModel.StudentID });
            }
        }
        #endregion

        #region #StudentDelete
        public IActionResult MST_StudentDelete(int id)
        {
            MST_DAL mST_DAL = new MST_DAL();
            TempData["message"] = mST_DAL.MST_Student_Delete(id);
            return RedirectToAction("MST_StudentList");
        }
        #endregion

        #region #SetStudentFilter
        public void SETMST_StudentFilter(string pro, int BranchID = 0, int CityID = 0)
        {
            SetBranchDropDownList();
            SetCityDropDownList();
            MST_DAL mST_DAL = new MST_DAL();
            DataTable dt = new DataTable();
            if (pro == "MST_StudentFilterBranch")
            {
                dt = mST_DAL.SetStudentFilterBranch(BranchID);
            }
            else if (pro == "MST_StudentFilterCity")
            {
                dt = mST_DAL.SetStudentFilterCity(CityID);
            }
            else
            {
                dt = mST_DAL.SetStudentFilterAll(BranchID, CityID);
            }
            List<MST_StudentModel> studentModelList = new List<MST_StudentModel>();
            if (dt.Rows.Count == 0)
            {
                ViewBag.Student = "NULL";
            }
            else
            {
                foreach (DataRow data in dt.Rows)
                {
                    MST_StudentModel studentModel = new MST_StudentModel();
                    studentModel.StudentID = Convert.ToInt32(data["StudentID"]);
                    studentModel.StudentName = data["StudentName"].ToString();
                    studentModel.BranchName = data["BranchName"].ToString();
                    studentModel.CityName = data["CityName"].ToString();
                    studentModel.Email = data["Email"].ToString();
                    studentModel.Created = System.DateOnly.Parse(dateFormate(data["Created"].ToString()));
                    studentModel.Modified = System.DateOnly.Parse(dateFormate(data["Modified"].ToString()));
                    studentModelList.Add(studentModel);
                }
                ViewBag.studentList = studentModelList;
            }
        }
        #endregion

        #region #StudentFilter
        public IActionResult MST_StudentFilter(int BranchID, int CityID)
        {
            if (BranchID == 0 && CityID == 0)
            {
                return RedirectToAction("MST_StudentList");
            }
            else if (BranchID == 0 && CityID != 0)
            {
                SETMST_StudentFilter("MST_StudentFilterCity", CityID: CityID);
                return View("MST_StudentList");
            }
            else if (BranchID != 0 && CityID == 0)
            {
                SETMST_StudentFilter("MST_StudentFilterBranch", BranchID: BranchID);
                return View("MST_StudentList");
            }
            else
            {
                SETMST_StudentFilter("MST_StudentFilterAll", BranchID, CityID);
                return View("MST_StudentList");
            }
        }
        #endregion

        #region #Cancel
        public IActionResult Cancel()
        {
            return RedirectToAction("MST_StudentList");
        }
        #endregion
    }
}
