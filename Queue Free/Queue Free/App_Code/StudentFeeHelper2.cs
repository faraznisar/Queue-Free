using System.Data.SqlClient;
using System.Configuration;


namespace Queue_Free.Util
{
    public class StudentFeeHelper2
    {
        public static string ConvertDepttIdToDepartmentName(string Id)
        {
            string result = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand csm = new SqlCommand("select DepttFullName from dbo.Deptts where DepttId =@DepttId", con);
                csm.Parameters.AddWithValue("@DepttId", System.Convert.ToInt32(Id));
                con.Open();
                SqlDataReader rdr = csm.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = rdr["DepttFullName"].ToString();
                    rdr.Close();
                    return (result);
                }
                rdr.Close();
                return (result);
            }
        }
    }
}