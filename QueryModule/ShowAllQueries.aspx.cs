using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.QueryModule
{
    public partial class ShowAllQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
                bindQueries();
        }

        protected void grdQuery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    Query query = new Query();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdQuery.Rows[index];

                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    query.deleteQueryByQueryId(new Guid(hdnField.Value.ToString()));
                    bindQueries();
                }
                if (e.CommandName.Equals("View"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdQuery.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageQuery.aspx?guid=" + new Guid(hdnField.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdQuery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuery.PageIndex = e.NewPageIndex;
            grdQuery.DataBind();
            bindQueries();
        }

        protected void grdQuery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void bindQueries()
        {
            Query query = new Query();
            try
            {
                grdQuery.DataSource = query.getAllQueries();
                grdQuery.DataBind();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                query = null;
            }
        }
    }
}