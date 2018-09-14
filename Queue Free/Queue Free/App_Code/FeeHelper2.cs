using System;
using System.Data.SqlClient;
using System.Configuration;


namespace Queue_Free.Util
{
    public class FeeHelper2
    {
        static public int ConvertDepartmentNameToId(string name)
        {
            int result = 0;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select DepttID from dbo.Deptts where DepttFullName=@deptfullname", con);
                csm.Parameters.AddWithValue("@deptfullname", name);
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = Convert.ToInt32(rdr["DepttID"].ToString());
                    rdr.Close();
                    return (result);


                }
                rdr.Close();
                return (result);


            }
        }
    }
}