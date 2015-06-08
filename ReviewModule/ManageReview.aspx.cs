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
    public partial class ManageReview : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TailorMaster objTailor = new TailorMaster();
                try
                {
                    DataTable dt = objTailor.getAllTailors();
                    if (dt.Rows.Count > 0)
                    {
                        ddlTaior.DataSource = dt;
                        ddlTaior.DataTextField = "TailorName";
                        ddlTaior.DataValueField = "GUID";
                        ddlTaior.DataBind();
                    }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Review objReview = new Review();
            try
            {
                if (ddlTaior.SelectedValue == "0")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select Tailor";
                }
                else if (txtReviewTitle.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter review title";
                }
                else if (txtDescription.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter description";
                }
                else
                {
                    objReview.ReviewTitle = txtReviewTitle.Text;
                    objReview.Description = txtDescription.Text;
                    objReview.Rating = Convert.ToInt32(ddlRating.SelectedValue);                    
                    objReview.ReviewStatus = 0;
                    objReview.TailorId = new Guid(ddlTaior.SelectedValue);
                    objReview.UserId = new Guid(HttpContext.Current.Session["User"].ToString());//Please add user Id here
                    objReview.saveReview();
                    lblError.Visible = true;
                    lblError.InnerHtml = "Review added successfully";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.InnerHtml = ex.Message;
            }
            finally
            {
                objReview = null;
            }
        }
    }
}