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
    public class Feature
    {
        public Guid GUID
        {
            get;
            set;
        }
        public string FeatureName
        {
            get;
            set;
        }

        public DataTable getAllFeatures()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtFeature = new DataTable();
            try
            {
                dtFeature = Ado.ExecuteStoredProcedure("sp_GetAllFeatures", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtFeature.Dispose();
            }
            return dtFeature;
        }

        public DataTable getTailorFeatureMapping(Guid tailorId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtFeature = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@tailorId", tailorId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtFeature = Ado.ExecuteStoredProcedure("sp_GetTailorFeatureMapping", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtFeature.Dispose();
            }
            return dtFeature;
        }
    }
}