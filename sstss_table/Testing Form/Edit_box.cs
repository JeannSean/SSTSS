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
        private string v_class;
        private string day { get; set; }
        private string subcode
        {
            get { return v_subcode; }
            set
            {
                v_subcode = value;
                subject_code_textbox.Text = value;
            }
        }
        private string instructor
        {
            get { return v_instrctr; }
            set
            {
                v_instrctr = value;
                instructor_dropdown.Text = value;
            }
        }
        private string start_time
        {
            get { return v_stime; }
            set
            {
                v_stime = value;
                start_time_dropdown.Text = value;
            }
        }
        private string end_time
        {
            get { return v_etime; }
            set
            {
                v_etime = value;
                end_time_dropdown.Text +=  value;
            }
        }
        private string room
        {
            get { return v_room; }
            set
            {
                v_room = value;
                room_dropdown.Text = value;
            }
        }
        private string section
        {
            get { return v_class; }
            set
            {
                v_class = value;
                label1.Text = value;
            }
        }
        /// </summary>
        
        /// <setValue>
        public void setSubjetcode(string value)
        {
            subcode = value;
        }
        public void setInstructor(string value)
        {
            instructor = value;
        }
        public void setStartingTime(string value)
        {
            start_time = value;
        }
        public void setEndingTime(string value)
        {
            end_time = value;
        }
        public void setRoom(string value)
        {
            room = value;
        }
        public void setSection(string value)
        {
            section = value;
        }
        public void setDay(string value)
        {
            day = value;
        }
        /// </setValue>
        public Edit_box()
        {            
            InitializeComponent();
            
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
            instructor_dropdown.Items.Clear();
            foreach (string strdata in dbcmd.getInsDD())
            {
                //Console.WriteLine(strdata);
                instructor_dropdown.Items.Add(strdata);
            }
        }

        private void room_dropdown_DropDown(object sender, EventArgs e)
        {
            DBCmmnds dbcmd = new DBCmmnds();
            room_dropdown.Items.Clear();
            foreach (string strdata in dbcmd.getRoomDD())
            {
                //Console.WriteLine(strdata);
                room_dropdown.Items.Add(strdata);
            }
        }

        private void start_time_dropdown_DropDown(object sender, EventArgs e)
        {
            start_time_dropdown.Items.Clear();
            DBCmmnds dbcmd = new DBCmmnds();
            foreach (string strdata in dbcmd.getStimeDD())
            {
                //Console.WriteLine(strdata);
                start_time_dropdown.Items.Add(strdata);
            }
        }
    }
}
