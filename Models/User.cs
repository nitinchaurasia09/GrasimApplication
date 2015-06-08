using BusinessWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GrasimApplication.Models;
using GrasimApplication.App_Code;

namespace GrasimApplication.Models
{
    public class User
    {
        private Guid guid;
        private string userName;
        private string userEmail;
        private string userPhone;
        private string userLocation;
        private string firstName;
        private string lastName;
        private string password;
        private string userImage;
        private int isAdmin;
        private DateTime createdDate;
        private int deleteStatus;
        private int userStatus;

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

        public string UserImage
        {
            get
            {
                return userImage;
            }
            set
            {
                userImage = value;
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

        public string UserPhone
        {
            get
            {
                return userPhone;
            }
            set
            {
                userPhone = value;
            }
        }

        public string UserLocation
        {
            get
            {
                return userLocation;
            }
            set
            {
                userLocation = value;
            }
        }
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public int IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
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

        public int UserStatus
        {
            get
            {
                return userStatus;
            }
            set
            {
                userStatus = value;
            }
        }

        public DataTable getAllUsers()
        {
            DbParameter[] parameters = new DbParameter[1];
            parameters = null;
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = Ado.ExecuteStoredProcedure("sp_GetAllUsers", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtUser.Dispose();
            }
            return dtUser;
        }

        public DataTable getUsersByUserId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtUser = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                dtUser = Ado.ExecuteStoredProcedure("sp_GetAllUsers", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtUser.Dispose();
            }
            return dtUser;
        }

        public void deleteUserByUserId(Guid guid)
        {
            DbParameter[] parameters = new DbParameter[1];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;
                Ado.ExecuteNonQueryStoredProcedure("sp_DeleteUser", parameters);
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

        public void saveUser()
        {
            DbParameter[] parameters = new DbParameter[10];
            try
            {
                parameters[0] = new SqlParameter("@userName", userName);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;

                parameters[1] = new SqlParameter("@userEmail", userEmail);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@userPhone", userPhone);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@userLocation", userLocation);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.String;

                parameters[4] = new SqlParameter("@firstName", firstName);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.String;

                parameters[5] = new SqlParameter("@lastName", lastName);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.String;

                parameters[6] = new SqlParameter("@password", password);
                parameters[6].Direction = ParameterDirection.Input;
                parameters[6].DbType = DbType.String;

                parameters[7] = new SqlParameter("@isAdmin", isAdmin);
                parameters[7].Direction = ParameterDirection.Input;
                parameters[7].DbType = DbType.Int32;

                parameters[8] = new SqlParameter("@userStatus", userStatus);
                parameters[8].Direction = ParameterDirection.Input;
                parameters[8].DbType = DbType.Int32;

                parameters[9] = new SqlParameter("@userImage", UserImage);
                parameters[9].Direction = ParameterDirection.Input;
                parameters[9].DbType = DbType.String;

                Ado.ExecuteNonQueryStoredProcedure("sp_AddNewUser", parameters);
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

        public void updateUser()
        {
            DbParameter[] parameters = new DbParameter[11];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@userName", userName);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@userEmail", userEmail);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                parameters[3] = new SqlParameter("@userPhone", userPhone);
                parameters[3].Direction = ParameterDirection.Input;
                parameters[3].DbType = DbType.String;

                parameters[4] = new SqlParameter("@userLocation", userLocation);
                parameters[4].Direction = ParameterDirection.Input;
                parameters[4].DbType = DbType.String;

                parameters[5] = new SqlParameter("@firstName", firstName);
                parameters[5].Direction = ParameterDirection.Input;
                parameters[5].DbType = DbType.String;

                parameters[6] = new SqlParameter("@lastName", lastName);
                parameters[6].Direction = ParameterDirection.Input;
                parameters[6].DbType = DbType.String;

                parameters[7] = new SqlParameter("@password", password);
                parameters[7].Direction = ParameterDirection.Input;
                parameters[7].DbType = DbType.String;

                parameters[8] = new SqlParameter("@isAdmin", isAdmin);
                parameters[8].Direction = ParameterDirection.Input;
                parameters[8].DbType = DbType.Int32;

                parameters[9] = new SqlParameter("@userStatus", userStatus);
                parameters[9].Direction = ParameterDirection.Input;
                parameters[9].DbType = DbType.Int32;


                parameters[10] = new SqlParameter("@userImage", UserImage);
                parameters[10].Direction = ParameterDirection.Input;
                parameters[10].DbType = DbType.String;


                Ado.ExecuteNonQueryStoredProcedure("sp_UpdateUser", parameters);
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
        
        public DataTable getUsersForLogin(string userName)
        {
            DbParameter[] parameters = new DbParameter[1];
            DataTable dtUser = new DataTable();
            try
            {
                parameters[0] = new SqlParameter("@userName", userName);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.String;
                dtUser = Ado.ExecuteStoredProcedure("sp_GetUsersForLogin", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                parameters = null;
                dtUser.Dispose();
            }
            return dtUser;
        }

        public void updatePassword(string OldPassword)
        {
            DbParameter[] parameters = new DbParameter[3];
            try
            {
                parameters[0] = new SqlParameter("@guid", guid);
                parameters[0].Direction = ParameterDirection.Input;
                parameters[0].DbType = DbType.Guid;

                parameters[1] = new SqlParameter("@password", password);
                parameters[1].Direction = ParameterDirection.Input;
                parameters[1].DbType = DbType.String;

                parameters[2] = new SqlParameter("@oldpassword", OldPassword);
                parameters[2].Direction = ParameterDirection.Input;
                parameters[2].DbType = DbType.String;

                Ado.ExecuteNonQueryStoredProcedure("sp_UpdatePassword", parameters);
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