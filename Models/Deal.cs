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
    public class Deal
    {
        private Guid guid;
        private int dealPercentage;
        private string dealDescription;
        private Guid tailorId;
        private int dealStatus;
        private int deleteStatus;
        private DateTime createdDt;

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
        public int DealPercentage
        {
            get
            {
                return dealPercentage;
            }
            set
            {
                dealPercentage = value;
            }
        }
        public string DealDescription
        {
            get
            {
                return dealDescription;
            }
            set
            {
                dealDescription = value;
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
        public int DealStatus
        {
            get
            {
                return dealStatus;
            }
            set
            {
                dealStatus = value;
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
        public DateTime CreatedDt
        {
            get
            {
                return createdDt;
            }
            set
            {
                createdDt = value;
            }
        }

        public DataTable getAllDeals()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtDeal = new DataTable();
            try
            {
                dtDeal = Ado.ExecuteStoredProcedure("sp_GetAllDeals", parameters);
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
        public DataTable getDealsByDealId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtDeal = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtDeal = Ado.ExecuteStoredProcedure("sp_GetAllDeals", parameters);
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
        public void deleteDealByDealId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteDeal", parameters);
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
        public void saveDeal()
        {
            DbParameter[] parameters = new DbParameter[4];
            try
            {
                parameters[0] = new SqlParameter("@dealPercentage", DealPercentage);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@dealDescription", DealDescription);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@dealStatus", DealStatus);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Int32;

                parameters[3] = new SqlParameter("@tailorId", TailorId);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Guid;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewDeal", parameters);
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
        public void updateDeal()
        {
            DbParameter[] parameters = new DbParameter[5];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                
                parameters[1] = new SqlParameter("@dealPercentage", DealPercentage);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.Int32;

                parameters[2] = new SqlParameter("@dealDescription", DealDescription);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@dealStatus", DealStatus);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Int32;

                parameters[4] = new SqlParameter("@tailorId", TailorId);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.Guid;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateDeal", parameters);
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