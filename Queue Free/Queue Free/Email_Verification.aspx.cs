using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net.Mail;

namespace Queue_Free
{
    public partial class Email_Verification : System.Web.UI.Page
    {
        bool flag = false;
        SqlConnection con;
        SqlCommand csm;

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rollno"] != null)
            {
                lbltemp.Text = Session["Rollno"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                csm = new SqlCommand("select Email_ID from Students where Rollno=@rollno", con);
                csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["Email_ID"].ToString() == txtemail.Text)
                    {
                        flag = true;
                        break;

                    }
                }
                if (flag == true)
                {
                    int Passwordlength = 4;
                    string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                    StringBuilder strB = new StringBuilder(100);
                    Random random = new Random();
                    while (0 < Passwordlength--)
                    {
                        strB.Append(valid[random.Next(valid.Length)]);
                    }
                    lblOTP.Text = strB.ToString();

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand csm = new SqlCommand("update dbo.Students set OTP=@otp where Rollno=@rollno", con);

                        csm.Parameters.AddWithValue("@rollno", lbltemp.Text);
                        csm.Parameters.AddWithValue("@OTP", lblOTP.Text);
                        con.Open();
                        csm.ExecuteNonQuery();

                    }
                    //MailMessage mailMsg = new MailMessage("faraz.nisar1@gmail.com", txtemail.Text);
                    //mailMsg.Subject = "OTP for registration of your account at Queue Free.";
                    //mailMsg.Body = "The OTP for your account registration is:"+ lblOTP.Text+". Please use this OTP to register your account at Queue Free. " ;
                    //smtpClient smtpClient = new smtpClient("smtp.gmail.com", 587);
                    //smtpClient.Credentials = new System.Net.NetworkCredential()
                    //{
                    //    UserName = "faraz.nisar1@gmail.com",
                    //    Password = "xxxxxxxxx"
                    //};
                    //smtpClient.EnableSsl = true;
                    //smtpClient.Send(mailMsg);

                    
                    //MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
                    //smtpClient client = new smtpClient();
                    //client.Port = 25;
                    //client.DeliveryMethod = smtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Host = "smtp.gmail.com";
                    //mail.Subject = "this is a test email.";
                    //mail.Body = "this is my test email body";
                    //client.Send(mail);

                    Response.Redirect("~/OTP.aspx");
                }
                else
                {
                    lblStatus.Text = "Email not valid.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }

        }


        
    }
}