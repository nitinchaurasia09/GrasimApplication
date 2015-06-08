using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.ReviewModule
{
    public partial class ShowAllReviews : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindReview();
        }

        protected void grdReview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Review objRev = new Review();
            try
            {
                if (e.CommandName.Equals("Approve"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdReview.Rows[index];

                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    objRev.GUID = new Guid(hdnField.Value.ToString());

                    objRev.ReviewStatus = 0;
                    objRev.updateStatus();
                    lblError.Visible = true;
                    lblError.InnerHtml = "Review approved successfully";
                }
                if (e.CommandName.Equals("Reject"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdReview.Rows[index];

                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    objRev.GUID = new Guid(hdnField.Value.ToString());
                    objRev.ReviewStatus = 1;
                    objRev.updateStatus();
                    lblError.InnerHtml = "Review rejected successfully";
                }
                bindReview();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRev = null;
            }
        }

        protected void grdReview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdReview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReview.PageIndex = e.NewPageIndex;
            grdReview.DataBind();
            bindReview();
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            Review objReview = new Review();
            try
            {
                objReview.updateReviewPublishing(Convert.ToInt32(ddlPublish.SelectedValue));
                bindReview();
                lblError.Visible = true;
                lblError.InnerHtml = "Status published successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objReview = null;
            }
        }

        private void bindReview()
        {
            Review objReview = new Review();
            DataTable dtReview = new DataTable();
            try
            {
                dtReview = objReview.getAllReviews();
                grdReview.DataSource = dtReview;
                grdReview.DataBind();
                if (dtReview.Rows.Count > 0)
                {
                    ddlPublish.SelectedValue = Convert.ToString(dtReview.Rows[0]["Publishing"].ToString() == "Manual" ? 1 : 0);
                    if (dtReview.Rows[0]["Publishing"].ToString() == "Manual")
                    {
                        grdReview.Columns[6].Visible = true;
                        grdReview.Columns[7].Visible = true;
                    }
                    else
                    {
                        grdReview.Columns[6].Visible = false;
                        grdReview.Columns[7].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objReview = null;
                dtReview.Dispose();
            }
        }
    }
}