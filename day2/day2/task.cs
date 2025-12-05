using System;
using System.Data;
using System.Data.SqlClient;

namespace day2
{
    internal class task
    {
        private string connection =
            @"Server=localhost\SQLEXPRESS;Database=StudentsDB;Trusted_Connection=True;";

        public void run()
        {
            // CREATE DATA ADAPTER
            string query = "SELECT  detailsid ,Age FROM studentdetails";

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                // auto-generate INSERT/UPDATE/DELETE from the SELECT
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                // FILL DATASET
                DataSet ds = new DataSet();
                da.Fill(ds, "studentdetails");   // creates DataTable "studentdetails"

                DataTable studentsTable = ds.Tables["studentdetails"];

                Console.WriteLine("Row count: " + studentsTable.Rows.Count);
                Console.WriteLine("=== ORIGINAL DATA ===");
                PrintTable(studentsTable);

                // MODIFY DATA IN DATASET (change age of one student)
                // Example: set Age = 30 for StudentID = 1
                foreach (DataRow row in studentsTable.Rows)
                {
                    if (Convert.ToInt32(row["detailsid"]) == 1)
                    {
                        row["Age"] = 30;  // change in memory (DataSet only)
                    }
                }

                Console.WriteLine("\n=== DATA AFTER CHANGE IN DATASET (BEFORE UPDATE) ===");
                PrintTable(studentsTable);

                // SAVE CHANGES BACK TO DATABASE
                int rowsUpdated = da.Update(ds, "studentdetails");
                Console.WriteLine($"\nRows updated in database: {rowsUpdated}");

                // FILTER USING DATAVIEW (e.g., Age = 30)
                Console.WriteLine("\n=== FILTERED DATA (Age = 30) USING DATAVIEW ===");

                DataView view = new DataView(studentsTable);
                view.RowFilter = "Age = 30";

                foreach (DataRowView drv in view)
                {
                    Console.WriteLine(
                        $"DetailsID: {drv["detailsid"]}  " +
                        $"Age: {drv["Age"]}"
                    );
                }
            }
        }

        private void PrintTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(
                        $"DetailsID: {row["detailsid"]}  " +
                        $"Age: {row["Age"]}"
                );
            }
        }
    }
}
