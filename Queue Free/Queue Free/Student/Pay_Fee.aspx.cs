using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Queue_Free.Util;

namespace Queue_Free.Student
{
    public partial class Pay_Fee : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBatch();

            if (String.IsNullOrEmpty(lblFeeAmount.Text))
            {
                btnPayFee.Enabled = false;

            }
            

            if (!IsPostBack)
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand csm = new SqlCommand("SELECT StudentFeeStatus.txn_id as FeeStatus, StudentFeeStatus.Semester as Semester, Session.SessionName as Session, StudentFeeStatus.Rollno as RollNo, StudentFeeStatus.FeeAmount Amount, StudentFeeStatus.TimeStamp as Date, StudentFeeStatus.Status as Status FROM Session INNER JOIN StudentFeeStatus ON Session.SessionId = StudentFeeStatus.SessionId where Rollno=@rollno order by txn_id desc", con);
                        csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                        con.Open();
                        SqlDataReader rdr = csm.ExecuteReader();


                        gvStudentFeeStatus.DataSource = rdr;
                        gvStudentFeeStatus.DataBind();

                    }

                }
                catch (Exception)
                {

                    
                }
               
                

            }



        }




        private void CheckBatch()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand csm = new SqlCommand("select Batch,DepttId from dbo.Students where Rollno=@rollno", con);
                    csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                    con.Open();
                    SqlDataReader rdr = csm.ExecuteReader();
                    while (rdr.Read())
                    {
                        lblBatch.Text = rdr["Batch"].ToString();
                        lblDepttName.Text = StudentFeeHelper2.ConvertDepttIdToDepartmentName(rdr["DepttId"].ToString());


                    }
                }


            }
            catch (Exception)
            {
                
            }
            
        }




        protected void btnPayFee_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand csm;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    csm = new SqlCommand("insert into dbo.StudentFeeStatus values(@sessionId,@rollNo,@feeAmount,@TimeStamp,@status,@semester)", con);


                    csm.Parameters.AddWithValue("@sessionId", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                    csm.Parameters.AddWithValue("@rollNo", Session["Rollno"]);
                    csm.Parameters.AddWithValue("@feeAmount", lblFeeAmount.Text);
                    csm.Parameters.AddWithValue("@TimeStamp", DateTime.Today);
                    csm.Parameters.AddWithValue("@status", lblTempStatus.Text);
                    csm.Parameters.AddWithValue("@semester", ddlSemester.Text);
                    con.Open();
                    csm.ExecuteNonQuery();


                }
                Response.Redirect("~/Student/Check_Status.aspx");
                // Response.Redirect("http://coetbgsbu.org/src/pg/testrequest.aspx");
            }
            catch (Exception)
            {
                
            }


          


            







        }

        protected void rbTutionFee_CheckedChanged(object sender, EventArgs e)
        {
            GetFeeAmountFrosmb();

        }


        private void GetFeeAmountFrosmb()
        {
            ddlSessionName.Items.Clear();



            SqlConnection con = new SqlConnection(cs);
            SqlCommand csm = new SqlCommand("select SessionId from dbo.MasterFee where YearOfAdmission = @yearofadmission and DepttId = @depttid", con);
            csm.Parameters.AddWithValue("@yearofadmission", lblBatch.Text);
            csm.Parameters.AddWithValue("@depttid", FeeHelper2.ConvertDepartmentNameToId(lblDepttName.Text));

            try
            {
                ListItem newItem = new ListItem();
                newItem.Text = "<Select Session>";
                newItem.Value = "0";
                ddlSessionName.Items.Add(newItem);

                con.Open();

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    newItem = new ListItem();
                    newItem.Text = StudentFeeHelper.ConvertSessionIdToSessionName(rdr["SessionId"].ToString());
                    ddlSessionName.Items.Add(newItem);
                    //ddlSessionName.DataValueField = rdr["SessionId"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
        }

      

        //private void GetHostelFeeFrosmb()
        //{
        //    ddlSessionName.Items.Clear();



        //    SqlConnection con = new SqlConnection(cs);
        //    SqlCommand csm = new SqlCommand("select SessionId from dbo.MasterFee where YearOfAdmission = @yearofadmission and DepttId = @depttid", con);
        //    csm.Parameters.AddWithValue("@yearofadmission", lblBatch.Text);
        //    csm.Parameters.AddWithValue("@depttid", FeeHelper2.ConvertDepartmentNameToId(lblDepttName.Text));

        //    try
        //    {
        //        ListItem newItem = new ListItem();
        //        newItem.Text = "<Select Session>";
        //        newItem.Value = "0";
        //        ddlSessionName.Items.Add(newItem);

        //        con.Open();
        //        SqlDataReader rdr = csm.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            newItem = new ListItem();
        //            newItem.Text = StudentFeeHelper.ConvertSessionIdToSessionName(rdr["SessionId"].ToString());
        //            ddlSessionName.Items.Add(newItem);
        //        }
        //        rdr.Close();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}



        protected void ddlSessionName_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con;
            SqlCommand csm;
            SqlDataReader rdr;


            if (rbTutionFee.Checked == true)
            {
                using (con = new SqlConnection(cs))
                {
                    csm = new SqlCommand("select TutionFeeAmount from dbo.MasterFee where SessionId=@sessionId", con);
                    csm.Parameters.AddWithValue("@sessionId", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                    con.Open();

                    rdr = csm.ExecuteReader();
                    if (rdr.Read())
                    {
                        lblFeeAmount.Text = rdr["TutionFeeAmount"].ToString();
                        btnPayFee.Enabled = true;

                    }
                }
            }


            if (rbExaminationFee.Checked == true)
            {

                using (con = new SqlConnection(cs))
                {
                    csm = new SqlCommand("select ExaminationFeeAmount from dbo.MasterFee where SessionId=@sessionId", con);
                    csm.Parameters.AddWithValue("@sessionId", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                    con.Open();

                    rdr = csm.ExecuteReader();
                    if (rdr.Read())
                    {
                        lblFeeAmount.Text = rdr["ExaminationFeeAmount"].ToString();

                        btnPayFee.Enabled = true;

                    }



                }
                rdr.Close();
            }

        }

        protected void rbExaminationFee_CheckedChanged(object sender, EventArgs e)
        {
            GetFeeAmountFrosmb();
        }
    }
}