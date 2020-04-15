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

        private void addClass()
        {

        }






        ///</update/add>
        private void _onControlCountChanged(object sender, EventArgs e)
        {
            int ctrlcunt = day_cntnr.Controls.Count-2;
            Console.WriteLine(ctrlcunt);
            if (ctrlcunt>4)           
                button_add_day.Hide();            
            else
                button_add_day.Show();
        }
        private void onControlCountChanged()
        {
            int ctrlcunt = day_cntnr.Controls.Count - 1;
            Console.WriteLine(ctrlcunt);
            if (ctrlcunt > 4)
                button_add_day.Hide();
            else
                button_add_day.Show();
        }
    }
}
