using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            InitializeComponent();
        }

        private void button_add_day_Click(object sender, EventArgs e)
        {
            Class_box cbc = new Class_box();
            day_cntnr.Controls.Add(cbc);
            cbc.Dock = DockStyle.Top;
            day_cntnr.Controls.SetChildIndex(cbc, 1);
            cbc.setSection(section + "_" + day + "_" + ctrlname());

        }
    }
}
