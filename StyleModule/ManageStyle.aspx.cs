using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.StyleModule
{
    public partial class ManageStyle : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["styleid"] != null)
                {
                    StyleMaster objStlMst = new StyleMaster();
                    try
                    {
                        DataTable dt = objStlMst.getStylesByStyleId(new Guid(Request.QueryString["styleid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            txtStyleName.Text = dt.Rows[0]["StyleName"].ToString();
                            txtDescription.Text = dt.Rows[0]["StyleDescription"].ToString();
                            rdoStatus.SelectedValue = dt.Rows[0]["StyleStatus"].ToString();
                            ViewState["StyleImage"] = dt.Rows[0]["CategoryImage"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objStlMst = null;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StyleMaster objStlMst = new StyleMaster();
            try
            {
                if (txtStyleName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Style Name";
                }
                else
                {
                    if (Request.QueryString["styleid"] == null)
                    {
                        objStlMst.StyleName = txtStyleName.Text;
                        objStlMst.StyleDescription = txtDescription.Text;
                        objStlMst.StyleStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        objStlMst.saveStyle();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Style created successfully";
                    }
                    else
                    {
                        objStlMst.GUID = new Guid(Request.QueryString["styleid"].ToString());
                        objStlMst.StyleName = txtStyleName.Text;
                        objStlMst.StyleDescription = txtDescription.Text;
                        objStlMst.StyleStatus = Convert.ToInt32(rdoStatus.SelectedValue);

                        objStlMst.updateStyle();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Style updated successfully";
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
                objStlMst = null;
            }
        }
    }
}