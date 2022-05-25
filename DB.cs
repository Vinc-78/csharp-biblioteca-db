using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class DB
    {
       private static string connectionString = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";

        private static SqlConnection Connect() 
        {
            SqlConnection conn = new SqlConnection(connectionString);
            
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return conn;
            
        
        }


        internal static int scaffaleAdd(string nuovo)
        { 
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Non è possibile connettersi");
            }

            var cmd = String.Format($"insert into Scaffale (Scaffale) values ('{nuovo}')");

            using (SqlCommand insert = new SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    return numrows;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;

                }
                finally
                {
                    conn.Close();
                }
            }
        
        }



    }
}
