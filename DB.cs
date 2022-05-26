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
                    conn.Close();
                    
                }
                return conn;
            
        
        }

        

        internal static bool DoSql(SqlConnection conn, string sql)
        {

            
            using (SqlCommand SqlCmd = new SqlCommand(sql, conn))
            {
                try
                {
                    var numrows = SqlCmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;

                }

            }

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

        // metodo per gestire un codice unico tramite una tabella di dedicata
        internal static long GetUnicoId()
        {
            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");
            
            string cmd = "UPDATE CodiceUnico SET Codice = Codice + 1 OUTPUT INSERTED.Codice";
            long id;
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    reader.Read();
                    id = reader.GetInt64(0);
                }
            }
            conn.Close();
            return id;
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

       
        // addLibro aggiunge i dati sia in documenti che in Libri che Autori
        // e tabella ponte Autori_Documenti

        
        internal static int libroAdd(Libro libro, List<Autore>listaAutori)
        {
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Non è possibile connettersi");
            }

            var ok = DoSql(conn, "begin transaction\n");

            if (!ok) throw new System.Exception("Errore in transaction");
            
             // insert into documenti
            
            var cmd = String.Format(@"insert into Documenti(Codice,Titolo,Settore,Stato,Tipo,Scaffale)
                values ({0},'{1}','{2}','{3}','libro','{4}')", libro.Codice,libro.Titolo,libro.Settore,libro.Stato.ToString(),libro.Scaffale.Numero);

            using (SqlCommand insert = new SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    
                    if (numrows != 1) {
                        DoSql(conn, "rollback transaction\n");
                        conn.Close();
                        throw new Exception("Insert in documenti non andato"); }

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DoSql(conn, "rollback transaction\n");
                    conn.Close();
                    return 0;

                }
                
            }

            var cmd1 = String.Format(@"insert into Libri(Codice,NumPagine) values ({0},{1})", libro.Codice,libro.NumeroPagine);

            using (SqlCommand insert = new SqlCommand(cmd1, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                   
                    if (numrows != 1)
                    {
                        DoSql(conn, "rollback transaction\n");
                        conn.Close();

                        throw new Exception("Insert in documenti non andato");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DoSql(conn, "rollback transaction\n");
                    conn.Close();
                    return 0;

                }

            }

            foreach (Autore autore in listaAutori)
            {

                var cmd2 = String.Format(@"insert into Autori(codice,Nome,Cognome,mail) values({0},'{1}','{2}','{3}')",autore.codiceAutore,autore.Nome, autore.Cognome, autore.mail);

                using (SqlCommand insert = new SqlCommand(cmd2, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();
                        
                        if (numrows != 1)
                        {
                            DoSql(conn, "rollback transaction\n");
                            conn.Close();
                            
                            throw new Exception("Insert in documenti non andato");
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        DoSql(conn, "rollback transaction\n");
                        conn.Close();
                        return 0;

                    }


                }

            }


            foreach (Autore autore in listaAutori)
            {
                var cmd3 = String.Format(@"insert into Autori_documenti(codice_autore,codice_documento) values({0},{1})",autore.codiceAutore, libro.Codice );

                using (SqlCommand insert = new SqlCommand(cmd3, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();
                       
                        if (numrows != 1)
                        {
                            DoSql(conn, "rollback transaction\n");
                            conn.Close();
                            throw new Exception("Insert in documenti non andato");
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        DoSql(conn, "rollback transaction\n");
                        conn.Close();
                        return 0;

                    }
                    

                }
            }
            DoSql(conn, "commit transaction\n");
            conn.Close();
            return 0;


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

        //metodo richiesto: implementare una select che seleziona tutti i libri e gli autori usando l'inner join 

        internal static List<List<string>> libriConAutoriGet()
        {
            var data = new List<List<string>>();

            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");

            var cmd = String.Format(@"select * from Documenti inner join Libri on Documenti.codice = Libri.codice 
                             inner join Autori_documenti on Documenti.codice = Autori_documenti.codice_documento
                             inner join Autori on Autori_documenti.codice_autore = Autori.codice"); 
                 
            
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())

                {
                   

                    while (reader.Read())
                    {

                        var ls = new List<string>();

                        ls.Add(reader.GetInt64(0).ToString());
                        ls.Add(reader.GetString(1));
                        ls.Add(reader.GetString(2));
                        ls.Add(reader.GetString(3));
                        ls.Add(reader.GetString(4));
                        ls.Add(reader.GetString(5));
                        ls.Add(reader.GetInt64(6).ToString());
                        ls.Add(reader.GetInt64(7).ToString());
                        ls.Add(reader.GetInt64(8).ToString());
                        ls.Add(reader.GetInt64(9).ToString());
                        ls.Add(reader.GetInt64(10).ToString());
                        ls.Add(reader.GetString(11));
                        ls.Add(reader.GetString(12));
                        ls.Add(reader.GetString(13));
       
                       data.Add(ls);
                    }
                }
            }
            conn.Close();
            return data;

        }

    }
}
