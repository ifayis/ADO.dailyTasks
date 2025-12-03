using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    public class managestudent
    {
        private string conn = "server=localhost\\SQLEXPRESS;database=studentsDB;trusted_connection=true";

        public void getdetails()
        {
            string query = @"
                select s.id, s.name, d.department, d.mark
                from students s
                inner join studentdetails d
                on s.detailsid = d.detailsid";

            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connect);
                connect.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"id : {dr["id"]}" +
                        $"name : {dr["name"]}" +
                        $"department : {dr["department"]}" +
                        $"mark : {dr["mark"]}"
                        );
                }
            }
        }
    }
}
