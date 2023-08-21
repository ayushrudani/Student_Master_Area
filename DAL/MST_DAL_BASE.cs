using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Student_Master_Areas.Areas.MST_Branch.Models;
using Student_Master_Areas.Areas.MST_Student.Models;
using System.Data.SqlClient;

namespace Student_Master_Areas.DAL
{
    public class MST_DAL_BASE : DAL_Halper
    {
        #region MST_Branch_SelectAll
        public DataTable MST_BranchList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDatabase.GetStoredProcCommand("SELECTALMST_Branch");
                DataTable dataTable = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCMD))
                {
                    dataTable.Load(dr);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region MST_Branch_SelectByPKID
        public DataTable MST_Branch_SelectByPK(int? BranchID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectByPKMST_Branch");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, BranchID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region MST_Branch_Insert
        public string MST_Branch_Insert(MST_BranchModel branchModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertMST_Branch");
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.NVarChar, branchModel.BranchName.Trim());
                sqlDB.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, branchModel.BranchCode.Trim());
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region MST_Branch_Update
        public string MST_Branch_Update(MST_BranchModel branchModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UPDATEMST_Branch");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, branchModel.BranchID);
                sqlDB.AddInParameter(dbCMD, "BranchName", SqlDbType.NVarChar, branchModel.BranchName.Trim());
                sqlDB.AddInParameter(dbCMD, "BranchCode", SqlDbType.VarChar, branchModel.BranchCode.Trim());
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region MST_Branch_Delete
        public string MST_Branch_Delete(int BranchID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("DELETEMST_Branch");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, BranchID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region MST_Student_SelectAll
        public DataTable MST_StudentList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDatabase.GetStoredProcCommand("SELECTALMST_Student");
                DataTable dataTable = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCMD))
                {
                    dataTable.Load(dr);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region MST_Student_SelectByPKID
        public DataTable MST_Student_SelectByPK(int? StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectByPKMST_Student");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, StudentID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region MST_Student_Insert
        public string MST_Student_Insert(MST_StudentModel studentModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertMST_Student");
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, studentModel.BranchID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, studentModel.CityID);
                sqlDB.AddInParameter(dbCMD, "StudentName", SqlDbType.NVarChar, studentModel.StudentName.Trim());
                sqlDB.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, studentModel.MobileNoStudent.Trim());
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, studentModel.Email.Trim());
                sqlDB.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, studentModel.MobileNoFather.Trim());
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, studentModel.Address.Trim());
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, studentModel.BirthDate);
                if (studentModel.IsActive == "Yes")
                {
                    sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, 1);
                }
                else
                {
                    sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, 0);
                }
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, studentModel.Gender);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, studentModel.Password.Trim());
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region MST_Student_Update
        public string MST_Student_Update(MST_StudentModel studentModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UPDATEMST_Student");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, studentModel.StudentID);
                sqlDB.AddInParameter(dbCMD, "BranchID", SqlDbType.Int, studentModel.BranchID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, studentModel.CityID);
                sqlDB.AddInParameter(dbCMD, "StudentName", SqlDbType.NVarChar, studentModel.StudentName.Trim());
                sqlDB.AddInParameter(dbCMD, "MobileNoStudent", SqlDbType.VarChar, studentModel.MobileNoStudent.Trim());
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, studentModel.Email.Trim());
                sqlDB.AddInParameter(dbCMD, "MobileNoFather", SqlDbType.VarChar, studentModel.MobileNoFather.Trim());
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, studentModel.Address.Trim());
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, studentModel.BirthDate);
                if (studentModel.IsActive == "Yes")
                {
                    sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, 1);
                }
                else
                {
                    sqlDB.AddInParameter(dbCMD, "IsActive", SqlDbType.Bit, 0);
                }
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.VarChar, studentModel.Gender);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }

}
        #endregion

        #region MST_Student_Delete
        public string MST_Student_Delete(int StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("DELETEMST_Student");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, StudentID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

    }
}
