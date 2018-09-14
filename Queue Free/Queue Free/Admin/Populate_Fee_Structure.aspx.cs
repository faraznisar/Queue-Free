using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Queue_Free.Admin;
using Queue_Free.Util;





namespace Queue_Free.Admin
{
    public partial class Populate_Fee_Structure : System.Web.UI.Page
    {
        //SqlConnection con;
        //SqlCommand csm;
        TextBox objtext, objtext2;
        TableRow rowobj;


        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {



            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("SELECT distinct Students.Batch, Session.SessionName, Deptts.DepttFullName FROM     Deptts CROSS JOIN Session CROSS JOIN Students", con);


                //    csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
                con.Open();
                int i = 0;

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {

                    rowobj = new TableRow();
                    i += 1;

                    for (int j = 0; j < rdr.FieldCount; j++)
                    {
                        TableCell objcell = new TableCell();
                        //    Label obj = new Label();
                        //  obj.ID = "demo" + i + j;
                        // obj.Text = Convert.ToString(rdr[j]);

                        objcell.Text = Convert.ToString(rdr[j]);
                        //     objcell.Controls.Add(obj);
                        rowobj.Cells.Add(objcell);

                    }

                    TableCell objcell1 = new TableCell();
                    TextBox txtfee = new TextBox();
                    txtfee.ID = "fee" + i;
                    objcell1.Controls.Add(txtfee);
                    rowobj.Cells.Add(objcell1);


                    TableCell objcell2 = new TableCell();
                    TextBox txthfee = new TextBox();
                    txthfee.ID = "hfee" + i;
                    objcell2.Controls.Add(txthfee);
                    rowobj.Cells.Add(objcell2);





                    tblresult.Rows.Add(rowobj);

                }
                Form.Controls.Add(tblresult);


            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                string tmpsql = "";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    int i = 0;
                    foreach (TableRow objrow in tblresult.Rows)

                    {
                        if (i == 0)
                        {
                            i += 1;
                            continue;
                        }

                        i += 1;


                        objtext = (TextBox)objrow.Cells[3].FindControl("fee" + Convert.ToString(i - 1));

                        if (objtext == null)
                            continue;


                        objtext2 = (TextBox)objrow.Cells[4].FindControl("hfee" + Convert.ToString(i - 1));

                        if (objtext2 == null)
                            continue;

                        //tmpsql += "insert into masterfee () values () " + objtext2.Text + " ";



                        tmpsql += "insert into dbo.MasterFee values(" + objrow.Cells[0].Text + "," + FeeHelper.convertsessionnametoid(objrow.Cells[1].Text) + "," + FeeHelper2.ConvertDepartmentNameToId(objrow.Cells[2].Text) + ", " + objtext.Text + "," + objtext2.Text + ");";

                      

                    }
                    SqlCommand csm = new SqlCommand(tmpsql, con);
                    con.Open();
                    csm.ExecuteNonQuery();
                    con.Close();
                }

              


                // Response.Write(tmpsql);
                // Response.Redirect("~/Admin/View_Fee.aspx");



                //Response.Write(tmpsql);

            }
            catch (Exception)
            {
                
            }
            finally
            {
                Response.Redirect("~/Admin/View_Fee.aspx");
            }

        }
    }
}
