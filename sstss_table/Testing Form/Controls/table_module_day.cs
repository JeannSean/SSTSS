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
using System.Collections;

namespace Testing_Form.Controls
{
    public partial class table_module_day : UserControl
    {
        private string v_day;
        
        private string day { get { return v_day; } 
            set { 
                v_day = value;
                day_label.Text = value;
            } 
        }

        private string section { get; set; }


        private string ctrlname() {            
            for (int i=0;i<6;i++) {
                if (!day_cntnr.Controls.ContainsKey(section + "_" + day + "_" + i))
                {
                    return ""+i;
                }
            }
            return "";
        }
        /// <setValues>
        

        public void setDay(string value)
        {
            day = value;
        }

        public void setSection(string value)
        {
            section = value;
        }
        /// </setValues>
        public table_module_day()
        {
            DBCmmnds dbcmd = new DBCmmnds();
            InitializeComponent();
            //0 - section
            //1 - day
            string[] attrb = 
            {
                dbcmd.getData("SELECT `section_id` FROM `tbl_section` WHERE `description` = '"+section+"'"), 
                dbcmd.getData("SELECT `day_id` FROM `tbl_day` WHERE `description` = '" + day + "'") 
            };                        

        }

        private void button_add_day_Click(object sender, EventArgs e)
        {
            Class_box cbc = new Class_box();
            cbc.onControlCountChanged += _onControlCountChanged;
            onControlCountChanged();
            day_cntnr.Controls.Add(cbc);
            cbc.Dock = DockStyle.Top;
            day_cntnr.Controls.SetChildIndex(cbc, 1);
            cbc.setSection(section + "_" + day + "_" + ctrlname());
            cbc.setDay(day);
        }
        ////<update/add>

        public void addClass()
        {
            DBCmmnds dbcmd = new DBCmmnds();            
            foreach (string[] s in dbcmd.getValues("SELECT `fk_day`,`panel_name`,`fk_subject`,`fk_instructor`,`fk_time`,`fk_etime`,`fk_room` FROM `tbl_class` WHERE `class_id` = '2' AND `fk_day` = '" + dbcmd.getData("SELECT `day_id` FROM `tbl_day` WHERE `description` = '" + day + "'") + "'") )
            {
                foreach(string ss in s)
                {
                    Console.WriteLine(ss);
                }

                if (!day_cntnr.Controls.ContainsKey(s[1]))
                {
                    Class_box cbc = new Class_box();
                    cbc.setDay(s[0]);
                    cbc.setSection(s[1]);
                    cbc.setSubjetcode(s[2]);
                    cbc.setInstructor(s[3]);
                    cbc.setStartingTime(s[4]);
                    cbc.setEndingTime(s[5]);
                    cbc.setRoom(s[6]);
                    cbc.onControlCountChanged += _onControlCountChanged;
                    onControlCountChanged();
                    cbc.Dock = DockStyle.Top;
                    day_cntnr.Controls.Add(cbc);
                    day_cntnr.Controls.SetChildIndex(cbc, 1);

                }
                else
                    continue;

            }
            

            
        }






        ///</update/add>
        private void _onControlCountChanged(object sender, EventArgs e)
        {
            int ctrlcunt = day_cntnr.Controls.Count-2;
            if (ctrlcunt>4)           
                button_add_day.Hide();            
            else
                button_add_day.Show();
        }
        private void onControlCountChanged()
        {
            int ctrlcunt = day_cntnr.Controls.Count - 1;
            if (ctrlcunt > 4)
                button_add_day.Hide();
            else
                button_add_day.Show();
        }
    }
}
