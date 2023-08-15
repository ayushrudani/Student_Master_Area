using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Student_Master_Areas.Areas.LOC_Country.Models;
using Student_Master_Areas.Areas.LOC_State.Models;
using Student_Master_Areas.Areas.LOC_City.Models;

namespace Student_Master_Areas.DAL
{
    public class LOC_DAL_BASE: DAL_Halper
    {

        #region LOC_Country_SelectAll
        public DataTable LOC_CountryList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDatabase.GetStoredProcCommand("SELECTALLOC_Country");
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

        #region LOC_Country_SelectByPKID
        public DataTable LOC_Country_SelectByPK(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectByPKLOC_Country");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, CountryID);
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

        #region LOC_Country_Insert
        public string LOC_Country_Insert(LOC_CountryModel countryModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertLOC_Country");
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, countryModel.CountryName.Trim());
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.VarChar, countryModel.CountryCode.Trim());
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region LOC_Country_Update
        public string LOC_Country_Update(LOC_CountryModel countryModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UPDATELOC_Country");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, countryModel.CountryID);
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, countryModel.CountryName.Trim());
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.VarChar, countryModel.CountryCode.Trim());
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region LOC_Country_Delete
        public string LOC_Country_Delete(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("DELETELOC_Country");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, CountryID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region LOC_State_SelectAll
        public DataTable LOC_StateList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDatabase.GetStoredProcCommand("SELECTALLOC_State");
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

        #region LOC_State_SelectByPKID
        public DataTable LOC_State_SelectByPKID(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectByPKLOC_State");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, StateID);
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

        #region LOC_State_Insert
        public string LOC_State_Insert(LOC_StateModel stateModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertLOC_State");
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, stateModel.StateName.Trim());
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, stateModel.StateCode.Trim());
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, stateModel.CountryID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region LOC_State_Update
        public string LOC_State_Update(LOC_StateModel stateModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UPDATELOC_State");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, stateModel.StateID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, stateModel.StateName.Trim());
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.VarChar, stateModel.StateCode.Trim());
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, stateModel.CountryID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region LOC_State_Delete
        public string LOC_State_Delete(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("DELETELOC_State");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, StateID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region LOC_City_SelectAll
        public DataTable LOC_CityList()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDatabase.GetStoredProcCommand("SELECTALLOC_City");
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

        #region LOC_City_SelectByPKID
        public DataTable LOC_City_SelectByPKID(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectByPKLOC_City");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, CityID);
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

        #region LOC_City_Insert
        public string LOC_City_Insert(LOC_CityModel cityModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertLOC_City");
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, cityModel.CityName.Trim());
                sqlDB.AddInParameter(dbCMD, "CityCode", SqlDbType.VarChar, cityModel.CityCode.Trim());
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, cityModel.StateID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region LOC_City_Update
        public string LOC_City_Update(LOC_CityModel cityModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UPDATELOC_City");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, cityModel.CityID);
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, cityModel.CityName.Trim());
                sqlDB.AddInParameter(dbCMD, "CityCode", SqlDbType.VarChar, cityModel.CityCode.Trim());
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, cityModel.StateID);
                sqlDB.ExecuteNonQuery(dbCMD);
                return "Record Updated Successfully";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        #region LOC_City_Delete
        public string LOC_City_Delete(int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("DELETELOC_City");
                sqlDB.AddInParameter(dbCMD, "ID", SqlDbType.Int, CityID);
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
