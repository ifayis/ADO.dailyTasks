using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trial1
{
    internal class sp
    {
        public void main()
        {
            String connection = @"server=localhost\SQLEXPRESS;database=newstudentsDB;trusted_connection=true";
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("viewstudents", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",1);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"id : {row["id"]} - name : {row["name"]} - age : {row["age"]}");
            }
        }
    }
}
