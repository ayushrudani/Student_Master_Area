using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Student_Master_Areas.Areas.SEC_Register.Models;

namespace Student_Master_Areas.DAL
{
    public class SEC_DAL : DAL_Halper
    {
        public DataTable Select_UserName_Password(string UserName,string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("USER_ID_PASSWORD");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);
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

        public void Insert_New_User(SEC_RegisterModel sEC_RegisterModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("INSERT_MASTER_USER");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, sEC_RegisterModel.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, sEC_RegisterModel.Password);
                sqlDB.AddInParameter(dbCMD, "ImageURL", SqlDbType.VarChar, sEC_RegisterModel.ImageURL);
                sqlDB.AddInParameter(dbCMD, "Is_Admin", SqlDbType.Bit,1);
                sqlDB.AddInParameter(dbCMD, "StudentID", SqlDbType.Int, null);
                sqlDB.ExecuteNonQuery(dbCMD);

                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
