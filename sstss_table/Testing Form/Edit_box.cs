using System;
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
        public Edit_box()
        {
            InitializeComponent();
        }

        private void subject_code_textbox_OnValueChanged(object sender, EventArgs e)
        {
            DBCmmnds dbcmmnd = new DBCmmnds(); 
            string subcode = subject_code_textbox.Text; 
            subject_code_display.Text = dbcmmnd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '" + subcode + "';");
        }
    }
}
