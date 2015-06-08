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
    public class StaticPage
    {
        public int GUID
        {
            get;
            set;
        }
        public string PageName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }

        public DataTable getPageDescription(int pageId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtPage = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@pageId", pageId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Int16;
                dtPage = Ado.ExecuteStoredProcedure("sp_GetStaticPageDetail", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtPage.Dispose();
            }
            return dtPage;
        }
        public void savePage()
        {
            DbParameter[] parameters = new DbParameter[2];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Int16;

                parameters[1] = new SqlParameter("@desc", Description);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateStaticPage", parameters);
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