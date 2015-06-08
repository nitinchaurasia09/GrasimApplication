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
    public class StyleMaster
    {
        public Guid GUID
        {
            get;
            set;
        }

        public string StyleName
        {
            get;
            set;
        }

        public string StyleDescription
        {
            get;
            set;
        }

        public int StyleStatus
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

        public DataTable getAllStyles()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtStyle = new DataTable();
            try
            {
                dtStyle = Ado.ExecuteStoredProcedure("sp_GetAllStyles", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtStyle.Dispose();
            }
            return dtStyle;
        }

        public DataTable getStylesByStyleId(Guid styleId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtStyle = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@styleid", styleId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtStyle = Ado.ExecuteStoredProcedure("sp_GetAllStyles", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtStyle.Dispose();
            }
            return dtStyle;
        }

        public void deleteStyleByStyleId(Guid styleId)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@styleid", styleId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteStyle", parameters);
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

        public void saveStyle()
        {
            DbParameter[] parameters = new DbParameter[3];
            try
            {
                parameters[0] = new SqlParameter("@stylename", StyleName);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@styledesc", StyleDescription);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@stylestatus", StyleStatus);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewStyle", parameters);
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

        public void updateStyle()
        {
            DbParameter[] parameters = new DbParameter[4];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@stylename", StyleName);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@styledesc", StyleDescription);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@stylestatus", StyleStatus);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateStyle", parameters);
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

        public DataTable getTailorStyleMapping(Guid tailorId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtStyle = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@tailorId", tailorId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtStyle = Ado.ExecuteStoredProcedure("sp_GetTailorStyleMapping", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtStyle.Dispose();
            }
            return dtStyle;
        }
    }
}