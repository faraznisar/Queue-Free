using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace Queue_Free
{
    public partial class Create_or_Change_Password : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rollno"] != null)
            {
                lbltemp.Text = Session["Rollno"].ToString();
                //txtretypepassword.Text = "password";
            }
        }

        protected void BtnSavePassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand csm = new SqlCommand("update dbo.Students set [Password]=@password where Rollno=@rollno", con);
                    csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
                    csm.Parameters.AddWithValue("@password", txtpassword.Text);
                    con.Open();
                    csm.ExecuteNonQuery();
                     Response.Redirect("~/Login.aspx");
                }
            }
            //if (txtpassword.Text=="")
            //{
            //    lblnopassword.Text = "please enter a password.";
            //}
            //else if (Page.IsValid)
            //{
            //    using (SqlConnection con = new SqlConnection(cs))
            //    {
            //        SqlCommand csm = new SqlCommand("update dbo.Students set [Password]=@password where Rollno=@rollno", con);
            //        csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
            //        csm.Parameters.AddWithValue("@password", txtpassword.Text);
            //        con.Open();
            //        csm.ExecuteNonQuery();
            //       // Response.Redirect("~/Login.aspx");
            //    }

            //}






        }
    }
}