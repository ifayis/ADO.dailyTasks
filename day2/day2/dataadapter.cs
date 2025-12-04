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
        public void run()
        {
            string connection = @"server=localhost\SQLEXPRESS;Database=StudentsDB;Trusted_connection=true";

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select *  from students", con); // created data adapter
                SqlDataAdapter da2 = new SqlDataAdapter("select * from studentdetails", con);

                DataTable dt = new DataTable(); // created data table
                da1.Fill(dt); // fill data table

                DataSet ds = new DataSet(); // created data set
                da2.Fill(ds, "studentdetails"); // fill data set

                // print rows
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["Id"]} - {row["Name"]}");
                }

                foreach (DataRow row1 in ds.Tables["studentdetails"].Rows)
                {
                    Console.WriteLine($"{row1["studentid"]} - {row1["department"]} - {row1["mark"]}");
                }
            }
        }
    }
}
