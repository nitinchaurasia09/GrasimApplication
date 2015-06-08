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
    public class Review
    {
        public Guid GUID
        {
            get;
            set;
        }
        public string ReviewTitle
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int Rating
        {
            get;
            set;
        }       
        public int ReviewStatus
        {
            get;
            set;
        }
        public Guid TailorId
        {
            get;
            set;
        }
        public Guid UserId
        {
            get;
            set;
        }

        public DataTable getAllReviews()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtReview = new DataTable();
            try
            {
                dtReview = Ado.ExecuteStoredProcedure("sp_GetTailorsReview", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtReview.Dispose();
            }
            return dtReview;
        }
        public void updateReviewPublishing(int Publishing)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@publishing", Publishing);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateReviewPublishStatus", parameters);
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
        public void updateStatus()
        {
            DbParameter[] parameters = new DbParameter[2];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@status", ReviewStatus);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateReviewStatus", parameters);
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
        public void saveReview()
        {
            DbParameter[] parameters = new DbParameter[6];
            try
            {
                parameters[0] = new SqlParameter("@ReviewTitle", ReviewTitle);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@Description", Description);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@Rating", Rating);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Int32;

                parameters[3] = new SqlParameter("@ReviewStatus", ReviewStatus);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Int32;

                parameters[4] = new SqlParameter("@TailorId", TailorId);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.Guid;

                parameters[5] = new SqlParameter("@UserId", UserId);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.Guid;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewTailorReview", parameters);
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