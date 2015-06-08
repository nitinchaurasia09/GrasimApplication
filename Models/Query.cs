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
    public class Query
    {
        private Guid guid;
        private string userName;
        private string userEmail;
        private string queryDescription;
        private Guid tailorId;
        private int deleteStatus;
        private DateTime createdDate;
        private int replyStatus;

        public Guid GUID
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                userEmail = value;
            }
        }
        public string QueryDescription
        {
            get
            {
                return queryDescription;
            }
            set
            {
                queryDescription = value;
            }
        }
        public Guid TailorId
        {
            get
            {
                return tailorId;
            }
            set
            {
                tailorId = value;
            }
        }        
        public int DeleteStatus
        {
            get
            {
                return deleteStatus;
            }
            set
            {
                deleteStatus = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                createdDate = value;
            }
        }
        public int ReplyStatus
        {
            get
            {
                return replyStatus;
            }
            set
            {
                replyStatus = value;
            }
        }

        public DataTable getAllQueries()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtDeal = new DataTable();
            try
            {
                dtDeal = Ado.ExecuteStoredProcedure("sp_GetAllQueries", parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                parameters = null;
                dtDeal.Dispose();
            }
            return dtDeal;
        }
        public DataTable getQueriesByQueryId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtDeal = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtDeal = Ado.ExecuteStoredProcedure("sp_GetAllQueries", parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                parameters = null;
                dtDeal.Dispose();
            }
            return dtDeal;
        }
        public void deleteQueryByQueryId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteQuery", parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                parameters = null;
            }
        }
        public void updateQueryStatusByQueryId()
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateQueryStatus", parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                parameters = null;
            }
        }
        
    }
}