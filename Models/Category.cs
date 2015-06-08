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
    public class Category
    {

        public Guid GUID
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }

        public string CategoryDescription
        {
            get;
            set;
        }

        public string CategoryImage
        {
            get;
            set;
        }

        public int CategoryStatus
        {
            get;
            set;
        }

        public int DeleteStatus
        {
            get;
            set;
        }

        public Guid FeatureId
        {
            get;
            set;
        }

        public DataTable getAllCategories()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtCategory = new DataTable();
            try
            {
                dtCategory = Ado.ExecuteStoredProcedure("sp_GetAllCategories", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtCategory.Dispose();
            }
            return dtCategory;
        }

        public DataTable getCategoriesByCatId(Guid categoryId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtCategory = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@catid", categoryId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtCategory = Ado.ExecuteStoredProcedure("sp_GetAllCategories", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtCategory.Dispose();
            }
            return dtCategory;
        }


        public DataTable getCategoriesByFeatureId(List<Guid> featureIds, DataTable dtResult)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtCategory = new DataTable();
            try
            {
                if (dtResult != null)
                    dtResult.Rows.Clear();
                foreach (Guid featureId in featureIds)
                {
                    parameters[0] = new SqlParameter("@featureid", featureId);
                    parameters[0].Direction = ParameterDirection.Input;
                    parameters[0].DbType = DbType.Guid;
                    dtCategory = Ado.ExecuteStoredProcedure("sp_GetCategoriesByFeature", parameters);
                    if (dtResult == null)
                    {
                        dtResult = new DataTable();
                        dtResult = dtCategory.Clone();
                    }
                    foreach (DataRow dr in dtCategory.Rows)
                    {
                        dtResult.ImportRow(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtCategory.Dispose();
            }

            return dtResult;
        }


        public void deleteCategoryByCatId(Guid categoryId)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@catid", categoryId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteCategory", parameters);
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

        public void saveCategory()
        {
            DbParameter[] parameters = new DbParameter[5];
            try
            {
                parameters[0] = new SqlParameter("@catname", CategoryName);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@catdesc", CategoryDescription);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@catstatus", CategoryStatus);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.Int32;

                parameters[3] = new SqlParameter("@catimage", CategoryImage);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.String;

                parameters[4] = new SqlParameter("@featId", FeatureId);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.Guid;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewCategory", parameters);
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
            DbParameter[] parameters = new DbParameter[6];
            try
            {
                parameters[0] = new SqlParameter("@guid", GUID);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@catname", CategoryName);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@catdesc", CategoryDescription);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@catstatus", CategoryStatus);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.Int32;

                parameters[4] = new SqlParameter("@catimage", CategoryImage);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.String;

                parameters[5] = new SqlParameter("@featId", FeatureId);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.Guid;


                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateCategory", parameters);
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

        public DataTable getTailorCategoryMapping(Guid tailorId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtCat = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@tailorId", tailorId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtCat = Ado.ExecuteStoredProcedure("sp_GetTailorCategoryMapping", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtCat.Dispose();
            }
            return dtCat;
        }
    }
}