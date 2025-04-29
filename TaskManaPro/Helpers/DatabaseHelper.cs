using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace TaskManaPro.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString =
            "Data Source=.;Initial Catalog=TaskManaDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}
