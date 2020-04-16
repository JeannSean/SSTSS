using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_misc;
namespace Testing_Form.Controls
{
    public partial class Class_box : UserControl
    {
        DBCmmnds dbcmd = new DBCmmnds();
        /// <attribute>
        private string v_subcode;
        private string v_instrctr;
        private string v_stime;
        private string v_etime;
        private string v_room;
        private string v_panelname;
        private table_module_day parent { get; set; }
        private string section { get; set; }
        private string day { get; set; }
        private string subcode { get { return v_subcode; } 
            set 
            { 
                v_subcode = value;
                subject_label.Text = dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '" + value + "'");
            } 
        }
        private string instructor { get { return v_instrctr; } 
            set 
            { 
                v_instrctr = value;
                Instructor_Label.Text = dbcmd.getData("SELECT CONCAT(`last_name`,\", \",`first_name`,\" \",`middle_name`) AS `first_name` FROM `sstss_data`.`tbl_instrctr` WHERE `instructor_id` = '"+ value + "'");
            } 
        }
        private string start_time { get { return v_stime; } 
            set 
            {
                v_stime = value;
                class_time.Text = dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'");
            } 
        }
        private string end_time { get { return v_etime; } 
            set 
            { 
                v_etime = value;
                class_time.Text += " - "+ dbcmd.getData("SELECT TIME_FORMAT(`time`, '%h:%i') FROM `sstss_data`.`tbl_time` WHERE `time_id` = '" + value + "'");
            } 
        }
        private string room { get { return v_room; } 
            set 
            { 
                v_room = value;
                Room_label.Text = dbcmd.getData("SELECT `description` FROM `sstss_data`.`tbl_room` WHERE `room_id` = '" + value + "'");
            } 
        }
        private string panelname
        { get { return v_panelname; } 
            set 
            {
                v_panelname = value;
                this.Name = value;
                //label1.Text = this.Name;
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

        public void setPanelname(string value)
        {
            panelname = value;
        }
        public void setDay(string value)
        {
            day = value;
        }
        public void setParet(table_module_day value)
        {
            parent = value;
            parent.triggerDispose += switchDispose;
        }
        /// </setValue>

        public Class_box()
        {
            InitializeComponent();
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {            
            Edit_box calledbox = new Edit_box();
            calledbox.setPanelname(panelname);
            calledbox.setDay(day);
            if(subcode!=null)
                calledbox.setSubjetcode(subcode);
            if (instructor != null)
                calledbox.setInstructor(instructor);
            if (start_time != null)
                calledbox.setStartingTime(start_time);
            if (end_time != null)
                calledbox.setEndingTime(end_time);
            if (room != null)
                calledbox.setRoom(room);
            if (section != null)
                calledbox.setSection(section);
            calledbox.onSave += updateClass;
            calledbox.ShowDialog();

        }

        public event EventHandler onClassUpdate;

        private void updateClass(object sender, EventArgs e)
        {
            onClassUpdate?.Invoke(this,EventArgs.Empty);
            this.Dispose();
        }        


        private void switchDispose(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            dbcmd.addData("DELETE FROM `sstss_data`.`tbl_class` WHERE  `panel_name` = '" + panelname + "'");
            this.ParentForm.Controls.Remove(this);
            this.Dispose();
            onControlCountChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler onControlCountChanged;

    }
}
