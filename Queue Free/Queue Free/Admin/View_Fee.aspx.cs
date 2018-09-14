using System;
using System.Data.SqlClient;
using System.Configuration;
using Queue_Free.Util;


namespace Queue_Free.Admin
{
    public partial class View_Fee : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        using (SqlCommand csm = new SqlCommand("select * from dbo.MasterFee", con))
                        {
                            con.Open();
                            SqlDataReader rdr = csm.ExecuteReader();
                            gvViewFee.DataSource = rdr;
                            gvViewFee.DataBind();
                        }
                    }


                }
                catch (Exception)
                {

                }
                finally
                {
                    //GetBatchFrosmb();
                    //GetSessionNameFrosDb();
                    //GetDepttNamefromDb();
                }



            }

        }


        //protected void LbUpdateFee_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {

        //        SqlCommand csm = new SqlCommand("select * from dbo.MasterFee where YearOfAdmission=@YOA and SessionId=ASessionId and DepttId=@DeptId", con);

        //    }
        //}


        //    private void GetDepttNamefromDb()
        //    {
        //        ddlDepttName.Items.Clear();



        //        SqlConnection con = new SqlConnection(cs);
        //        SqlCommand csm = new SqlCommand("select DepttShortName from dbo.Deptts", con);


        //        try
        //        {
        //            System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
        //            newItem.Text = "<Select Department>";
        //            newItem.Value = "0";
        //            ddlDepttName.Items.Add(newItem);

        //            con.Open();

        //            SqlDataReader rdr = csm.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                newItem = new System.Web.UI.WebControls.ListItem();
        //                newItem.Text = rdr["DepttShortName"].ToString();
        //                ddlDepttName.Items.Add(newItem);

        //            }
        //            rdr.Close();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }


        //    private void GetSessionNameFrosDb()
        //    {
        //        ddlSessionName.Items.Clear();



        //        SqlConnection con = new SqlConnection(cs);
        //        SqlCommand csm = new SqlCommand("select SessionName from dbo.Session", con);


        //        try
        //        {
        //            System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
        //            newItem.Text = "<Select Session>";
        //            newItem.Value = "0";
        //            ddlSessionName.Items.Add(newItem);

        //            con.Open();

        //            SqlDataReader rdr = csm.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                newItem = new System.Web.UI.WebControls.ListItem();
        //                newItem.Text = rdr["SessionName"].ToString();
        //                ddlSessionName.Items.Add(newItem);

        //            }
        //            rdr.Close();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //    private void GetBatchFrosmb()
        //    {
        //        ddlBatch.Items.Clear();



        //        SqlConnection con = new SqlConnection(cs);
        //        SqlCommand csm = new SqlCommand("select distinct Batch from dbo.Students", con);


        //        try
        //        {
        //            System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
        //            newItem.Text = "<Select Batch>";
        //            newItem.Value = "0";
        //            ddlBatch.Items.Add(newItem);

        //            con.Open();

        //            SqlDataReader rdr = csm.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                newItem = new System.Web.UI.WebControls.ListItem();
        //                newItem.Text = rdr["Batch"].ToString();
        //                ddlBatch.Items.Add(newItem);

        //            }
        //            rdr.Close();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //    protected void btnViewFee_Click(object sender, EventArgs e)
        //    {

        //        try
        //        {
        //            using (SqlConnection con = new SqlConnection(cs))
        //            {
        //                SqlCommand cmd = new SqlCommand("select TutionFeeAmount,HostelFeeAmount from dbo.MasterFee where YearOfAdmission=@yoa and SessionId=@sessionid and DepttId=@depttid", con);
        //                cmd.Parameters.AddWithValue("@yoa", ddlBatch.Text);
        //                cmd.Parameters.AddWithValue("@sessionid", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
        //                cmd.Parameters.AddWithValue("@depttid", FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
        //                con.Open();
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                while (rdr.Read())
        //                {
        //                    txtTutionFee.Text = rdr["TutionFeeAmount"].ToString();
        //                    txtHostelFee.Text = rdr["HostelFeeAmount"].ToString();

        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {


        //        }

        //    }

        //    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        //    {

        //    }

        //    protected void ddlSessionName_SelectedIndexChanged(object sender, EventArgs e)
        //    {

        //    }

        //    protected void ddlDepttName_SelectedIndexChanged(object sender, EventArgs e)
        //    {

        //    }
        //}
    }
}