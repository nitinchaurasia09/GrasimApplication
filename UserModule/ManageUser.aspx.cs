using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using GrasimApplication.App_Code;
using System.Configuration;

namespace GrasimApplication.UserModule
{
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
            {
                lblError.Visible = false;
                lblError.InnerHtml = "";
                divPassword.Visible = true;
                if (Request.QueryString["guid"] != null)
                {
                    User user = new User();
                    try
                    {

                        DataTable dt = user.getUsersByUserId(new Guid(Request.QueryString["guid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                            txtUserEmail.Text = dt.Rows[0]["UserEmail"].ToString();
                            txtUserPhone.Text = dt.Rows[0]["UserPhone"].ToString();
                            txtUserLocation.Text = dt.Rows[0]["UserLocation"].ToString();
                            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                            imgUser.Visible = true;
                            imgUser.ImageUrl = dt.Rows[0]["UserImage"].ToString();
                            rdoIsAdmin.SelectedValue = dt.Rows[0]["IsAdmin"].ToString();
                            rdoUserStatus.SelectedValue = dt.Rows[0]["UserStat"].ToString();
                            divPassword.Visible = false;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        user = null;
                    }
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User objAddNewUser = new User();
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter User Name";
                }
                else if (string.IsNullOrWhiteSpace(txtUserEmail.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter User Email";
                }
                else if (string.IsNullOrWhiteSpace(txtUserPhone.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter User Phone";
                }
                else if (string.IsNullOrWhiteSpace(txtUserLocation.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter User Location";
                }
                else if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter First Name";
                }
                else if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Last Name";
                }
                else if (divPassword.Visible && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Password";
                }
                else
                {
                    if (Request.QueryString["guid"] == null)
                    {
                        objAddNewUser.UserName = txtUserName.Text;
                        objAddNewUser.UserEmail = txtUserEmail.Text;
                        objAddNewUser.UserPhone = txtUserPhone.Text;
                        objAddNewUser.UserLocation = txtUserLocation.Text;
                        objAddNewUser.FirstName = txtFirstName.Text;
                        objAddNewUser.LastName = txtLastName.Text;
                        objAddNewUser.Password = txtPassword.Text;// PasswordHash.CreateHash(txtPassword.Text);
                        objAddNewUser.IsAdmin = Convert.ToInt32(rdoIsAdmin.SelectedValue);
                        objAddNewUser.UserStatus = Convert.ToInt32(rdoUserStatus.SelectedValue);

                        if (flUserImage.FileName != "")
                        {
                            string fileName = Path.GetFileName(flUserImage.PostedFile.FileName);
                            flUserImage.PostedFile.SaveAs(Server.MapPath("~/Images/UserImages/") + fileName);
                            objAddNewUser.UserImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/UserImages/" + flUserImage.FileName;
                        }
                        else
                            objAddNewUser.UserImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/UserImages/" + "noimage.png";


                        objAddNewUser.saveUser();
                        lblError.Visible = true;
                        lblError.InnerHtml = "User created successfully";
                    }
                    else
                    {
                        objAddNewUser.GUID = new Guid(Request.QueryString["guid"].ToString());
                        objAddNewUser.UserName = txtUserName.Text;
                        objAddNewUser.UserEmail = txtUserEmail.Text;
                        objAddNewUser.UserPhone = txtUserPhone.Text;
                        objAddNewUser.UserLocation = txtUserLocation.Text;
                        objAddNewUser.FirstName = txtFirstName.Text;
                        objAddNewUser.LastName = txtLastName.Text;
                        objAddNewUser.IsAdmin = Convert.ToInt32(rdoIsAdmin.SelectedValue);
                        objAddNewUser.UserStatus = Convert.ToInt32(rdoUserStatus.SelectedValue);

                        if (flUserImage.FileName != "")
                        {
                            String path = Server.MapPath(flUserImage.FileName.Replace(ConfigurationManager.AppSettings["ImageUrl"].ToString(), ""));
                            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

                            string fileName = Path.GetFileName(flUserImage.PostedFile.FileName);
                            flUserImage.PostedFile.SaveAs(Server.MapPath("~/Images/UserImages/") + fileName);
                            objAddNewUser.UserImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/UserImages/" + flUserImage.FileName;
                        }
                        else
                            objAddNewUser.UserImage = imgUser.ImageUrl == "" ? ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/UserImages/" + "noimage.png" : imgUser.ImageUrl;

                        objAddNewUser.updateUser();
                        lblError.Visible = true;
                        lblError.InnerHtml = "User updated successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.InnerHtml = ex.Message;
            }
            finally
            {
                objAddNewUser = null;
            }
        }
    }
}