using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;



namespace Queue_Free
{
    public partial class LogIn : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            {

                try
                {
                    
                    GetRoles();
                    CheckUserPassword();

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("spAuthenticateUsers", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        if (lblrole.Text == "1")
                        {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {


                                Session["Rollno"] = rdr["Rollno"];
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Student/Index.aspx");
                            }
                           


                        }
                        else if (lblrole.Text == "2")
                        {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {

                                Session["Rollno"] = rdr["Rollno"];
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Student/Index.aspx");
                            }
                           



                        }
                        else if (lblrole.Text == "3")
                        {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {

                                Session["Rollno"] = rdr["Rollno"];
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Student/Index.aspx");
                            }

                           

                        }
                        else if (lblrole.Text == "4")
                        {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {

                                Session["Rollno"] = rdr["Rollno"];
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Student/Index.aspx");
                            }

                           

                        }
                        else if (lblrole.Text == "5")
                        {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {

                                Session["Rollno"] = rdr["Rollno"];
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Student/Index.aspx");
                            }
                           
                           

                        }
                         else if (lblrole.Text=="Admin")
                            {
                            if (Convert.ToBoolean(rdr["Authenticated"]))

                            {
                                
                                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);
                                Response.Redirect("~/Admin/Index.aspx");
                            }
                           
                        }
                        else if (lblrole.Text == null)
                        {
                            lblStatus.Text = "Invalid Username and/or Password.";
                            lblStatus.ForeColor = System.Drawing.Color.Red;
                        }
                        //if (Convert.ToBoolean(rdr["Authenticated"]))
                        //{
                        //    Session["Rollno"] = rdr["Rollno"];
                        //    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRemember.Checked);

                        //}


                    }


                }
                catch (Exception)
                {

                }


            }



        }


      

        private void CheckUserPassword()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("select Password from dbo.Students where Rollno=@rollno", con);
                    cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
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

        

        private void GetRoles()
        {
            try
            {



                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("select distinct DepttId from dbo.Students where Rollno=@rollno", con);
                    cmd.Parameters.AddWithValue("@rollno", txtUserName.Text);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lblrole.Text = rdr["DepttId"].ToString();

                    }

                }


            }
            catch (Exception)
            {
                
            }
        }

    }
}

