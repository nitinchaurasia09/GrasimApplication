using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.DealModule
{
    public partial class ShowAllDeals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
                bindDeals();
        }

        protected void grdDeal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    Deal deal = new Deal();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdDeal.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    deal.deleteDealByDealId(new Guid(hdnField.Value.ToString()));
                    bindDeals();
                }
                if (e.CommandName.Equals("Edit"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grdDeal.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnGUID");
                    Response.Redirect("ManageDeal.aspx?guid=" + new Guid(hdnField.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdDeal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDeal.PageIndex = e.NewPageIndex;
            grdDeal.DataBind();
            bindDeals();
        }

        protected void grdDeal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void bindDeals()
        {
            Deal deal = new Deal();
            try
            {
                grdDeal.DataSource = deal.getAllDeals();
                grdDeal.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                deal = null;
            }
        }
    }
}