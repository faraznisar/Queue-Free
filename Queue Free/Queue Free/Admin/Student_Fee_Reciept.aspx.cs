using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Configuration;
using Queue_Free.Util;

namespace Queue_Free.Admin
{
    public partial class Student_Fee_Reciept : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDepttName.Items.Clear();
                GetBatchFromDb();
                GetSessionNameFromDb();



                SqlConnection con = new SqlConnection(cs);
                SqlCommand csm = new SqlCommand("select DepttFullName from dbo.Deptts", con);


                try
                {
                    System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
                    newItem.Text = "<Select Department>";
                    newItem.Value = "0";
                    ddlDepttName.Items.Add(newItem);

                    con.Open();

                    SqlDataReader rdr = csm.ExecuteReader();
                    while (rdr.Read())
                    {
                        newItem = new System.Web.UI.WebControls.ListItem();
                        newItem.Text = rdr["DepttFullName"].ToString();
                        ddlDepttName.Items.Add(newItem);

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



        }



        private void GetBatchFromDb()
        {
            ddlBatch.Items.Clear();



            SqlConnection con = new SqlConnection(cs);
            SqlCommand csm = new SqlCommand("select distinct Batch from dbo.Students", con);


            try
            {
                System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
                newItem.Text = "<Select Batch>";
                newItem.Value = "0";
                ddlBatch.Items.Add(newItem);

                con.Open();

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    newItem = new System.Web.UI.WebControls.ListItem();
                    newItem.Text = rdr["Batch"].ToString();
                    ddlBatch.Items.Add(newItem);

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


        private void GetSessionNameFromDb()
        {
            ddlSessionName.Items.Clear();



            SqlConnection con = new SqlConnection(cs);
            SqlCommand csm = new SqlCommand("select SessionName from dbo.Session", con);


            try
            {
                System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
                newItem.Text = "<Select Session>";
                newItem.Value = "0";
                ddlSessionName.Items.Add(newItem);

                con.Open();

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    newItem = new System.Web.UI.WebControls.ListItem();
                    newItem.Text = rdr["SessionName"].ToString();
                    ddlSessionName.Items.Add(newItem);

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

        protected void btnGetPdf_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con;
                if (ddlFeeType.Text == "Examination Fee")
                {
                    using (con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("select ExaminationFeeAmount from dbo.MasterFee where YearOfAdmission=@yoa and SessionId=@sessionid and DepttId=@depttid", con);
                        cmd.Parameters.AddWithValue("@yoa", ddlBatch.Text);
                        cmd.Parameters.AddWithValue("@sessionid", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                        cmd.Parameters.AddWithValue("@depttid",FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            lbltempfee.Text = rdr["ExaminationFeeAmount"].ToString();
                        }
                    }
                }
                if (ddlFeeType.Text == "Tution Fee")
                {
                    using (con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("select TutionFeeAmount from dbo.MasterFee where YearOfAdmission=@yoa and SessionId=@sessionid and DepttId=@depttid", con);
                        cmd.Parameters.AddWithValue("@yoa", ddlBatch.Text);
                        cmd.Parameters.AddWithValue("@sessionid", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                        cmd.Parameters.AddWithValue("@depttid",FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            lbltempfee.Text = rdr["TutionFeeAmount"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT distinct StudentFeeStatus.txn_id as Id, Students.StudentFullName as Student_Name, Students.Rollno, Deptts.DepttShortName as Department, Students.Batch, Session.SessionName as Session, StudentFeeStatus.FeeAmount as Amount, StudentFeeStatus.Semester, StudentFeeStatus.TimeStamp as Date_Paid FROM StudentFeeStatus INNER JOIN Session ON StudentFeeStatus.SessionId = Session.SessionId INNER JOIN Students ON StudentFeeStatus.Rollno = Students.Rollno CROSS JOIN Deptts where Deptts.DepttID=@depttid and SessionName = @sessionName and Batch = @batch and StudentFeeStatus.Status = 'completed' and FeeAmount=@feeamount", con);
                    cmd.Parameters.AddWithValue("@depttid", FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
                    cmd.Parameters.AddWithValue("@sessionName",ddlSessionName.Text);
                    cmd.Parameters.AddWithValue("@batch",ddlBatch.Text);
                    cmd.Parameters.AddWithValue("@feeamount", lbltempfee.Text);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    gvStudentFeeRecieptAdmin.DataSource = rdr;
                    gvStudentFeeRecieptAdmin.DataBind();
                    
                }
            }
            catch (Exception)
            {


            }


        }

        protected void btnDownloaadPdf_Click(object sender, EventArgs e)
        {



           



            using (MemoryStream ms = new MemoryStream())
            {

                Paragraph paragraph;
                iTextSharp.text.Font fdefault = FontFactory.GetFont("Arial", 17, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                Document doc = new Document(PageSize.A4);

                var writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                foreach (GridViewRow gvR in gvStudentFeeRecieptAdmin.Rows)
            {
                string Id = gvR.Cells[0].Text;
                string StudentName = gvR.Cells[1].Text;
                string Rollno= gvR.Cells[2].Text;
                string Department= gvR.Cells[3].Text;
                string Batch= gvR.Cells[4].Text;
                string Session = gvR.Cells[5].Text;
                string Amount = gvR.Cells[6].Text;
                string semester= gvR.Cells[7].Text;
                string datePaid= gvR.Cells[8].Text;




               
             
                try
                {

                  


                    var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logoBGSB.jpg"));
                    logo.SetAbsolutePosition(50, 730);
                    logo.ScaleAbsoluteHeight(75);
                    logo.ScaleAbsoluteWidth(70);
                    doc.Add(logo);


                    string SoET = "School of Engineering Technology";
                    paragraph = new Paragraph(SoET, fdefault);
                    paragraph.IndentationLeft = 150;
                    paragraph.SpacingAfter = 10;
                    doc.Add(paragraph);

                    string Bgsbu = "Baba Ghulam Shah Badshah University";
                    paragraph = new Paragraph(Bgsbu, fdefault);
                    paragraph.IndentationLeft = 135;
                    paragraph.SpacingAfter = 10;
                    paragraph.SpacingBefore = -10;
                    doc.Add(paragraph);


                    string Rjri = "Rajouri, Jammu and Kashmir (185234).";
                    paragraph = new Paragraph(Rjri, fdefault);
                    paragraph.IndentationLeft = 137;
                    paragraph.SpacingAfter = 10;
                    paragraph.SpacingBefore = -10;
                    doc.Add(paragraph);

                    Paragraph LineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    paragraph.SpacingAfter = 60;

                    doc.Add(LineSeparator);


                    PdfPTable table2 = new PdfPTable(2);
                    table2.SpacingBefore = 20;
                    table2.WidthPercentage = 80;
                    table2.SpacingAfter = 10;

                    PdfPCell cell1 = new PdfPCell();
                    cell1.AddElement(new Paragraph("Fee Reciept", FontFactory.GetFont("Arial", 12, Font.NORMAL)));
                    cell1.VerticalAlignment = Element.ALIGN_CENTER;

                    PdfPCell cell2 = new PdfPCell();
                    cell2.AddElement(new Paragraph("Admin Copy", FontFactory.GetFont("Arial", 12, Font.NORMAL)));
                    cell1.VerticalAlignment = Element.ALIGN_CENTER;

                    table2.AddCell(cell1);
                    table2.AddCell(cell2);

                    doc.Add(table2);

                    Paragraph LineSeparator3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    paragraph.SpacingAfter = 60;
                    doc.Add(LineSeparator3);


                    PdfPTable table1 = new PdfPTable(2);

                    table1.WidthPercentage = 90;
                    table1.SpacingBefore = 40;



                    PdfPCell cell11 = new PdfPCell();

                    cell11.AddElement(new Paragraph("Name : " +StudentName));

                    cell11.AddElement(new Paragraph("Roll no : " + Rollno));

                    cell11.AddElement(new Paragraph("Semester : " + semester));

                    cell11.VerticalAlignment = Element.ALIGN_LEFT;

                    PdfPCell cell12 = new PdfPCell();

                    cell12.AddElement(new Paragraph("Reciept no : " + Id));

                    cell12.AddElement(new Paragraph("Date Paid : " + datePaid));

                    cell12.AddElement(new Paragraph("Session : " + Session));



                    cell12.VerticalAlignment = Element.ALIGN_RIGHT;

                    table1.SpacingAfter = 18;

                    table1.AddCell(cell11);

                    table1.AddCell(cell12);
                    doc.Add(table1);





                    paragraph = new Paragraph("Recieved with thanks a sum of rupees " + Amount + "( " + ConvertCurrency.ConvertNumbertoWords((long)Convert.ToDouble(Amount)) + " )" + " from " + StudentName + " on account of " + /*ddlFeeType.Text*/  ".");
                    paragraph.IndentationLeft = 30f;
                    paragraph.SpacingBefore = 20;
                    paragraph.SpacingAfter = 30;
                    doc.Add(paragraph);

                    Paragraph LineSeparator5 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    paragraph.SpacingAfter = 1;
                    Paragraph LineSeparator6 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 70.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));

                    paragraph.SpacingAfter = 1;
                    Paragraph LineSeparator7 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));

                    paragraph.SpacingAfter = 60;
                    doc.Add(LineSeparator5);
                    doc.Add(LineSeparator6);
                    doc.Add(LineSeparator7);


                        doc.NewPage();
                        // paragraph = new Paragraph("tution fee" + lblAmount.Text);
                        //paragraph.IndentationLeft = 100f;
                        //paragraph.SpacingAfter = 30;
                        //doc.Add(paragraph);













                        //////////



                    }
                catch (Exception)
                {


                }





            }
                
                doc.Close();
            
                Response.ContentType = "pdf/application";
                Response.AddHeader("content-disposition", "attachment;filename=Fee Reciept.pdf");
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);


                //for (int i = 0; i < gvStudentFeeRecieptAdmin.Columns.Count; i++)
                //{
                //}
            }
        }
    }
}