using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.TailorModule
{
    public partial class ManageGallery : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                lblError.InnerHtml = "";
                if (Request.QueryString["galleryId"] != null)
                {
                    Gallery objGallery = new Gallery();
                    try
                    {

                        DataTable dt = objGallery.getGalleryByGalleryId(new Guid(Request.QueryString["galleryId"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            rdoStatus.SelectedValue = dt.Rows[0]["GalleryStatus"].ToString();
                            galleryImage.Visible = true;
                            galleryImage.ImageUrl = dt.Rows[0]["GalleryImage"].ToString();
                            ViewState["GalleryImage"] = dt.Rows[0]["GalleryImage"].ToString();
                        }

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Gallery objGallery = new Gallery();
            try
            {
                if (imgUpload.HasFile && imgUpload.PostedFile.ContentLength > 1048576)
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "File size should not be more than 1 MB";
                }
                else
                {
                    if (Request.QueryString["galleryId"] == null)
                    {

                        objGallery.GalleryStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        objGallery.GalleryImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/GalleryImages/" + imgUpload.FileName;
                        objGallery.TailorId = new Guid(Request.QueryString["tailorid"].ToString());
                        objGallery.saveGallery();
                        string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);
                        imgUpload.PostedFile.SaveAs(Server.MapPath("~/Images/GalleryImages/") + fileName);
                        lblError.Visible = true;
                        lblError.InnerHtml = "Gallery created successfully";
                    }
                    else
                    {
                        objGallery.GUID = new Guid(Request.QueryString["galleryId"].ToString());
                        objGallery.TailorId = new Guid(Request.QueryString["tailorid"].ToString());
                        objGallery.GalleryStatus = Convert.ToInt32(rdoStatus.SelectedValue);
                        if (imgUpload.FileName != "")
                            objGallery.GalleryImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/GalleryImages/" + imgUpload.FileName;
                        else
                            objGallery.GalleryImage = galleryImage.ImageUrl;
                        objGallery.updateCategory();
                        if (imgUpload.FileName != "")
                        {
                            String path = Server.MapPath(galleryImage.ImageUrl.Replace(ConfigurationManager.AppSettings["ImageUrl"].ToString(), ""));
                            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

                            string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);
                            imgUpload.PostedFile.SaveAs(Server.MapPath("~/Images/GalleryImages/") + fileName);
                        }
                        lblError.Visible = true;
                        lblError.InnerHtml = "Gallery updated successfully";
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
                objGallery = null;
            }


        }
    }
}