using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    public class managestu
    {
        private string connection = "server=localhost\\SQLEXPRESS;database=studentsDB;trusted_connection=true";

        // insert
        public void insertdata(Student stu)
        {
            string query = @"insert into Students(id, name, detailsid)
              values (@id, @name, @detailsid);";

            using (SqlConnection con = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", stu.id);
                cmd.Parameters.AddWithValue("@name", stu.name);
                cmd.Parameters.AddWithValue("@detailsid", stu.detailsid);

                con.Open();

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "student inserted successfully" : "insert failed");
            }
        }
    }
}
