using System;
using System.Collections;
using MySql.Data.MySqlClient;


namespace db_misc
{
    public class DBCmmnds
    {
        /// <universal>
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

        /// </universal>       

        public ArrayList getValues(String query)
        {
            ArrayList list = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");            
            try
            {
                conn.Open();
                string stm = query;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string[] temp = new string[dataReader.VisibleFieldCount];
                    for (int i=0;i< dataReader.VisibleFieldCount; i++)
                    {
                        temp[i] = Convert.ToString(dataReader[i]);
                        //Console.WriteLine(temp[i]);
                    }
                    list.Add(temp);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine(e.Message);
            }
            conn.Close();            
            return list;
        }


        public ArrayList getIntValues(String query)
        {
            ArrayList list = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {
                conn.Open();
                string stm = query;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int[] temp = new int[dataReader.VisibleFieldCount];
                    for (int i = 0; i < dataReader.VisibleFieldCount; i++)
                    {
                        temp[i] = Convert.ToInt32(dataReader[i]);
                        //Console.WriteLine(temp[i]);
                    }
                    list.Add(temp);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed!");
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return list;
        }



    }
}


/*       

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

