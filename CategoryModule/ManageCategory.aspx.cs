using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.CategoryModule
{
    public partial class ManageCategory : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFeatures();
                lblError.Visible = false;
                lblError.InnerHtml = "";
                if (Request.QueryString["catid"] != null)
                {
                    Category cat = new Category();
                    try
                    {

                        DataTable dt = cat.getCategoriesByCatId(new Guid(Request.QueryString["catid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            txtCatName.Text = dt.Rows[0]["CategoryName"].ToString();
                            txtDescription.Text = dt.Rows[0]["CategoryDescription"].ToString();
                            rdoStatus.SelectedValue = dt.Rows[0]["CategoryStatus"].ToString();
                            ddlFeature.SelectedValue = dt.Rows[0]["FeatureId"].ToString();
                            catImage.Visible = true;
                            if (dt.Rows[0]["CategoryImage"].ToString() != "../Images/CategoryImages/" && dt.Rows[0]["CategoryImage"].ToString() != "")
                                catImage.ImageUrl = dt.Rows[0]["CategoryImage"].ToString();
                            else
                                catImage.ImageUrl = "../Images/CategoryImages/noimage.png";

                            ViewState["CatImage"] = dt.Rows[0]["CategoryImage"].ToString();
                        }

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
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Category objAddNewCat = new Category();
            try
            {
                if (txtCatName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter Category Name";
                }
                else if (imgUpload.HasFile && imgUpload.PostedFile.ContentLength > 1048576)
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "File size should not be more than 1 MB";
                }
                else
                {
                    if (Request.QueryString["catid"] == null)
                    {
                        objAddNewCat.CategoryName = txtCatName.Text;
                        objAddNewCat.CategoryDescription = txtDescription.Text;
                        objAddNewCat.CategoryStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        objAddNewCat.CategoryImage = imgUpload.FileName;
                        objAddNewCat.FeatureId = new Guid(ddlFeature.SelectedValue);
                        objAddNewCat.saveCategory();
                        if (imgUpload.FileName != "")
                        {
                            string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);
                            imgUpload.PostedFile.SaveAs(Server.MapPath("~/Images/CategoryImages/") + fileName);
                        }
                        lblError.Visible = true;
                        lblError.InnerHtml = "Category created successfully";
                    }
                    else
                    {
                        objAddNewCat.GUID = new Guid(Request.QueryString["catid"].ToString());
                        objAddNewCat.CategoryName = txtCatName.Text;
                        objAddNewCat.CategoryDescription = txtDescription.Text;
                        objAddNewCat.CategoryStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        if (imgUpload.FileName != "")
                            objAddNewCat.CategoryImage = imgUpload.FileName;
                        else
                            objAddNewCat.CategoryImage = catImage.ImageUrl.Replace("../Images/CategoryImages/", "");
                        objAddNewCat.updateCategory();
                        if (imgUpload.FileName != "")
                        {
                            if (ViewState["CatImage"].ToString() != "../Images/CategoryImages/noimage.png")
                            {
                                String path = Server.MapPath(ViewState["CatImage"].ToString().Replace("..", ""));
                                if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
                            }
                            string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);
                            imgUpload.PostedFile.SaveAs(Server.MapPath("~/Images/CategoryImages/") + fileName);
                        }
                        lblError.Visible = true;
                        lblError.InnerHtml = "Category updated successfully";
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
                objAddNewCat = null;
            }


        }

        private void bindFeatures()
        {
            Feature feature = new Feature();
            try
            {
                ddlFeature.DataSource = feature.getAllFeatures();
                ddlFeature.DataValueField = "GUID";
                ddlFeature.DataTextField = "FeatureName";
                ddlFeature.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                feature = null;
            }
        }
    }
}