using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_misc;

namespace Testing_Form
{
    public partial class Edit_box : Form
    {
        /// <attribute>
        private static string v_subcode;
        private static string v_instrctr;
        private static string v_stime;
        private static string v_etime;
        private static string v_room;

        internal string subcode{ get { return v_subcode; } set { v_subcode = value; } }
        internal string instructor { get { return v_instrctr; } set { v_instrctr = value; } }
        internal string start_time { get { return v_stime; } set { v_stime = value; } }
        internal string end_time { get { return v_etime; } set { v_etime = value; } }
        internal string room { get { return v_room; } set { v_room = value; } }
        
        /// </summary>
        public Edit_box()
        {
            InitializeComponent();
            Console.WriteLine(subcode+" data thrown");
            if (subcode != null)
            {                
                subject_code_textbox.Text = subcode;
                
            }
            if (instructor !=null)
            {
                instructor_dropdown.Text = instructor;
            }
            if (start_time != null)
            {
                start_time_dropdown.Text = start_time;
            }
            if (end_time != null)
            {
                end_time_dropdown.Text = end_time;
            }
            if (room != null)
            {
                room_dropdown.Text = room;
            }


        }

        private void subject_code_textbox_OnValueChanged(object sender, EventArgs e)
        {
            DBCmmnds dbcmmnd = new DBCmmnds(); 
            string subcode = subject_code_textbox.Text; 
            subject_code_display.Text = dbcmmnd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '" + subcode + "';");
        }

        private void button_discard_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
