using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.PageModule
{
    public partial class ManagePage : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            StaticPage objPage = new StaticPage();
            try
            {
                if (txtDescription.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Description";
                }
                else
                {
                    objPage.Description = txtDescription.Text;
                    objPage.GUID = Convert.ToInt16(ddlPageName.SelectedValue);
                    objPage.savePage();
                    lblError.Visible = true;
                    lblError.InnerHtml = "Page created successfully";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPage = null;
            }

        }

        protected void ddlPageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StaticPage objPage = new StaticPage();
            try
            {
                DataTable dt = objPage.getPageDescription(Convert.ToInt16(ddlPageName.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPage = null;
            }
        }
    }
}