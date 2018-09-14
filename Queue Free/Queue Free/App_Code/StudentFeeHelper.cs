using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Queue_Free.Util
{
    public class StudentFeeHelper
    {


        public static string ConvertSessionIdToSessionName(string Id)
        {
            string result = null;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select SessionName from dbo.Session where SessionId =  @SessionId", con);
                csm.Parameters.AddWithValue("SessionId",System.Convert.ToInt32(Id));
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = rdr["SessionName"].ToString();
                    rdr.Close();
                    return (result);

                }
                rdr.Close();
                return (result);
            }
        }
    }
}