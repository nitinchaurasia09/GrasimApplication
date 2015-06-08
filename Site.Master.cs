using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrasimApplication
{
    public partial class SiteMaster : MasterPage
    {      

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["User"]=null;
            FormsAuthentication.SignOut();
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            Response.Redirect("~/Default.aspx");
        }

    }

}