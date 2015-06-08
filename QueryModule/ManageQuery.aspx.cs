using GrasimApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication.QueryModule
{
    public partial class ManageQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            //}
            if (!IsPostBack)
            {
                if (Request.QueryString["guid"] != null)
                {
                    Query query = new Query();
                    try
                    {

                        DataTable dt = query.getQueriesByQueryId(new Guid(Request.QueryString["guid"].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            lblUserName.Text = dt.Rows[0]["UserName"].ToString();
                            lblQuery.Text = dt.Rows[0]["QueryDescription"].ToString();
                            hdnUserEmail.Value = dt.Rows[0]["UserEmail"].ToString();
                            if (dt.Rows[0]["ReplyStatus"].ToString() == "1")
                            {
                                btnReply.Enabled = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/QueryModule/ShowAllQueries");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        query = null;
                    }
                }
                else
                {
                    Response.Redirect("~/QueryModule/ShowAllQueries");
                }
            }

        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            Query objQuery = new Query();
            try
            {
                if (txtReply.Text == "")
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Please enter reply";
                }
                else
                {
                    objQuery.GUID = new Guid(Request.QueryString["guid"].ToString());

                    SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["DomainEmailHost"], Convert.ToInt32(ConfigurationManager.AppSettings["DomainEmailPort"]));

                    smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["DomainEmailId"], ConfigurationManager.AppSettings["DomainEmailPwd"]);
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage mail = new MailMessage();

                    //Setting From , To and CC
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["DomainEmailId"], ConfigurationManager.AppSettings["DomainEmailDisplayName"]);
                    mail.To.Add(new MailAddress(hdnUserEmail.Value));
                    mail.Body = txtReply.Text;
                    mail.Subject = lblQuery.Text.Substring(0, 20) + "...";

                    smtpClient.Send(mail);

                    objQuery.updateQueryStatusByQueryId();
                    lblError.Visible = true;
                    lblError.InnerHtml = "Query updated successfully";
                    btnReply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.InnerHtml = ex.Message;
            }
            finally
            {
                objQuery = null;
            }
        }
    }
}