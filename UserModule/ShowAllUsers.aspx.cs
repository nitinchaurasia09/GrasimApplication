using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.UserModule
{
    public partial class ShowAllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
                bindUsers();
        }

        protected void grdUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    User user = new User();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdUser.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    user.deleteUserByUserId(new Guid(hdnField.Value.ToString()));
                    bindUsers();
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdUser.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageUser.aspx?guid=" + new Guid(hdnField.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void grdUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUser.PageIndex = e.NewPageIndex;
            grdUser.DataBind();
            bindUsers();
        }

        private void bindUsers()
        {
            User user = new User();
            try
            {
                grdUser.DataSource = user.getAllUsers();
                grdUser.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                user = null;
            }
        }
    }
}