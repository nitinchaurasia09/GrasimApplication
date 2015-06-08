using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.StyleModule
{
    public partial class ShowAllStyles : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindStyles();
        }

        protected void grdStyle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    StyleMaster styl = new StyleMaster();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdStyle.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    styl.deleteStyleByStyleId(new Guid(hdnField.Value.ToString()));
                    bindStyles();
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdStyle.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageStyle.aspx?styleid=" + new Guid(hdnField.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdStyle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void grdStyle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStyle.PageIndex = e.NewPageIndex;
            grdStyle.DataBind();
            bindStyles();
        }
        private void bindStyles()
        {
            StyleMaster styl = new StyleMaster();
            try
            {
                grdStyle.DataSource = styl.getAllStyles();
                grdStyle.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                styl = null;
            }
        }
    }
}