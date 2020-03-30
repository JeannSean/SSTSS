using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class_display
{
    public partial class class_control : UserControl
    {
        public class_control()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            input_data_form.editbox callform = new input_data_form.editbox();
            callform.ShowDialog();
        }
    }
}
