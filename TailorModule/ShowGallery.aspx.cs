using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.TailorModule
{
    public partial class ShowGallery : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.QueryString["tailorid"] != null)
                {
                    bindTailorGallery(new Guid(Request.QueryString["tailorid"].ToString()));
                }
            }
        }

        protected void grdGallery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    Gallery objGallery = new Gallery();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdGallery.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    objGallery.deleteGalleryByGalleryId(new Guid(hdnField.Value.ToString()));
                    bindTailorGallery(new Guid(row.Cells[0].Text.ToString()));
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdGallery.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageGallery.aspx?galleryId=" + new Guid(hdnField.Value.ToString()) + "&tailorid=" + Request.QueryString["tailorid"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdGallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGallery.PageIndex = e.NewPageIndex;
            grdGallery.DataBind();
            bindTailorGallery(new Guid(Request.QueryString["tailorid"].ToString()));
        }

        private void bindTailorGallery(Guid tailorId)
        {
            Gallery objGallery = new Gallery();
            try
            {
                grdGallery.DataSource = objGallery.getGalleryByTailorId(tailorId);
                grdGallery.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGallery = null;
            }
        }
    }
}