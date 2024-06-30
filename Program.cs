using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLDataSetADO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string emp_query = "select * from Employee_tbl";
                string student_query = "select * from Student_tbl";



                #region
                string query = "spGetStudents";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ds.Tables[0].TableName = "Employee_tbl";
                ds.Tables[1].TableName = "Student_tbl";

                foreach (DataRow row in ds.Tables["Employee_tbl"].Rows)
                {
                    Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3] + " " + row[4] + " " + row[5]);
                }
                Console.WriteLine("---------------------------------------------------------------");

                foreach (DataRow row in ds.Tables["Student_tbl"].Rows)
                {
                    Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3] + " " + row[4] + " ");
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                throw;
            }
            Console.ReadLine();

        }
    }
}
