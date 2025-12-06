using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3
{
    internal class storedprocedure
    {
        String connection = @"server=localhost\SQLEXPRESS;database=StudentsDB;trusted_connection=true";
        
        public void getstudentdetails(int id)
        {
            using (SqlConnection con = new SqlConnection(connection)) 
            using (SqlCommand cmd = new SqlCommand("getallstudents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Console.WriteLine(
                            $"id{ dr["id"]}" +
                            $"name{ dr["name"]}" +
                            $"age { dr["age"]}"
                            );
                    }
                    else
                    {
                        Console.WriteLine("data not available with the id" + id);
                    }
                }
            } 
        }
    }
}
