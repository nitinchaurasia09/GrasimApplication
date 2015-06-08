using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.TailorModule
{
    public partial class ShowAllTailors : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindTailors();
        }

        protected void grdTailor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    TailorMaster objTailor = new TailorMaster();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdTailor.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    objTailor.deleteTailorByTailorId(new Guid(hdnField.Value.ToString()));
                    bindTailors();
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdTailor.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageTailor.aspx?tailorid=" + new Guid(hdnField.Value.ToString()));
                }
                if (e.CommandName.Equals("ManageGallery"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdTailor.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ShowGallery.aspx?tailorid=" + new Guid(hdnField.Value.ToString()));
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTailor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdTailor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTailor.PageIndex = e.NewPageIndex;
            grdTailor.DataBind();
            bindTailors();
        }

        private void bindTailors()
        {
            TailorMaster objTailor = new TailorMaster();
            try
            {
                grdTailor.DataSource = objTailor.getAllTailors();
                grdTailor.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTailor = null;
            }
        }
    }
}