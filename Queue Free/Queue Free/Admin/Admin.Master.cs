using System;
using System.Web.Security;

namespace Queue_Free.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["TestPage"]==null)
                {
                    Response.Redirect("~/Student/Index.aspx");
                }
            }

        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Index.aspx");
        }
    }
}