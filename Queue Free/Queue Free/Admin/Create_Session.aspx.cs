using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Queue_Free.Admin
{
    public partial class Create_Session : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand csm;
        bool flag = false;

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateSession_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(cs))
                {
                    csm = new SqlCommand("select SessionName FROM dbo.Session where SessionName=@sessionname", con);
                    csm.Parameters.AddWithValue("@sessionname", txtSessionName.Text);
                    con.Open();
                    SqlDataReader rdr = csm.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["SessionName"].ToString() == txtSessionName.Text)
                        {
                            flag = true;
                            break;

                        }
                    }
                    if (flag == true)
                    {
                        lblStatus.Text = "Session already exists.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        using (con = new SqlConnection(cs))
                        {
                            csm = new SqlCommand("insert into dbo.Session values(@sessionname)", con);
                            csm.Parameters.AddWithValue("@sessionname", txtSessionName.Text);
                            con.Open();
                            csm.ExecuteNonQuery();

                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
            
            
        }

        protected void btnViewSession_Click(object sender, EventArgs e)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select * FROM dbo.Session", con);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                gvViewSession.DataSource = rdr;
                gvViewSession.DataBind();
            }
        }
    }
}