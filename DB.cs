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

        //metodo per leggere e caricare i dati in una lista di appoggio
        internal static List<string> scaffaliGet()
        { 
            List<string> scaffali = new List<string>();

            var conn = Connect();
            if (conn == null)  throw new Exception("Non è possibile connettersi");

            var cmd = String.Format("select Scaffale from Scaffale"); //li prendo tutti

            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    
                    while (reader.Read())
                    { 
                        scaffali.Add(reader.GetString(0));
                    }
                }
            }
            
            conn.Close();

            return scaffali;
        
        }

        //nel caso ci siano più attributi, allora potete utilizzare le tuple( metodo generico da adattare )
        internal static List<Tuple<int, string, string, string, string, string>> documentiGet()
        {
            var ld = new List<Tuple<int, string, string, string, string, string>>();
            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");
            var cmd = String.Format("select codice, Titolo, Settore, Stato, Tipo, Scaffale from Documenti");  //Li prendo tutti
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Tuple<Int32, string, string, string, string, string>(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5));
                        ld.Add(data);
                    }
                }
            }
            conn.Close();
            return ld;
        }

        // addLibro aggiunge sia in documenti che in Libri  //da implementare ancora!!!!
        /*
        internal static int libroAdd(Libro libro)
        {
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Non è possibile connettersi");
            }

            // insert documenti e poi insert in libro
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

        */

    }
}
