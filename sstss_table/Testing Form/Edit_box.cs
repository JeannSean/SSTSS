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
                instructor_dropdown.Text = (value != null) ? dbcmd.getData("SELECT CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) AS `first_name` FROM `sstss_data`.`tbl_instrctr` WHERE `instructor_id` = '"+value+"'"):"Instructor";
            }
        }
        private string start_time
        {
            get { return v_stime; }
            set
            {
                v_stime = value;
                start_time_dropdown.Text = (value != null) ? dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'"):"Starting Time";
            }
        }
        private string end_time
        {
            get { return v_etime; }
            set
            {
                v_etime = value;
                end_time_dropdown.Text = (value != null) ? dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'"):"Ending Time";
            }
        }
        private string room
        {
            get { return v_room; }
            set
            {
                v_room = value;
                room_dropdown.Text = (value!=null)?dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_room` WHERE `room_id` = '" + value + "'"):"Room";
            }
        }

        private string section { get; set; }

        private string panelname
        {
            get { return v_panelname; }
            set
            {
                v_panelname = value;
                //label1.Text = value;
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
            //label1.Text = value;
        }
        public void setSection(string value)
        {
            section = value;
        }
        public void setDay(string value)
        {
            day = value;
            //label2.Text = value;
        }
        /// </setValue>
        public Edit_box()
        {            
            InitializeComponent();
            
        }

        private void subject_code_textbox_OnValueChanged(object sender, EventArgs e)
        {
            subcode = subject_code_textbox.Text;
            string subjctcode = subject_code_textbox.Text; 
            subject_code_display.Text = dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '" + subjctcode + "';");
        }

        private void button_discard_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public event EventHandler onSave;
        private void button_save_Click(object sender, EventArgs e)
        {
            if (dbcmd.getData("SELECT COUNT(*) FROM `sstss_data`.tbl_class WHERE `panel_name` = '" + panelname + "'") != "0")
                dbcmd.addData("DELETE FROM `sstss_data`.`tbl_class` WHERE  `panel_name` = '" + panelname + "'");
            dbcmd.addData("INSERT INTO `sstss_data`.`tbl_class` (`class_id`, `fk_day`, `panel_name`, `fk_subject`, `fk_instructor`, `fk_time`, `fk_etime`, `fk_room`) VALUES ('" + section + "', '" + 
                day
                + "', '" + 
                panelname 
                + "', '" + 
                subject_code_textbox.Text 
                + "', '" +
                instructor
                + "', '" +
                start_time
                + "', '" +
                end_time
                + "', '" +
                room
                + "')");
            this.Dispose();
            onSave?.Invoke(this, EventArgs.Empty);
            
        }

        private void instructor_dropdown_DropDown(object sender, EventArgs e)
        {
            
            instructor_dropdown.Items.Clear();
            foreach (string[] arStr in dbcmd.getValues("SELECT CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) FROM `tbl_instrctr` ORDER BY `last_name` ASC") )
            {
                foreach (string s in arStr) {
                    //Console.WriteLine(strdata);
                    instructor_dropdown.Items.Add(s);
                }
            }
        }

        private void room_dropdown_DropDown(object sender, EventArgs e)
        {
            room_dropdown.Items.Clear();
            foreach (string[] arStr in dbcmd.getValues("SELECT `description` FROM `tbl_room` ORDER BY `description` ASC"))
            {
                foreach (string s in arStr)
                {
                    //Console.WriteLine(strdata);
                    room_dropdown.Items.Add(s);
                }
            }

        }

        private void start_time_dropdown_DropDown(object sender, EventArgs e)
        {
            start_time_dropdown.Items.Clear();    
            foreach (string strdata in sortSTime())
            {
                //Console.WriteLine(strdata);
                if (!strdata.Contains("29") && !strdata.Contains("59"))
                    start_time_dropdown.Items.Add(strdata);
                
                
            }
            
        }

        private void start_time_dropdown_TextChanged(object sender, EventArgs e)
        {
            start_time = dbcmd.getData("SELECT `time_id` FROM `sstss_data`.`tbl_time` WHERE TIME_FORMAT(`time`, '%h:%i') = '" + start_time_dropdown.Text + "'");
            if (start_time_dropdown.Text != "Starting time")
                end_time_dropdown.Enabled = true;
            else
                end_time_dropdown.Enabled = false;
            end_time_dropdown_content();
        }

        private ArrayList sortSTime()
        {
            ArrayList baselist = new ArrayList(),
                      occupiedtime = dbcmd.getIntValues("SELECT `fk_time`,`fk_etime` FROM `sstss_data`.`tbl_class` WHERE `class_id`= " + section),
                      temp = new ArrayList();
            //dbcmd.getIntValues("SELECT `fk_etime` FROM `sstss_data`.`tbl_class` WHERE `class_id`= " + section)            
            foreach (int[] elem in dbcmd.getIntValues("SELECT `fk_time`,`fk_etime` FROM `sstss_data`.`tbl_class` WHERE `fk_instructor`= '" + instructor+"' AND `class_id` != " + section))
            {                
                occupiedtime.Add(elem);
            }
            foreach (int[] i in dbcmd.getIntValues("SELECT `time_id` FROM `sstss_data`.`tbl_time`"))
            {
                foreach (int it in i)
                {
                    temp.Add(it);
                }
            }
            foreach (int[] elem in occupiedtime)
            {
                for (int i = elem[0];i<=elem[1];i++)
                {
                    temp.Remove(i); 
                }
            }
            foreach (int s in temp)
            {
                if(temp.Contains(s + 3) )
                    baselist.Add(dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '"+s+"'"));                
            }
            
            return baselist;
        }


        private ArrayList sortETime(string stime)
        {
            int srtime = Convert.ToInt32(start_time);
            ArrayList baselist = new ArrayList(),
                      occupiedtime = dbcmd.getIntValues("SELECT `fk_time`,`fk_etime` FROM `sstss_data`.`tbl_class` WHERE `class_id`= " + section),
                      temp = new ArrayList();
            //dbcmd.getIntValues("SELECT `fk_etime` FROM `sstss_data`.`tbl_class` WHERE `class_id`= " + section)            
            foreach (int[] elem in dbcmd.getIntValues("SELECT `fk_time`,`fk_etime` FROM `sstss_data`.`tbl_class` WHERE `fk_instructor`= '" + instructor + "' AND `class_id` != " + section))
            {
                occupiedtime.Add(elem);
            }
            foreach (int[] i in dbcmd.getIntValues("SELECT `time_id` FROM `sstss_data`.`tbl_time`"))
            {
                foreach (int it in i)
                {
                    temp.Add(it);
                }
            }
            foreach (int[] elem in occupiedtime)
            {
                for (int i = elem[0]; i <= elem[1]; i++)
                {
                    temp.Remove(i);
                }
            }
            foreach (int s in temp)
            {
                if (s > srtime)
                {
                    //Console.WriteLine(s);
                    if (s >= srtime + 2 && !temp.Contains(s + 1))
                    {
                        break;
                    }
                    if (s>srtime+2)
                    {
                        //Console.WriteLine(s);
                        baselist.Add(dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + s + "'"));
                    }
                }
            }

            return baselist;
        }


        private void instructor_dropdown_TextChanged(object sender, EventArgs e)
        {
            instructor = dbcmd.getData("SELECT `instructor_id` FROM `sstss_data`.`tbl_instrctr` WHERE CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) = '" + instructor_dropdown.Text + "'");
            end_time = null;
            start_time = null;
            room = null;
        }

        private void end_time_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            end_time = dbcmd.getData("SELECT `time_id` FROM `sstss_data`.`tbl_time` WHERE TIME_FORMAT(`time`, '%h:%i') = '" + end_time_dropdown.Text + "'");
        }

        private void room_dropdown_SelectedValueChanged(object sender, EventArgs e)
        {
            room = dbcmd.getData("SELECT `room_id` FROM `sstss_data`.`tbl_room` WHERE `description` = '" + room_dropdown.Text + "'");
        }

        private void end_time_dropdown_DropDown(object sender, EventArgs e)
        {
            end_time_dropdown_content();
        }

        private void end_time_dropdown_content()
        {
            end_time_dropdown.Items.Clear();
            ArrayList list = sortETime(start_time);
            foreach (string strdata in list)
            {
                //Console.WriteLine("qwerty");
                if ((strdata.Contains("29") || strdata.Contains("59")))
                    end_time_dropdown.Items.Add(strdata);


            }
        }
    }
}
