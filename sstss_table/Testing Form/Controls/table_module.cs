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
    public partial class table_module : UserControl
    {   private string v_section;
        public string section { get { return v_section; } set { v_section = value; } }
        public table_module()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Class_box cbc = new Class_box();
            monday_cntnr.Controls.Add(cbc);
            cbc.Dock = DockStyle.Top;
            monday_cntnr.Controls.SetChildIndex(cbc, 1);
            


        }
    }
}
