using System;
using System.Collections;
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
        DBCmmnds dbcmd = new DBCmmnds();
        /// <attribute>
        private string v_subcode;
        private string v_instrctr;
        private string v_stime;
        private string v_etime;
        private string v_room;
        private string v_panelname;
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
                instructor_dropdown.Text = dbcmd.getData("SELECT CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) AS `first_name` FROM `sstss_data`.`tbl_instrctr` WHERE `instructor_id` = '10'");
            }
        }
        private string start_time
        {
            get { return v_stime; }
            set
            {
                v_stime = value;
                start_time_dropdown.Text = dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'");
            }
        }
        private string end_time
        {
            get { return v_etime; }
            set
            {
                v_etime = value;
                end_time_dropdown.Text = dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'");
            }
        }
        private string room
        {
            get { return v_room; }
            set
            {
                v_room = value;
                room_dropdown.Text = dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_room` WHERE `room_id` = '" + value + "'");
            }
        }

        private string section { get; set; }

        private string panelname
        {
            get { return v_panelname; }
            set
            {
                v_panelname = value;
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
            end_time_dropdown.Enabled = true;
        }
        public void setRoom(string value)
        {
            room = value;
        }
        public void setPanelname(string value)
        {
            panelname = value;
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
            
            string subcode = subject_code_textbox.Text; 
            subject_code_display.Text = dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '" + subcode + "';");
        }

        private void button_discard_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public event EventHandler onSave;
        private void button_save_Click(object sender, EventArgs e)
        {
            dbcmd.addData("INSERT INTO `sstss_data`.`tbl_class` (`class_id`, `fk_day`, `panel_name`, `fk_subject`, `fk_instructor`, `fk_time`, `fk_etime`, `fk_room`) VALUES ('" + section + "', '" + 
                dbcmd.getData("SELECT `day_id` FROM `tbl_day` WHERE `description` = '" + day + "'")
                + "', '" + panelname + "', '" + subject_code_textbox.Text + "', '" +
                dbcmd.getData("SELECT `instructor_id` FROM `sstss_data`.`tbl_instrctr` WHERE CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) = '" + instructor_dropdown.Text+"'")
                + "', '" +
                dbcmd.getData("SELECT `time_id` FROM `sstss_data`.`tbl_time` WHERE TIME_FORMAT(`time`, '%h:%i') = '" + start_time_dropdown.Text + "'") 
                + "', '" +
                dbcmd.getData("SELECT `time_id` FROM `sstss_data`.`tbl_time` WHERE TIME_FORMAT(`time`, '%h:%i') = '" + end_time_dropdown.Text + "'")
                + "', '" +
                dbcmd.getData("SELECT `room_id` FROM `sstss_data`.`tbl_room` WHERE `description` = '" + room_dropdown.Text + "'")
                + "')");
            this.Dispose();
            onSave?.Invoke(this, EventArgs.Empty);
            
        }

        private void instructor_dropdown_DropDown(object sender, EventArgs e)
        {
            
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
            ArrayList list =dbcmd.getStimeDD();
            if (instructor_dropdown.Text != "Instructor") {
                
            }
            foreach (string strdata in list)
            {
                //Console.WriteLine(strdata);
                if (list.IndexOf(strdata)%2==0)
                    start_time_dropdown.Items.Add(strdata);
                
                
            }
            
        }

        private void start_time_dropdown_TextChanged(object sender, EventArgs e)
        {
            if (start_time_dropdown.Text != "Starting time")
                end_time_dropdown.Enabled = true;
            end_time_dropdown.Items.Clear();
            ArrayList list = dbcmd.getStimeDD();
            foreach (string strdata in list)
            {
                //Console.WriteLine(strdata);
                if (list.IndexOf(strdata) % 2 != 0&& list.IndexOf(start_time_dropdown.Text)+1< list.IndexOf(strdata))
                    end_time_dropdown.Items.Add(strdata);


            }
        }
    }
}
