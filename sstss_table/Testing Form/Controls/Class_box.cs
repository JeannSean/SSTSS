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

        /// <attribute>
        private string v_subcode;
        private string v_instrctr;
        private string v_stime;
        private string v_etime;
        private string v_room;
        private string v_class;
        public string subcode { get { return v_subcode; } set { v_subcode = value; } }
        public string instructor { get { return v_instrctr; } set { v_instrctr = value; } }
        public string start_time { get { return v_stime; } set { v_stime = value; } }
        public string end_time { get { return v_etime; } set { v_etime = value; } }
        public string room { get { return v_room; } set { v_room = value; } }
        public string section { get { return v_class; } set { v_class = value; } }

        /// </summary>

        public Class_box()
        {

            InitializeComponent();
            if (subcode != null)
            {
                subject_box.Text = subcode;
            }
            if (instructor != null)
            {
                instructor_box.Text = instructor;
            }
            if (start_time != null && end_time !=null)
            {
                time_box.Text = start_time+"-"+end_time;
            }
            if (room != null)
            {
                room_box.Text = room;
            }
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            string[] data = {subcode, instructor, start_time, end_time, room, section };
            Edit_box calledbox = new Edit_box(data);
            calledbox.ShowDialog();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {           
            this.ParentForm.Controls.Remove(this);
            this.Dispose();
        }
    }
}
