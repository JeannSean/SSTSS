using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace db_misc
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstss_thor");
            try
            {
                Console.WriteLine("Connecting.........");
                conn.Open();
                Console.WriteLine("Connection Success!");

            }
            catch(Exception e)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
