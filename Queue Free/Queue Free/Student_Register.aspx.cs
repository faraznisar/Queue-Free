using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue_Free
{
    public partial class Student_Register : System.Web.UI.Page
    {
        bool flag = false;

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
    }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select Rollno from dbo.Students where Rollno=@rollno", con);
                csm.Parameters.AddWithValue("@rollno", TxtRollNo.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["Rollno"].ToString() == TxtRollNo.Text)
                    {

                        flag = true;
                        break;

                    }


                }
                if (flag == true)
                {
                    Session["Rollno"] = TxtRollNo.Text;
                    Response.Redirect("~/Email_Verification.aspx");
                }

                else
                {
                    LblStatus.Text = "Roll number not valid.";
                    LblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
    }