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
        DBCmmnds dbcmd = new DBCmmnds();
        private string v_day;
        
        private string day { get { return v_day; } 
            set { 
                v_day = value;
            } 
        }

        private string panelname { get; set; }

        private string section { get; set; }
        private string ctrlname() {            
            for (int i=0;i<6;i++) {
                if (!day_cntnr.Controls.ContainsKey(panelname + "_" + day + "_" + i))
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
            day_label.Text = value;
        }

        public void setPanelname(string value)
        {
            panelname = value;
        }
        public void setSection(string value)
        {
            section = value;
        }
        /// </setValues>
        public table_module_day()
        {
            InitializeComponent();
            
            //0 - section
            //1 - day               

        }

        private void button_add_day_Click(object sender, EventArgs e)
        {
            Class_box cbc = new Class_box();
            cbc.onClassUpdate += updateClass;
            cbc.onControlCountChanged += _onControlCountChanged;
            onControlCountChanged();
            day_cntnr.Controls.Add(cbc);
            cbc.Dock = DockStyle.Top;
            day_cntnr.Controls.SetChildIndex(cbc, 1);
            cbc.setPanelname(panelname + "_" + day + "_" + ctrlname());
            cbc.setSection(section);
            cbc.setDay(dbcmd.getData("SELECT `day_id` FROM `sstss_data`.`tbl_day` WHERE `description` = '" + day + "'"));
            
        }
        ////<update/add>

        public void addClass()
        {          
            foreach (string[] s in dbcmd.getValues("SELECT `class_id`,`fk_day`,`panel_name`,`fk_subject`,`fk_instructor`,`fk_time`,`fk_etime`,`fk_room` FROM `tbl_class` WHERE `class_id` = '2' AND `fk_day` = '" + dbcmd.getData("SELECT `day_id` FROM `tbl_day` WHERE `description` = '" + day + "'") + "' ORDER BY `fk_time` ASC") )
            {
                if (!day_cntnr.Controls.ContainsKey(s[1]))
                {
                    Class_box cbc = new Class_box();
                    cbc.onControlCountChanged += _onControlCountChanged;
                    cbc.onClassUpdate += updateClass;
                    cbc.setParet(this);
                    onControlCountChanged();
                    cbc.Dock = DockStyle.Top;
                    day_cntnr.Controls.Add(cbc);
                    day_cntnr.Controls.SetChildIndex(cbc, 1);
                    cbc.setSection(s[0]);
                    cbc.setDay(s[1]);
                    cbc.setPanelname(s[2]);
                    cbc.setSubjetcode(s[3]);
                    cbc.setInstructor(s[4]);
                    cbc.setStartingTime(s[5]);
                    cbc.setEndingTime(s[6]);
                    cbc.setRoom(s[7]);
                    onControlCountChanged();

                }
                else
                    continue;

            }
        }
        public event EventHandler triggerDispose;

        private void updateClass(object sender, EventArgs e)
        {
            triggerDispose?.Invoke(this, EventArgs.Empty);
            addClass();
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
