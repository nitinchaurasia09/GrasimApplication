using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.CategoryModule
{
    public partial class ShowAllCategories : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindCategories();
        }

        protected void grdCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    Category cat = new Category();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdCategory.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");

                    cat.deleteCategoryByCatId(new Guid(hdnField.Value.ToString()));
                    String path = Server.MapPath(row.Cells[3].Text.Replace("..", "").ToString());
                    if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
                    bindCategories();
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdCategory.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageCategory.aspx?catid=" + new Guid(hdnField.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void bindCategories()
        {
            Category cat = new Category();
            try
            {
                grdCategory.DataSource = cat.getAllCategories();
                grdCategory.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cat = null;
            }
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            grdCategory.DataBind();
            bindCategories();
        }
    }
}