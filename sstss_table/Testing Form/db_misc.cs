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
        public ArrayList getInsDD()
        {
            ArrayList list = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {
                string stm = "SELECT * FROM `tbl_instrctr`";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader dr = cmd.ExecuteReader(); ;
                list.Clear();
                while (dr.Read())
                {
                    list.Add(dr["first_name"] + " " + dr["middle_name"] + " " + dr["last_name"]);
                    
                }
                conn.Close();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            return list;
        }

        public ArrayList getRoomDD()
        {
            ArrayList list = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {
                string stm = "SELECT * FROM `tbl_room`";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader dr = cmd.ExecuteReader(); ;
                list.Clear();
                while (dr.Read())
                {
                    list.Add(dr["description"]);

                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            return list;
        }
        public ArrayList getStimeDD()
        {
            ArrayList list = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=sstss_data;password=sstssthor");
            try
            {
                string stm = "SELECT * FROM `tbl_time`";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader dr = cmd.ExecuteReader(); ;
                list.Clear();
                while (dr.Read())
                {
                    list.Add(dr["time"].ToString());

                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            return list;
        }

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

