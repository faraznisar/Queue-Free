using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Queue_Free.Util;

namespace Queue_Free
{
    public partial class Default : System.Web.UI.MasterPage
    {

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
            
        //    try
        //    {
        //        GetRoles();
        //        CheckPassword();

        //        using (SqlConnection con = new SqlConnection(cs))
        //        {
        //            SqlCommand cmd = new SqlCommand("spAuthenticateUsers", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
        //            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            rdr.Read();
        //            if (lblrole.Text=="1")
        //            {
        //                if (Convert.ToBoolean(rdr["Authenticated"]))

        //                {
                            

        //                    Session["Rollno"] = rdr["Rollno"];
        //                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
        //                    Response.Redirect("~/Student/Index.aspx");
        //                }
        //                else
        //                {
        //                    lblStatus.Text = "Invalid Username and/or Password.";
        //                    lblStatus.ForeColor = System.Drawing.Color.Red;

        //                }


        //            }
        //            else if (lblrole.Text == "2")
        //            {
        //                if (Convert.ToBoolean(rdr["Authenticated"]))

        //                {

        //                    Session["Rollno"] = rdr["Rollno"];
        //                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
        //                    Response.Redirect("~/Student/Index.aspx");
        //                }
        //                else
        //                {
        //                    lblStatus.Text = "Invalid Username and/or Password.";
        //                    lblStatus.ForeColor = System.Drawing.Color.Red;

        //                }



        //            }
        //            else if (lblrole.Text == "3")
        //            {
        //                if (Convert.ToBoolean(rdr["Authenticated"]))

        //                {

        //                    Session["Rollno"] = rdr["Rollno"];
        //                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
        //                    Response.Redirect("~/Student/Index.aspx");
        //                }

        //                else
        //                {
        //                    lblStatus.Text = "Invalid Username and/or Password.";
        //                    lblStatus.ForeColor = System.Drawing.Color.Red;

        //                }

        //            }
        //            else if (lblrole.Text == "4")
        //            {
        //                if (Convert.ToBoolean(rdr["Authenticated"]))

        //                {

        //                    Session["Rollno"] = rdr["Rollno"];
        //                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
        //                    Response.Redirect("~/Student/Index.aspx");
        //                }

        //                else
        //                {
        //                    lblStatus.Text = "Invalid Username and/or Password.";
        //                    lblStatus.ForeColor = System.Drawing.Color.Red;

        //                }

        //            }
        //            else if (lblrole.Text == "5")
        //            {
        //                if (Convert.ToBoolean(rdr["Authenticated"]))

        //                {

        //                    Session["Rollno"] = rdr["Rollno"];
        //                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
        //                    Response.Redirect("~/Student/Index.aspx");
        //                }
        //                else
        //                {
        //                    lblStatus.Text = "Invalid Username and/or Password.";
        //                    lblStatus.ForeColor = System.Drawing.Color.Red;

        //                }

        //            }
        //            else if (lblrole.Text==null)
        //            {
        //                lblStatus.Text = "Invalid Username and/or Password.";
        //                lblStatus.ForeColor = System.Drawing.Color.Red;
        //            }
        //            //if (Convert.ToBoolean(rdr["Authenticated"]))
        //            //{
        //            //    Session["Rollno"] = rdr["Rollno"];
        //            //    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);

        //            //}
                   
                   
        //        }


        //    }
        //    catch (Exception)
        //    {
                
        //    }
           


        //}


        //private void CheckPassword()
        //{

        //    try
        //    {

        //        using (SqlConnection con = new SqlConnection(cs))
        //        {
        //            SqlCommand cmd = new SqlCommand("select Password from dbo.Students where Rollno=@rollno", con);
        //            cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {

        //                lblp.Text = rdr["Password"].ToString();

        //            }
        //            if (txtPassword.Text != lblp.Text)
        //            {
        //                lblStatus.Text = "Invalid Username and/or password.";
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}


        //private void GetRoles()
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand("select distinct DepttId from dbo.Students where Rollno=@rollno", con);
        //        cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            lblrole.Text = rdr["DepttId"].ToString();

        //        }

        //    }
        //}





    }
}
