using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Queue_Free.Util;

namespace Queue_Free.Admin
{
    public partial class Student_Fee_Status : System.Web.UI.Page
    {
        
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlDepttName.Items.Clear();



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

                    GetBatchFrosmb();
                    GetSessionNameFrosmb();


                }
            }
        }

       

        private void GetBatchFrosmb()
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







        private void GetSessionNameFrosmb()
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

        protected void ddlSessionName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnGetStatus_Click(object sender, EventArgs e)
        {




            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("SELECT Students.Rollno, Students.StudentFullName, StudentFeeStatus.Status,Students.Batch, StudentFeeStatus.FeeAmount, StudentFeeStatus.txn_id, Session.SessionName, Students.DepttId FROM     StudentFeeStatus INNER JOIN Session ON StudentFeeStatus.SessionId = Session.SessionId INNER JOIN Students ON StudentFeeStatus.Rollno = Students.Rollno where Students.DepttId = @depttid and SessionName =@sessionName and Batch =@batch", con);

                csm.Parameters.AddWithValue("@depttid",FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
                csm.Parameters.AddWithValue("@sessionName", ddlSessionName.Text);
                csm.Parameters.AddWithValue("@batch", ddlBatch.Text);

                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();

                gvStudentFeeStatusAdmin.DataSource = rdr;
                gvStudentFeeStatusAdmin.DataBind();
            }


        }

        protected void btnGetSummary_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("SELECT distinct Students.Batch, Session.SessionName, StudentFeeStatus.Rollno, StudentFeeStatus.Status, StudentFeeStatus.Semester FROM     Session INNER JOIN StudentFeeStatus ON Session.SessionId = StudentFeeStatus.SessionId INNER JOIN  Students ON StudentFeeStatus.Rollno = Students.Rollno where Students.DepttId = @depttid and SessionName =@sessionName and Batch = @batch", con);

                csm.Parameters.AddWithValue("@depttid",FeeHelper2.ConvertDepartmentNameToId(ddlDepttName.Text));
                csm.Parameters.AddWithValue("@sessionName", ddlSessionName.Text);
                csm.Parameters.AddWithValue("@batch", ddlBatch.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();

                gvStudentFeeStatusAdmin.DataSource = rdr;
                gvStudentFeeStatusAdmin.DataBind();
            }
        }

        protected void btnGetPdf_Click(object sender, EventArgs e)
        {
            Paragraph paragraph;
            int columns = 0;
            iTextSharp.text.Font fdefault = FontFactory.GetFont("Arial", 17, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);

            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logoBGSB.jpg"));
            logo.SetAbsolutePosition(30, 760);
            logo.ScaleAbsoluteHeight(65);
            logo.ScaleAbsoluteWidth(60);



            string SoET = "School of Engineering Technology";
            paragraph = new Paragraph(SoET, fdefault);
            paragraph.IndentationLeft = 150;
            paragraph.SpacingAfter = 10;
            

            string Bgsbu = "Baba Ghulam Shah Badshah University";
            Paragraph paragraph1 = new Paragraph(Bgsbu, fdefault);
            paragraph1.IndentationLeft = 135;
            paragraph1.SpacingAfter = 10;
            paragraph1.SpacingBefore = -10;


            string Rjri = "Rajouri, Jammu and Kashmir (185234).";
            Paragraph paragraph2 = new Paragraph(Rjri, fdefault);
            paragraph2.IndentationLeft = 137;
            paragraph2.SpacingAfter = 10;
            paragraph2.SpacingBefore = -10;

            Paragraph LineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            paragraph.SpacingAfter = 30;

            

            string summary = "Summary for the fee details of students from the department of " + ddlDepttName.Text + " batch " + ddlBatch.Text + " for the session " + ddlSessionName.Text;
            Paragraph paraSummary = new Paragraph(summary);
            paragraph.SpacingAfter = 30;


            Paragraph LineSeparator1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            paragraph.SpacingAfter = 30;

            if (gvStudentFeeStatusAdmin.Rows.Count >0)
            {
                columns = gvStudentFeeStatusAdmin.Rows[0].Cells.Count;
                //rows = gvStudentFeeStatusAdmin.Columns.Count;
            }

            


            PdfPTable table = new PdfPTable(columns);
            table.SpacingBefore = 30;
            int padding = 2;
            //float[] widths = new float[8];
            for (int x = 0; x < columns; x++)
            {
              //  widths[x] = (float)gvStudentFeeStatusAdmin.Columns[x].ItemStyle.Width.Value;
                string cellText = gvStudentFeeStatusAdmin.HeaderRow.Cells[x].Text;
                PdfPCell cell = new PdfPCell(new Phrase(cellText))
                {
                    BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#fffffff")),
                    Padding = padding
                };
                table.AddCell(cell);

            }
           // table.SetTotalWidth(widths);
           // table.LockedWidth = true;


            for (int i = 0; i < gvStudentFeeStatusAdmin.Rows.Count; i++)
            {
                if (gvStudentFeeStatusAdmin.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        string cellText = gvStudentFeeStatusAdmin.Rows[i].Cells[j].Text;
                        PdfPCell cell = new PdfPCell(new Phrase(cellText))
                        {
                            Padding = padding

                        };
                        //if (i % 2 != 0)
                        //{
                        //    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                        //}
                        table.AddCell(cell);

                    }
                }
            }
            Response.ContentType = "pdf/application";
            Response.AddHeader("content-disposition", "attachment;filename=Student Fee Status.pdf");
            Document pdfDoc = new Document(PageSize.A4);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(logo);
            pdfDoc.Add(paragraph);
            pdfDoc.Add(paragraph1);
            pdfDoc.Add(paragraph2);
            pdfDoc.Add(LineSeparator);
            pdfDoc.Add(paraSummary);
            pdfDoc.Add(LineSeparator1);
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.End();
        }


    }
}










//ExportToPDFWithFormatting();




//protected void ExportToPDFWithFormatting()
//{
//    //link button column is excluded from the list
//    int colCount = gvStudentFeeStatusAdmin.Columns.Count - 1;

//    //Create a table
//    PdfPTable table = new PdfPTable(colCount);
//    table.HorizontalAlignment = 0;
//    table.WidthPercentage = 100;

//    //create an array to store column widths
//    int[] colWidths = new int[gvStudentFeeStatusAdmin.Columns.Count];

//    PdfPCell cell;
//    string cellText;

//    //create the header row
//    for (int colIndex = 0; colIndex < colCount; colIndex++)
//    {
//        //set the column width
//        colWidths[colIndex] = (int)gvStudentFeeStatusAdmin.Columns[colIndex].ItemStyle.Width.Value;

//        //fetch the header text
//        cellText = Server.HtmlDecode(gvStudentFeeStatusAdmin.HeaderRow.Cells[colIndex].Text);

//        //create a new cell with header text
//        cell = new PdfPCell(new Phrase(cellText));

//        //set the background color for the header cell
//        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

//        //add the cell to the table. we dont need to create a row and add cells to the row
//        //since we set the column count of the table to 4, it will automatically create row for
//        //every 4 cells
//        table.AddCell(cell);
//    }

//    //export rows from GridView to table
//    for (int rowIndex = 0; rowIndex < gvStudentFeeStatusAdmin.Rows.Count; rowIndex++)
//    {
//        if (gvStudentFeeStatusAdmin.Rows[rowIndex].RowType == DataControlRowType.DataRow)
//        {
//            for (int j = 0; j < gvStudentFeeStatusAdmin.Columns.Count - 1; j++)
//            {
//                //fetch the column value of the current row
//                cellText = Server.HtmlDecode(gvStudentFeeStatusAdmin.Rows[rowIndex].Cells[j].Text);

//                //create a new cell with column value
//                cell = new PdfPCell(new Phrase(cellText));

//                //Set Color of Alternating row
//                if (rowIndex % 2 != 0)
//                {
//                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#9ab2ca"));
//                }
//                else
//                {
//                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#f1f5f6"));
//                }
//                //add the cell to the table
//                table.AddCell(cell);
//            }
//        }
//    }

//    //Create the PDF Document
//    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

//    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

//    //open the stream
//    pdfDoc.Open();

//    //add the table to the document
//    pdfDoc.Add(table);

//    //close the document stream
//    pdfDoc.Close();

//    Response.ContentType = "application/pdf";
//    Response.AddHeader("content-disposition", "attachment;" + "filename=Product.pdf");
//    Response.Cache.SetCacheability(HttpCacheability.NoCache);
//    Response.Write(pdfDoc);
//    Response.End();
//}






