using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    internal class dataadapter
    {
        public void main()
        {
            string connection = @"server=localhost\SQLEXPRESS;Database=StudentsDB;Trusted_connection=true";

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter("select *  from students", con); // created data adapter
                DataTable dt = new DataTable(); // created data table
                da.Fill(dt); // fill data table

                // print rows
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["Id"]} - {row["Name"]} - {row["Age"]}");
                }
            }
        }
    }
}
