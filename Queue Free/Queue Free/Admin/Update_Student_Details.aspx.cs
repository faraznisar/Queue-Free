using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue_Free.Admin
{
    public partial class Update_Student_Details : System.Web.UI.Page
    {


        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con;
        SqlCommand csm;
        string str;
        int count;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CheckEmail()
        {
            con = new SqlConnection(cs);
            con.Open(); 
            str = "select count(*) from dbo.Students where Email_ID=@email";
            csm = new SqlCommand(str, con);
            csm.Parameters.AddWithValue("@email", txtEmail.Text);
            count = Convert.ToInt32(csm.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                LblStatus.Text = "The Email is already taken, Please enter another email";
                LblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LblStatus.Text = "Email updated succesfully";
                LblStatus.ForeColor = System.Drawing.Color.Green;
                con.Open();
                str = "update dbo.Students set Email_ID=@email where Rollno=@rollno";
                csm = new SqlCommand(str, con);
                csm.Parameters.AddWithValue("@rollno", TxtRollno.Text);
                csm.Parameters.AddWithValue("@email", txtEmail.Text);
                csm.ExecuteNonQuery();
                con.Close();
            }
        }
        
        public void CheckMobile()
        {
            con = new SqlConnection(cs);
            con.Open();
            str = "select count(*) from dbo.Students where Mobile_No=@mobileno";
            csm = new SqlCommand(str, con);
            csm.Parameters.AddWithValue("@mobileno", txtMobileNo.Text);
            count = Convert.ToInt32(csm.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                LblStatus.Text = "The Mobile number is already registered, Please enter another mobile number.";
                LblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LblStatus.Text = "Mobile number updated succesfully";
                LblStatus.ForeColor = System.Drawing.Color.Green;
                con.Open();
                str = "update dbo.Students set Mobile_No=@mobileno where Rollno=@rollno";
                csm = new SqlCommand(str, con);
                csm.Parameters.AddWithValue("@rollno", TxtRollno.Text);
                csm.Parameters.AddWithValue("@mobileno", txtMobileNo.Text);
                csm.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select Email_ID,Mobile_No from dbo.Students where Rollno=@rollno", con);
                csm.Parameters.AddWithValue("@rollno", TxtRollno.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    txtEmail.Text = rdr["Email_ID"].ToString();
                    txtMobileNo.Text = rdr["Mobile_No"].ToString();
                }
            }
        }

        protected void BtnEmail_Click(object sender, EventArgs e)
        {
            CheckEmail();
        }

        protected void BtnUpdateMobile_Click(object sender, EventArgs e)
        {
            CheckMobile();
        }
    }
}







