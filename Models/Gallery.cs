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
    public class Gallery
    {

        public Guid GUID
        {
            get;
            set;
        }
        public string GalleryImage
        {
            get;
            set;
        }
        public Guid TailorId
        {
            get;
            set;
        }
        public int GalleryStatus
        {
            get;
            set;
        }
        public int DeleteStatus
        {
            get;
            set;
        }

        public DataTable getGalleryByTailorId(Guid tlrId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtTlrGallery = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", tlrId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtTlrGallery = Ado.ExecuteStoredProcedure("sp_GetTailorsGallery", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtTlrGallery.Dispose();
            }
            return dtTlrGallery;
        }
        public DataTable getGalleryByGalleryId(Guid glryId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtTlrGallery = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", glryId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtTlrGallery = Ado.ExecuteStoredProcedure("sp_GetAllTailorGallery", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtTlrGallery.Dispose();
            }
            return dtTlrGallery;
        }
        public void deleteGalleryByGalleryId(Guid glryId)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", glryId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteTailorGallery", parameters);
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
        public void saveGallery()
        {
            DbParameter[] parameters = new DbParameter[3];
            try
            {
                parameters[0] = new SqlParameter("@GalleryImage", GalleryImage);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@TailorId", TailorId);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.Guid;

                parameters[2] = new SqlParameter("@GalleryStatus", GalleryStatus);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddTailorGallery", parameters);
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
        public void updateCategory()
        {
            DbParameter[] parameters = new DbParameter[4];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@GalleryImage", GalleryImage);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@TailorId", TailorId);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Guid;

                parameters[3] = new SqlParameter("@GalleryStatus", GalleryStatus);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Int32;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateTailorGallery", parameters);
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