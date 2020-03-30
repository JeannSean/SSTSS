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
namespace input_data_form
{
    public partial class editbox : Form
    {
        public editbox()
        {
            InitializeComponent();
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            dbCmmnds dbcmmnd = new dbCmmnds();
            string subcode = subject_code_textbox.Text;
            subject_code_display.Text = dbcmmnd.getData("SELECT `description` FROM `sstss_data`.`tbl_subject` WHERE `subject_code` = '"+ subcode+"';");

        

        }

    }
}
