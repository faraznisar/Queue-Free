using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace Queue_Free.Student
{
    public partial class Check_Status : System.Web.UI.Page
    {



        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (rbPass.Checked == true)
            {
                
                    
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand csm = new SqlCommand("update dbo.StudentFeeStatus set Status='completed' where Rollno=@rollno and txn_id=@txnid", con);
                        csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                        csm.Parameters.AddWithValue("@txnid", txttempId.Text);
                        con.Open();
                        csm.ExecuteNonQuery();
                    }
                    Response.Redirect("~/Student/Pay_Fee.aspx");
                    
               
            }

            if (rbFail.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand csm = new SqlCommand("update dbo.StudentFeeStatus set Status='Failed' where Rollno=@rollno and txn_id=@txnid", con);
                    csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                    csm.Parameters.AddWithValue("@txnid", txttempId.Text);
                    con.Open();
                    csm.ExecuteNonQuery();
                }
                Response.Redirect("~/Student/Pay_Fee.aspx");
            }
        }


        //private string CheckFeeStatus(string test, string value)
        //{
        //    test = "paid";
        //    if (test==value)
        //    {
        //        flag = true;
        //    }
        //    else
        //    {
        //        flag = false;
        //    }
        //    if (flag==true)
        //    {
        //        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //        using (SqlConnection con=new SqlConnection(cs))
        //        {
        //            SqlCommand csm = new SqlCommand("update dbo.StudentFeeStatus set Status='paid' where Rollno=@rollno and txn_id=@txnid", con);
        //            csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
        //            csm.Parameters.AddWithValue("@txnid",lblTempId.Text);
        //            con.Open();
        //            csm.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}