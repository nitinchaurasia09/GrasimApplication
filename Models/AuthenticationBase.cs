using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrasimApplication.Models
{
    public class AuthenticationBase : System.Web.UI.Page
    {
        public AuthenticationBase()
        {
            this.Load += new EventHandler(this.Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User"]==null)
            {
                Response.Redirect("~/Default.aspx?ReturnUrl=~" + Server.UrlEncode(Request.RawUrl));
            }
        }
    }
}