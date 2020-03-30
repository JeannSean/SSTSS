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
    public partial class Class_box : UserControl
    {
        public Class_box()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Edit_box calledbox = new Edit_box();
            calledbox.ShowDialog();
        }
    }
}
