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
        private string v_subcode;
        private string v_instrctr;
        private string v_stime;
        private string v_etime;
        private string v_room;

        internal string subcode{ get { return v_subcode; } set { v_subcode = value;  } }
        internal string instructor { get { return v_instrctr; } set { v_instrctr = value; } }
        internal string start_time { get { return v_stime; } set { v_stime = value; } }
        internal string end_time { get { return v_etime; } set { v_etime = value; } }
        internal string room { get { return v_room; } set { v_room = value; } }
        
        /// </summary>/
        public Edit_box(string[] data)
        {            
            //  0 - subcode
            //  1 - insrtructor 
            //  2 - start time
            //  3 - end time
            //  4 - room
            //  5 - section(hidden)
            //  6 - panel
            InitializeComponent();
            label1.Text = data[6];
            if (data[0] != null)
            {
                subject_code_textbox.Text = data[0];

            }
            if (data[1] != null)
            {
                instructor_dropdown.Text = data[1];
            }
            if (data[2] != null)
            {
                start_time_dropdown.Text = data[2];
            }
            if (data[3] != null)
            {
                end_time_dropdown.Text = data[3];
            }
            if (data[4] != null)
            {
                room_dropdown.Text = data[4];
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

        private void button_save_Click(object sender, EventArgs e)
        {
            DBCmmnds dbcmmnd = new DBCmmnds();
        }

        private void instructor_dropdown_DropDown(object sender, EventArgs e)
        {
            DBCmmnds dbcmd = new DBCmmnds();
            foreach (string strdata in dbcmd.getInsDD())
            {
                //Console.WriteLine(strdata);
                instructor_dropdown.Items.Add(strdata);
            }
        }

        private void room_dropdown_DropDown(object sender, EventArgs e)
        {
            DBCmmnds dbcmd = new DBCmmnds();
            foreach (string strdata in dbcmd.getRoomDD())
            {
                //Console.WriteLine(strdata);
                room_dropdown.Items.Add(strdata);
            }
        }
    }
}
