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
    public class Country
    {
        public Guid GUID
        {
            get;
            set;
        }
        public string CountryName
        {
            get;
            set;
        }
        public string StateName
        {
            get;
            set;
        }

        public DataTable getAllCountries()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtCountry = new DataTable();
            try
            {
                dtCountry = Ado.ExecuteStoredProcedure("sp_GetAllCountries", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtCountry.Dispose();
            }
            return dtCountry;
        }

        public DataTable getStatebyCountryId(int countryId)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtStates = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@countryId", countryId);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Int16 ;
                dtStates = Ado.ExecuteStoredProcedure("sp_GetAllStates", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtStates.Dispose();
            }
            return dtStates;
        }
    }
}