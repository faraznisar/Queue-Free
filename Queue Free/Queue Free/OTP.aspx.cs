using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Queue_Free
{
    public partial class OTP : System.Web.UI.Page
    {
        bool flag;
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rollno"] != null)
            {
                lbltemp.Text = Session["Rollno"].ToString();

            }
        }

        protected void BtnSubmitOTP_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select OTP from dbo.Students where Rollno=@rollno", con);
                con.Open();
                csm.Parameters.AddWithValue("@rollno", lbltemp.Text);

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["OTP"].ToString() == TxtOTP.Text)
                    {
                        flag = true;
                        break;

                    }
                }
                for (int i = 0; i <= 2; i++)
                {
                    if (flag == true)
                    {
                        Response.Redirect("~/Create_or_Change_Password.aspx");
                    }
                    else
                    {
                        lblstatus.Text = "Invalid OTP";
                    }
                }
            }
        }
    }
}