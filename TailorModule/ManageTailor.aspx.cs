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
    public partial class ManageTailor : AuthenticationBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindStyles();
                bindCountries();
                bindFeatures();

                if (Request.QueryString["tailorid"] != null)
                {
                    TailorMaster objTailor = new TailorMaster();
                    StyleMaster objStyle = new StyleMaster();
                    Category objCategory = new Category();
                    Feature objFeature = new Feature();
                    try
                    {

                        DataTable dt = objTailor.getTailorByTailorId(new Guid(Request.QueryString["tailorid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            txtTailorName.Text = dt.Rows[0]["TailorName"].ToString();
                            txtEmail.Text = dt.Rows[0]["TailorEmail"].ToString();
                            txtPhone.Text = dt.Rows[0]["TailorPhone"].ToString();
                            txtAddress.Text = dt.Rows[0]["TailorAddress"].ToString();
                            txtCity.Text = dt.Rows[0]["TailorCity"].ToString();
                            txtPin.Text = dt.Rows[0]["TailorPinCode"].ToString();
                            imgTailor.Visible = true;
                            imgTailor.ImageUrl = dt.Rows[0]["TailorImage"].ToString();
                            txtPriceRange.Text = dt.Rows[0]["TailorPriceRange"].ToString();
                            ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                            bindStates(Convert.ToInt16(ddlCountry.SelectedValue));
                            ddlState.SelectedValue = dt.Rows[0]["TailorStateId"].ToString();
                            rdoStatus.SelectedValue = dt.Rows[0]["TailorStatus"].ToString();
                            txtExpertise.Text = dt.Rows[0]["TailorExpertise"].ToString();
                            txtDescription.Text = dt.Rows[0]["TailorDescription"].ToString();
                            txtLatitude.Text = dt.Rows[0]["latitude"].ToString();
                            txtLongitude.Text = dt.Rows[0]["longitude"].ToString();
                            ViewState["TailorImage"] = dt.Rows[0]["TailorImage"].ToString();

                            #region Map Style with Tailor
                            DataTable dtStyle = objStyle.getTailorStyleMapping(new Guid(Request.QueryString["tailorid"].ToString()));
                            foreach (DataRow dr in dtStyle.Rows)
                            {
                                foreach (ListItem item in chkStyle.Items)
                                {
                                    if (item.Value.ToString().ToUpper() == dr["StyleId"].ToString().ToUpper())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                            #endregion

                            #region Map Category with Tailor
                            DataTable dtCat = objCategory.getTailorCategoryMapping(new Guid(Request.QueryString["tailorid"].ToString()));
                            foreach (DataRow dr in dtCat.Rows)
                            {
                                foreach (ListItem item in chkCategory.Items)
                                {
                                    if (item.Value.ToString().ToUpper() == dr["CategoryId"].ToString().ToUpper())
                                    {
                                        item.Selected = true;
                                        dvCategory.Visible = true;
                                        break;
                                    }
                                }
                            }
                            #endregion

                            #region Map Featrue with Tailor
                            DataTable dtFeat = objFeature.getTailorFeatureMapping(new Guid(Request.QueryString["tailorid"].ToString()));
                            foreach (DataRow dr in dtFeat.Rows)
                            {
                                foreach (ListItem item in chkFeature.Items)
                                {
                                    if (item.Value.ToString().ToUpper() == dr["FeatureId"].ToString().ToUpper())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objTailor = null;
                        objStyle = null;
                        objCategory = null;
                        objFeature = null;
                    }
                }
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindStates(Convert.ToInt16(ddlCountry.SelectedValue));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TailorMaster objTailor = new TailorMaster();
            try
            {
                if (txtTailorName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter tailor name";
                }
                else if (txtEmail.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter tailor email";
                }
                else if (!ddlCountry.Items.Cast<ListItem>().Any(item => item.Selected))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select Country";
                }
                else if (!ddlState.Items.Cast<ListItem>().Any(item => item.Selected))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select state";
                }
                else if (txtLatitude.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter tailor latitude";
                }
                else if (txtLongitude.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter tailor longitude";
                }
                else if (!chkCategory.Items.Cast<ListItem>().Any(item => item.Selected) && chkCategory.Items.Count > 0)
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select alteast one category";
                }
                else if (!chkStyle.Items.Cast<ListItem>().Any(item => item.Selected))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select alteast one style";
                }
                else if (!chkFeature.Items.Cast<ListItem>().Any(item => item.Selected))
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please select alteast one feature";
                }
                else
                {
                    if (Request.QueryString["tailorid"] == null)
                    {
                        #region Add Tailor
                        objTailor.TailorName = txtTailorName.Text;
                        objTailor.TailorEmail = txtEmail.Text;
                        objTailor.TailorPhone = txtPhone.Text;
                        objTailor.TailorAddress = txtAddress.Text;
                        objTailor.TailorCity = txtCity.Text;
                        objTailor.TailorPincode = txtPin.Text;
                        objTailor.TailorPricerange = txtPriceRange.Text;
                        objTailor.TailorStateId = Convert.ToInt16(ddlState.SelectedValue);
                        objTailor.TailorStatus = Convert.ToInt16(rdoStatus.SelectedValue);
                        objTailor.TailorExpertise = txtExpertise.Text;
                        objTailor.TailorDescription = txtDescription.Text;
                        objTailor.TailorLatitude = Convert.ToDecimal(txtLatitude.Text);
                        objTailor.TailorLongitude = Convert.ToDecimal(txtLongitude.Text);

                        if (flTailorImage.FileName != "")
                        {
                            objTailor.TailorImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/TailorImages/" + flTailorImage.FileName;
                            string fileName = Path.GetFileName(flTailorImage.PostedFile.FileName);
                            flTailorImage.PostedFile.SaveAs(Server.MapPath("~/Images/TailorImages/") + fileName);
                        }
                        else
                            objTailor.TailorImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/TailorImages/" + "noimage.png";


                        #region Insert Category/Style/Feature mapping
                        IEnumerable<Guid> objCategory = (from item in chkCategory.Items.Cast<ListItem>()
                                                         where item.Selected
                                                         select Guid.Parse(item.Value));

                        IEnumerable<Guid> objStyle = (from item in chkStyle.Items.Cast<ListItem>()
                                                      where item.Selected
                                                      select Guid.Parse(item.Value));

                        IEnumerable<Guid> objFeature = (from item in chkFeature.Items.Cast<ListItem>()
                                                        where item.Selected
                                                        select Guid.Parse(item.Value));
                        #endregion
                        objTailor.CategoryIds = objCategory;
                        objTailor.StyleIds = objStyle;
                        objTailor.FeatureIds = objFeature;

                        objTailor.saveTailor();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Tailor created successfully";
                        #endregion
                    }
                    else
                    {
                        #region Edit Tailor
                        txtEmail.Enabled = false;
                        objTailor.GUID = new Guid(Request.QueryString["tailorid"].ToString());
                        objTailor.TailorName = txtTailorName.Text;
                        objTailor.TailorEmail = txtEmail.Text;
                        objTailor.TailorPhone = txtPhone.Text;
                        objTailor.TailorAddress = txtAddress.Text;
                        objTailor.TailorCity = txtCity.Text;
                        objTailor.TailorPincode = txtPin.Text;
                        objTailor.TailorPricerange = txtPriceRange.Text;
                        objTailor.TailorStateId = Convert.ToInt16(ddlState.SelectedValue);
                        objTailor.TailorStatus = Convert.ToInt16(rdoStatus.SelectedValue);
                        objTailor.TailorExpertise = txtExpertise.Text;
                        objTailor.TailorDescription = txtDescription.Text;
                        objTailor.TailorLatitude = Convert.ToDecimal(txtLatitude.Text);
                        objTailor.TailorLongitude = Convert.ToDecimal(txtLongitude.Text);

                        if (flTailorImage.FileName != "")
                        {
                            String path = Server.MapPath(imgTailor.ImageUrl.Replace(ConfigurationManager.AppSettings["ImageUrl"].ToString(), ""));
                            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

                            string fileName = Path.GetFileName(flTailorImage.PostedFile.FileName);
                            flTailorImage.PostedFile.SaveAs(Server.MapPath("~/Images/TailorImages/") + fileName);
                            objTailor.TailorImage = ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/TailorImages/" + flTailorImage.FileName;
                        }
                        else
                            objTailor.TailorImage = imgTailor.ImageUrl == "" ? ConfigurationManager.AppSettings["ImageUrl"].ToString() + "Images/TailorImages/" + "noimage.png" : imgTailor.ImageUrl;

                        #region Insert Category/Style/Feature mapping
                        IEnumerable<Guid> objCategory = (from item in chkCategory.Items.Cast<ListItem>()
                                                         where item.Selected
                                                         select Guid.Parse(item.Value));

                        IEnumerable<Guid> objStyle = (from item in chkStyle.Items.Cast<ListItem>()
                                                      where item.Selected
                                                      select Guid.Parse(item.Value));

                        IEnumerable<Guid> objFeature = (from item in chkFeature.Items.Cast<ListItem>()
                                                        where item.Selected
                                                        select Guid.Parse(item.Value));
                        #endregion
                        objTailor.CategoryIds = objCategory;
                        objTailor.StyleIds = objStyle;
                        objTailor.FeatureIds = objFeature;

                        objTailor.updateTailor();
                        lblError.Visible = true;
                        lblError.InnerHtml = "Tailor updated successfully";
                        #endregion
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
                objTailor = null;
            }
        }

        private void bindCategories(List<Guid> featureId)
        {
            Category cat = new Category();
            try
            {
                Session["dt"] = cat.getCategoriesByFeatureId(featureId, (DataTable)Session["dt"]);
                chkCategory.DataSource = (DataTable)Session["dt"];
                chkCategory.DataValueField = "GUID";
                chkCategory.DataTextField = "CategoryName";
                chkCategory.DataBind();
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
        private void bindStyles()
        {
            StyleMaster styl = new StyleMaster();
            try
            {
                chkStyle.DataSource = styl.getAllStyles();
                chkStyle.DataValueField = "GUID";
                chkStyle.DataTextField = "StyleName";
                chkStyle.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                styl = null;
            }
        }
        private void bindCountries()
        {
            Country cont = new Country();
            try
            {
                ddlCountry.DataSource = cont.getAllCountries();
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cont = null;
            }
        }
        private void bindStates(int countryId)
        {
            Country cont = new Country();
            try
            {
                ddlState.DataSource = cont.getStatebyCountryId(countryId);
                ddlState.DataValueField = "StateId";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cont = null;
            }
        }
        private void bindFeatures()
        {
            Feature feature = new Feature();
            try
            {
                chkFeature.DataSource = feature.getAllFeatures();
                chkFeature.DataValueField = "GUID";
                chkFeature.DataTextField = "FeatureName";
                chkFeature.DataBind();
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

        protected void chkFeature_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkCategory.Items.Clear();
            int lastSelectedIndex = -1;
            string lastSelectedValue = string.Empty;
            List<Guid> lstGuid = new List<Guid>();
            foreach (ListItem listitem in chkFeature.Items)
            {
                if (listitem.Selected)
                {
                    int thisIndex = chkFeature.Items.IndexOf(listitem);
                    if (lastSelectedIndex < thisIndex)
                    {
                        lastSelectedIndex = thisIndex;
                        lastSelectedValue = listitem.Value;
                        lstGuid.Add(new Guid(lastSelectedValue));
                    }
                }
            }
            if (lastSelectedValue == "")
            {
                chkCategory.Items.Clear(); dvCategory.Visible = false;
            }
            else
                bindCategories(lstGuid);

            if (chkCategory.Items.Count > 0)
                dvCategory.Visible = true;
            else
                dvCategory.Visible = false;
        }
    }
}