using System;
using System.Data.SqlClient;
using System.Configuration;


namespace Queue_Free.Util
{

    public class FeeHelper
    {        

      static  public   int convertsessionnametoid(string name)
        {
            int result = 0;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select SessionId from dbo.Session where SessionName=  @SessionName", con);
                csm.Parameters.AddWithValue("@SessionName", name);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = Convert.ToInt32(rdr["SessionId"].ToString());
                    rdr.Close();
                    return (result);


                }
                rdr.Close();
                return (result);


            }
        }

    }
}