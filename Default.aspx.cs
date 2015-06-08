using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using GrasimApplication.App_Code;
using System.Data;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using GrasimApplication.Models.Security;

namespace GrasimApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty)
            {
                lblError.Visible = true;
                lblError.InnerHtml = "Please enter User Name";
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                lblError.Visible = true;
                lblError.InnerHtml = "Please enter Password";
            }
            else
            {
                Models.User objUser = new Models.User();
                DataTable dt = objUser.getUsersForLogin(txtUserName.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    if (txtPassword.Text.Trim() == dt.Rows[0]["Password"].ToString())
                    //if (PasswordHash.ValidatePassword(txtPassword.Text.Trim(), dt.Rows[0]["Password"].ToString()))
                    {
                        SystemSession.UserID = new Guid(dt.Rows[0]["GUID"].ToString());
                        FormsAuthentication.SetAuthCookie(dt.Rows[0]["UserName"].ToString(), false);
                        FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                        HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                        if (authCookie != null)
                        {
                            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                            var newUser = new CustomPrincipal(authTicket.Name)
                            {
                                UserId = new Guid(dt.Rows[0]["GUID"].ToString()),
                                UserName = dt.Rows[0]["UserName"].ToString(),
                                FirstName = dt.Rows[0]["FirstName"].ToString(),
                                LastName = dt.Rows[0]["LastName"].ToString()
                            };
                            HttpContext.Current.User = newUser;
                        }
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            HttpContext.Current.Session["User"] = dt.Rows[0]["GUID"].ToString();
                            if (Request.QueryString["ReturnUrl"] == null)
                            {
                                Response.Redirect("~/HomeModule/ControlPanelHome.aspx");
                            }
                            else
                            {
                                Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
                            }
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.InnerHtml = "Invalid UserName/Password. Please contact Administrator";
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Invalid UserName/Password. Please contact Administrator";
                }


            }
        }
    }
}