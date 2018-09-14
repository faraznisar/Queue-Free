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

namespace Queue_Free
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {



            try
            {
                GetAdminRole();
                CheckAdminPassword();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spAuthenticateAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();



                    if (lblrole.Text == "Admin")
                    {
                        if (Convert.ToBoolean(rdr["Authenticated"]))

                        {

                            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                            Session["TestPage"] = "Admin_Login.aspx";
                            Response.Redirect("~/Admin/Index.aspx");
                        }
                        
                    }
                    else if (lblrole.Text == null)
                    {
                        lblStatus.Text = "Invalid Username and/or Password.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                  


                }


            }
            catch (Exception)
            {

            }


        }

        private void CheckAdminPassword()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("select Password from dbo.Admin_Login where UserName=@username", con);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        lblp.Text = rdr["Password"].ToString();

                    }
                    if (txtPassword.Text != lblp.Text)
                    {
                        lblStatus.Text = "Invalid Username and/or password.";
                    }

                }
            }
            catch (Exception)
            {

            }
        }




        private void GetAdminRole()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select RoleType from dbo.Admin_Login where UserName=@username", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblrole.Text = rdr["RoleType"].ToString();

                }

            }



        }


    }
}