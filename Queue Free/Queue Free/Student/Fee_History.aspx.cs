using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Queue_Free.Util;


namespace Queue_Free.Student
{
    public partial class Fee_Status : System.Web.UI.Page
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
                        SqlCommand csm = new SqlCommand("select distinct Batch,DepttId from dbo.Students where Rollno=@rollno", con);
                        csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                        con.Open();
                        SqlDataReader rdr = csm.ExecuteReader();

                        while (rdr.Read())
                        {
                            lbltemp1.Text = rdr["Batch"].ToString();
                            lbltemp2.Text = rdr["DepttId"].ToString();

                        }
                        GetSessionNameFrosmb();
                        GetSemesterFrosDb();
                    }
                }
                catch (Exception)
                {
                }




            }

        }


        private void GetSemesterFrosDb()
        {
            ddlSemester.Items.Clear();



            SqlConnection con = new SqlConnection(cs);
            SqlCommand csm = new SqlCommand("select distinct Semester from dbo.StudentFeeStatus where Rollno=@rollno", con);

            csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);

            try
            {
                System.Web.UI.WebControls.ListItem newItem = new System.Web.UI.WebControls.ListItem();
                newItem.Text = "<Select Semester>";
                newItem.Value = "0";
                ddlSemester.Items.Add(newItem);

                con.Open();

                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    newItem = new System.Web.UI.WebControls.ListItem();
                    newItem.Text = rdr["Semester"].ToString();
                    ddlSemester.Items.Add(newItem);
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


        private void GetSessionNameFrosmb()
        {
            ddlSessionName.Items.Clear();



            SqlConnection con = new SqlConnection(cs);
            SqlCommand csm = new SqlCommand("select SessionId from dbo.MasterFee where YearOfAdmission = @yearofadmission and DepttId = @depttid", con);
            csm.Parameters.AddWithValue("@yearofadmission", lbltemp1.Text);
            csm.Parameters.AddWithValue("@depttid", lbltemp2.Text);

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

        protected void btnGetPdf_Click(object sender, EventArgs e)
        {


            using (MemoryStream ms = new MemoryStream())
            {
                Paragraph paragraph;
                iTextSharp.text.Font fdefault = FontFactory.GetFont("Arial", 17, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                Document doc = new Document(PageSize.A4);
                try
                {

                    var writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();


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
                    cell2.AddElement(new Paragraph("Student Copy", FontFactory.GetFont("Arial", 12, Font.NORMAL)));
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

                    cell11.AddElement(new Paragraph("Name : " + lblSttudentName.Text));

                    cell11.AddElement(new Paragraph("Department : " + lblDepartmentName.Text));

                    cell11.AddElement(new Paragraph("Roll no : " + lblRollno.Text));

                    cell11.AddElement(new Paragraph("Semester : " + ddlSemester.Text));

                    cell11.VerticalAlignment = Element.ALIGN_LEFT;

                    PdfPCell cell12 = new PdfPCell();

                    cell12.AddElement(new Paragraph("Reciept no : " + lbltemp3.Text));

                    cell12.AddElement(new Paragraph("Date Paid : " + lblDatePaid.Text));

                    cell12.AddElement(new Paragraph("Session : " + ddlSessionName.Text));



                    cell12.VerticalAlignment = Element.ALIGN_RIGHT;

                    table1.SpacingAfter = 18;

                    table1.AddCell(cell11);

                    table1.AddCell(cell12);
                    doc.Add(table1);





                    paragraph = new Paragraph("Recieved with thanks a sum of rupees " + lblAmount.Text + "( " + ConvertCurrency.ConvertNumbertoWords((long)Convert.ToDouble(lblAmount.Text)) + " )" + " from " + lblSttudentName.Text + " on account of " + ddlFeeType.Text + ".");
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

                    // paragraph = new Paragraph("tution fee" + lblAmount.Text);
                    //paragraph.IndentationLeft = 100f;
                    //paragraph.SpacingAfter = 30;
                    //doc.Add(paragraph);










                    doc.Close();
                    Response.ContentType = "pdf/application";
                    Response.AddHeader("content-disposition", "attachment;filename= "+ddlFeeType.Text+ "-" + ddlSemester.Text+"-" + ddlSessionName.Text +".pdf");
                    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);


                    //////////



                }
                catch (Exception)
                {


                }





            }

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            if (ddlFeeType.Text == "Examination Fee")
            {
                using (con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("select ExaminationFeeAmount from dbo.MasterFee where YearOfAdmission=@yoa and SessionId=@sessionid and DepttId=@depttid", con);
                    cmd.Parameters.AddWithValue("@yoa",lbltemp1.Text);
                    cmd.Parameters.AddWithValue("@sessionid",FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                    cmd.Parameters.AddWithValue("@depttid",lbltemp2.Text);
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
                    cmd.Parameters.AddWithValue("@yoa", lbltemp1.Text);
                    cmd.Parameters.AddWithValue("@sessionid", FeeHelper.convertsessionnametoid(ddlSessionName.Text));
                    cmd.Parameters.AddWithValue("@depttid", lbltemp2.Text);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        lbltempfee.Text = rdr["TutionFeeAmount"].ToString();
                    }
                }
            }
            
                
            



            using (con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("SELECT Students.Rollno, Students.StudentFullName, Students.DepttId,Students.Batch, Session.SessionName, StudentFeeStatus.FeeAmount, StudentFeeStatus.txn_id, StudentFeeStatus.TimeStamp, StudentFeeStatus.Status FROM     StudentFeeStatus INNER JOIN  Session ON StudentFeeStatus.SessionId = Session.SessionId INNER JOIN Students ON StudentFeeStatus.Rollno = Students.Rollno where Session.SessionName = @sessionname  and StudentFeeStatus.[Status] = 'completed' and StudentFeeStatus.Semester =@semester and  Students.Rollno = @rollno ", con);
                csm.Parameters.AddWithValue("@sessionname", ddlSessionName.Text);
                csm.Parameters.AddWithValue("@rollno", Session["Rollno"]);
                csm.Parameters.AddWithValue("@semester", ddlSemester.Text);
                csm.Parameters.AddWithValue("@feeamount", lbltempfee.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    lblSttudentName.Text = rdr["StudentFullName"].ToString();
                    lblRollno.Text = rdr["Rollno"].ToString();
                    lblDepartmentName.Text = StudentFeeHelper2.ConvertDepttIdToDepartmentName(rdr["DepttId"].ToString());
                    lblBatch.Text = rdr["Batch"].ToString();
                    lblAmount.Text = rdr["FeeAmount"].ToString();
                    lblStatus.Text = rdr["Status"].ToString();
                    lblDatePaid.Text = rdr["TimeStamp"].ToString();
                    lbltemp3.Text = rdr["txn_id"].ToString();
                }
            }

        }










    }
}
