using BusinessWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrasimApplication.Models
{
    public class TailorMaster
    {
        public Guid GUID
        {
            get;
            set;
        }
        public IEnumerable<Guid> CategoryIds
        {
            get;
            set;
        }
        public IEnumerable<Guid> StyleIds
        {
            get;
            set;
        }
        public IEnumerable<Guid> FeatureIds
        {
            get;
            set;
        }
        public string TailorName
        {
            get;
            set;
        }
        public string TailorEmail
        {
            get;
            set;
        }
        public string TailorPhone
        {
            get;
            set;
        }
        public string TailorAddress
        {
            get;
            set;
        }
        public string TailorCity
        {
            get;
            set;
        }
        public string TailorPincode
        {
            get;
            set;
        }
        public string TailorImage
        {
            get;
            set;
        }
        public string TailorPricerange
        {
            get;
            set;
        }
        public int TailorStateId
        {
            get;
            set;
        }
        public int TailorStatus
        {
            get;
            set;
        }
        public int DeleteStatus
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public string TailorDescription
        {
            get;
            set;
        }
        public string TailorExpertise
        {
            get;
            set;
        }
        public decimal TailorLatitude
        {
            get;
            set;
        }
        public decimal TailorLongitude
        {
            get;
            set;
        }

        public DataTable getAllTailors()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtTailor = new DataTable();
            try
            {
                dtTailor = Ado.ExecuteStoredProcedure("sp_GetAllTailors", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtTailor.Dispose();
            }
            return dtTailor;
        }
        public DataTable getTailorByTailorId(Guid tailorId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtTailor = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", tailorId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtTailor = Ado.ExecuteStoredProcedure("sp_GetAllTailors", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtTailor.Dispose();
            }
            return dtTailor;
        }
        public void deleteTailorByTailorId(Guid tailorId)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", tailorId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteTailor", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
            }
        }
        public void saveTailor()
        {
            DbParameter[] parameters = new DbParameter[17];
            try
            {
                #region Save Tailor Detail
                parameters[0] = new SqlParameter("@tailorname", TailorName);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@tailoremail", TailorEmail);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@tailorphone", TailorPhone);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@tailoraddress", TailorAddress);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.String;

                parameters[4] = new SqlParameter("@tailorCity", TailorCity);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.String;

                parameters[5] = new SqlParameter("@tailorpin", TailorPincode);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.String;

                parameters[6] = new SqlParameter("@tailorImg", TailorImage);
                parameters[6].Direction = ParameterDirection.Input;
                parameters[6].DbType = DbType.String;

                parameters[7] = new SqlParameter("@tailorPriceRange", TailorPricerange);
                parameters[7].Direction = ParameterDirection.Input;
                parameters[7].DbType = DbType.String;

                parameters[8] = new SqlParameter("@stateId", TailorStateId);
                parameters[8].Direction = ParameterDirection.Input;
                parameters[8].DbType = DbType.Int16;

                parameters[9] = new SqlParameter("@tailorstatus", TailorStatus);
                parameters[9].Direction = ParameterDirection.Input;
                parameters[9].DbType = DbType.Int16;

                parameters[10] = new SqlParameter("@tailorExpertise", TailorExpertise);
                parameters[10].Direction = ParameterDirection.Input;
                parameters[10].DbType = DbType.String;

                parameters[11] = new SqlParameter("@tailorDesc", TailorDescription);
                parameters[11].Direction = ParameterDirection.Input;
                parameters[11].DbType = DbType.String;

                parameters[12] = new SqlParameter("@latitude", TailorLatitude);
                parameters[12].Direction = ParameterDirection.Input;
                parameters[12].DbType = DbType.Decimal;

                parameters[13] = new SqlParameter("@longitude", TailorLongitude);
                parameters[13].Direction = ParameterDirection.Input;
                parameters[13].DbType = DbType.Decimal;

                #region Add category mapping parameter
                DataTable tblCat = new DataTable();
                tblCat.Columns.Add("CategoryId", typeof(Guid));
                foreach (Guid CategoryId in CategoryIds)
                {
                    tblCat.Rows.Add(CategoryId);
                }
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "CategoryTableType";
                parameter.ParameterName = "@catids";
                parameter.Value = tblCat;
                parameters[14] = parameter;
                #endregion

                #region Add Style mapping parameter
                DataTable tblStl = new DataTable();
                tblStl.Columns.Add("StyleId", typeof(Guid));
                foreach (Guid StyleId in StyleIds)
                {
                    tblStl.Rows.Add(StyleId);
                }
                SqlParameter paramStyl = new SqlParameter();
                paramStyl.SqlDbType = SqlDbType.Structured;
                paramStyl.TypeName = "StyleTableType";
                paramStyl.ParameterName = "@styleids";
                paramStyl.Value = tblStl;
                parameters[15] = paramStyl;
                #endregion

                #region Add Feature mapping parameter
                DataTable tblFeature = new DataTable();
                tblFeature.Columns.Add("FeatureId", typeof(Guid));
                foreach (Guid FeatureId in FeatureIds)
                {
                    tblFeature.Rows.Add(FeatureId);
                }
                SqlParameter paramFeature = new SqlParameter();
                paramFeature.SqlDbType = SqlDbType.Structured;
                paramFeature.TypeName = "FeatureTableType";
                paramFeature.ParameterName = "@featureids";
                paramFeature.Value = tblFeature;
                parameters[16] = paramFeature;
                #endregion
                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewTailor", parameters);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
            }
        }
        public void updateTailor()
        {
            DbParameter[] parameters = new DbParameter[18];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@tailorname", TailorName);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@tailoremail", TailorEmail);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@tailorphone", TailorPhone);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.String;

                parameters[4] = new SqlParameter("@tailoraddress", TailorAddress);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.String;

                parameters[5] = new SqlParameter("@tailorCity", TailorCity);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.String;

                parameters[6] = new SqlParameter("@tailorpin", TailorPincode);
                parameters[6].Direction = ParameterDirection.Input;
                parameters[6].DbType = DbType.String;

                parameters[7] = new SqlParameter("@tailorImg", TailorImage);
                parameters[7].Direction = ParameterDirection.Input;
                parameters[7].DbType = DbType.String;

                parameters[8] = new SqlParameter("@tailorPriceRange", TailorPricerange);
                parameters[8].Direction = ParameterDirection.Input;
                parameters[8].DbType = DbType.String;

                parameters[9] = new SqlParameter("@stateId", TailorStateId);
                parameters[9].Direction = ParameterDirection.Input;
                parameters[9].DbType = DbType.Int16;

                parameters[10] = new SqlParameter("@tailorstatus", TailorStatus);
                parameters[10].Direction = ParameterDirection.Input;
                parameters[10].DbType = DbType.Int16;

                parameters[11] = new SqlParameter("@tailorExpertise", TailorExpertise);
                parameters[11].Direction = ParameterDirection.Input;
                parameters[11].DbType = DbType.String;

                parameters[12] = new SqlParameter("@tailorDesc", TailorDescription);
                parameters[12].Direction = ParameterDirection.Input;
                parameters[12].DbType = DbType.String;

                parameters[13] = new SqlParameter("@latitude", TailorLatitude);
                parameters[13].Direction = ParameterDirection.Input;
                parameters[13].DbType = DbType.Decimal;

                parameters[14] = new SqlParameter("@longitude", TailorLongitude);
                parameters[14].Direction = ParameterDirection.Input;
                parameters[14].DbType = DbType.Decimal;


                #region Add category mapping parameter
                DataTable tblCat = new DataTable();
                tblCat.Columns.Add("CategoryId", typeof(Guid));
                foreach (Guid CategoryId in CategoryIds)
                {
                    tblCat.Rows.Add(CategoryId);
                }
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "CategoryTableType";
                parameter.ParameterName = "@catids";
                parameter.Value = tblCat;
                parameters[15] = parameter;
                #endregion

                #region Add Style mapping parameter
                DataTable tblStl = new DataTable();
                tblStl.Columns.Add("StyleId", typeof(Guid));
                foreach (Guid StyleId in StyleIds)
                {
                    tblStl.Rows.Add(StyleId);
                }
                SqlParameter paramStyl = new SqlParameter();
                paramStyl.SqlDbType = SqlDbType.Structured;
                paramStyl.TypeName = "StyleTableType";
                paramStyl.ParameterName = "@styleids";
                paramStyl.Value = tblStl;
                parameters[16] = paramStyl;
                #endregion

                #region Add Feature mapping parameter
                DataTable tblFeature = new DataTable();
                tblFeature.Columns.Add("FeatureId", typeof(Guid));
                foreach (Guid FeatureId in FeatureIds)
                {
                    tblFeature.Rows.Add(FeatureId);
                }
                SqlParameter paramFeature = new SqlParameter();
                paramFeature.SqlDbType = SqlDbType.Structured;
                paramFeature.TypeName = "FeatureTableType";
                paramFeature.ParameterName = "@featureids";
                paramFeature.Value = tblFeature;
                parameters[17] = paramFeature;
                #endregion
                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateTailor", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
            }
        }
    }
}