using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.DealModule
{
    public partial class ManageDeal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
            {               
                TailorMaster objTailorMaster = new TailorMaster();                
                ddlTailor.DataTextField = "TailorName";
                ddlTailor.DataValueField = "GUID";
                ddlTailor.DataSource = objTailorMaster.getAllTailors();
                ddlTailor.DataBind();
                if (Request.QueryString["guid"] != null)
                {
                    Deal deal = new Deal();
                    try
                    {

                        DataTable dt = deal.getDealsByDealId(new Guid(Request.QueryString["guid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            txtDealPercentage.Text = dt.Rows[0]["DealPercentage"].ToString();
                            txtDealDescription.Text = dt.Rows[0]["DealDescription"].ToString();
                            rdoStatus.SelectedValue = dt.Rows[0]["DealStat"].ToString();
                            ddlTailor.SelectedValue = dt.Rows[0]["TailorId"].ToString();
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        deal = null;
                    }
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Deal objAddNewDeal = new Deal();
            try
            {
                if (txtDealPercentage.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Deal Percentage";
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(txtDealPercentage.Text, "^[0-9]*$"))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Deal Percentage in numbers only";
                }
                else if (txtDealDescription.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Deal Description";
                }
                else
                {
                    if (Request.QueryString["guid"] == null)
                    {
                        objAddNewDeal.DealPercentage = Convert.ToInt32(txtDealPercentage.Text);
                        objAddNewDeal.DealDescription = txtDealDescription.Text;
                        objAddNewDeal.DealStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        objAddNewDeal.TailorId = new Guid(ddlTailor.SelectedValue);
                        objAddNewDeal.saveDeal();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Deal created successfully";
                    }
                    else
                    {
                        objAddNewDeal.GUID = new Guid(Request.QueryString["guid"].ToString());
                        objAddNewDeal.DealPercentage = Convert.ToInt32(txtDealPercentage.Text);
                        objAddNewDeal.DealDescription = txtDealDescription.Text;
                        objAddNewDeal.DealStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        objAddNewDeal.TailorId = new Guid(ddlTailor.SelectedValue);
                        objAddNewDeal.updateDeal();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Deal updated successfully";
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
                objAddNewDeal = null;
            }


        }
    }
}