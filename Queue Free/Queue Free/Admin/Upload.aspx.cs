using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;




namespace Queue_Free.Admin
{
    public partial class Upload : System.Web.UI.Page
    {
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Display()
        {
            try
            {
                //Upload and save the file
                string csvPath = Server.MapPath("~/Files/") + "uploded.csv";
                // + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(csvPath);

                //Create a DataTable.
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Department Id", typeof(int)),
        new DataColumn("Batch", typeof(int)),
        new DataColumn("Roll no",typeof(string)),new DataColumn("Student Full Name",typeof(string)),
        new DataColumn("Email ID",typeof(string)),new DataColumn("Mobile_No",typeof(string)) });

                //Read the contents of CSV file.
                string csvData = File.ReadAllText(csvPath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;

                        //Execute a loop over the columns.
                        foreach (string cell in row.Split(','))
                        {

                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            if (i == 4)
                            {
                                if (check_email_exists(cell))
                                {
                                    limsg.Text += "Email already exists: " + cell + "<br />";
                                    btnDBAdd.Enabled = false;
                                }
                            }
                            if (i == 5)
                            {
                                if (check_mobileno_exists(cell))
                                {
                                    limsg.Text += "Mobile Number already exists: " + cell + "<br/>";
                                    btnDBAdd.Enabled = false;
                                }
                            }
                            if (i == 2)
                            {
                                if (Check_rollno_exists(cell))
                                {
                                    limsg.Text += "A Sudent With the Rollno " + cell + " already exists." + "<br/>";
                                    btnDBAdd.Enabled = false;
                                }
                            }

                            i++;
                        }
                    }
                }


                //check if email exits



                //Bind the DataTable.
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
           


          
        }


        Boolean Check_rollno_exists(string roll)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                SqlCommand csm = new SqlCommand("select * from dbo.Students where Rollno='" + roll + "'", con);
                if (csm.ExecuteScalar()==null)
                {
                    con.Close();
                    return false;
                }
                else
                {
                    con.Close();
                    return true;
                }

            }
        }

        Boolean check_mobileno_exists(string mobile)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                SqlCommand csm = new SqlCommand("select * from dbo.Students where Mobile_No='" + mobile + "'", con);
                if (csm.ExecuteScalar()==null)
                {
                    con.Close();
                    return false;
                }
                else
                {
                    con.Close();
                    return true;
                }
            }
        }
        Boolean check_email_exists(string email)
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand csm = new SqlCommand("select * from dbo.students where email_id = '" + email + "'",con);
                if (csm.ExecuteScalar() == null)
                {
                    con.Close();
                    return false;
                }
                else
                {
                    con.Close();
                    return true;
                }
            }
  

        }



      
        protected void btnImport_Click(object sender, EventArgs e)
        {
            Display();
        }

        protected void btnDBAdd_Click(object sender, EventArgs e)
        {
            try
            {
                 //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + "uploded.csv";
            // + Path.GetFileName(FileUpload1.PostedFile.FileName);
         //   FileUpload1.SaveAs(csvPath);

            //Create a DataTable.
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Department Id", typeof(int)),
        new DataColumn("Batch", typeof(int)),
        new DataColumn("Roll no",typeof(string)),new DataColumn("Student Full Name",typeof(string)),
        new DataColumn("Email ID",typeof(string)),new DataColumn("Mobile_No",typeof(string)) });

            //Read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    //Execute a loop over the columns.
                    foreach (string cell in row.Split(','))
                    {

                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        if (i == 4)
                        {
                            if (check_email_exists(cell))
                            {
                                limsg.Text += "Email already exists: " + cell + "<br />";
                                btnDBAdd.Enabled = false;
                            }
                        }
                        if (i == 5)
                        {
                            if (check_mobileno_exists(cell))
                            {
                                limsg.Text += "Mobile Number already exists: " + cell + "<br/>";
                                btnDBAdd.Enabled = false;
                            }
                        }
                        if (i == 2)
                        {
                            if (Check_rollno_exists(cell))
                            {
                                limsg.Text += "A Sudent With the Rollno " + cell + " already exists." + "<br/>";
                                btnDBAdd.Enabled = false;
                            }
                        }

                        i++;
                    }
                }
            }


            //check if email exits



            //Bind the DataTable.
            GridView1.DataSource = dt;
            GridView1.DataBind();



            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
          {

              using (SqlBulkCopy bulkcopy = new SqlBulkCopy(con))
              {
                  //set DB table name.
                  bulkcopy.DestinationTableName = "dbo.Students";

                  //map DataTable columns with the DB columns.
                  bulkcopy.ColumnMappings.Add("Department Id", "DepttId");
                  bulkcopy.ColumnMappings.Add("Batch", "Batch");
                  bulkcopy.ColumnMappings.Add("Roll no", "Rollno");
                  bulkcopy.ColumnMappings.Add("Student Full Name", "StudentFullName");
                  bulkcopy.ColumnMappings.Add("Email ID", "Email_ID");
                  bulkcopy.ColumnMappings.Add("Mobile_No", "Mobile_No");
                  con.Open();

                  bulkcopy.WriteToServer(dt);
                  con.Close();
              }
          } 
            }
            catch (Exception)
            {

                throw;
            }

           
        }
    }
}