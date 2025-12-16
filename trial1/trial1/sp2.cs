using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trial1
{
    internal class sp2
    {
       public void main2()
        {
            String connection2 = @"server=localhost\SQLEXPRESS;database=EmployersDB;trusted_connection=true";
            DataSet ds2 = new DataSet();

            using (SqlConnection con2 = new SqlConnection(connection2))
            {
                using (SqlCommand cmd2 = new SqlCommand("viewemployees",con2))
                {
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id", 2);

                    using (SqlDataAdapter da2 = new SqlDataAdapter(cmd2))
                    {
                        da2.Fill(ds2);
                    }
                }
            }

            DataTable dt2 = ds2.Tables[0];

            foreach (DataRow row in dt2.Rows)
            {
                Console.WriteLine($"id {row["Empid"]} - name { row["EmpName"]} - department { row["EmpDept"]} - age { row["EmpAge"]}");
            }
        }
    }
}
