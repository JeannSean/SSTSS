using System;
using MySql.Data.MySqlClient;
namespace db_misc
{
    public class DBCmmnds
    {

        public void addData(String query)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {            
                conn.Open();
                string stm = query;   
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.ExecuteNonQuery();
                                
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine(e.Message);
            }
            conn.Close();
            Console.WriteLine("Data Added!");
        }

        public string getData(String query){
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            string data="";
            try 
            {            
                conn.Open();
                string stm = query;   
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                data = Convert.ToString(cmd.ExecuteScalar());
            } catch (MySqlException ex) 
            {
                Console.WriteLine("Error: {0}",  ex.ToString());
            }
            conn.Close();
            return data;
        }
        /*       
        try 
        {
          conn = new MySqlConnection(cs);
          conn.Open();

          string stm = "SELECT VERSION()";   
          MySqlCommand cmd = new MySqlCommand(stm, conn);
          string version = Convert.ToString(cmd.ExecuteScalar());
          Console.WriteLine("MySQL version : {0}", version);

        } catch (MySqlException ex) 
        {
          Console.WriteLine("Error: {0}",  ex.ToString());

        }
        _______________________________ 
        
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {
                Console.WriteLine("Connecting.........");
                conn.Open();
                Console.WriteLine("Connection Success!");
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine(e.Message);
            }
        */

        

    }
}
