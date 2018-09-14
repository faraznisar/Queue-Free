using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue_Free
{
    public partial class Mobile_No : System.Web.UI.Page
    {
        bool flag = false;

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rollno"] != null)
            {
                lbltemp.Text = Session["Rollno"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select Token from dbo.Students where Rollno=@rollno", con);
                csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["Token"].ToString() == txtMobileNo.Text)
                    {

                        flag = true;
                        break;

                    }


                }
                if (flag == true)
                {
                    Response.Redirect("~/Student/Mobile OTP.aspx");
                }

                else
                {
                    lblStatus.Text = "Mobile number not valid.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}