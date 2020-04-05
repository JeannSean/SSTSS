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
        private string subcode { get { return v_subcode; } 
            set 
            { 
                v_subcode = value;
                subject_box.Text = value;
            } 
        }
        private string instructor { get { return v_instrctr; } 
            set 
            { 
                v_instrctr = value;
                instructor_box.Text = value;
            } 
        }
        private string start_time { get { return v_stime; } 
            set 
            {
                v_stime = value;
                time_box.Text = value;
            } 
        }
        private string end_time { get { return v_etime; } 
            set 
            { 
                v_etime = value;
                time_box.Text += "-"+value;
            } 
        }
        private string room { get { return v_room; } 
            set 
            { 
                v_room = value;
                room_box.Text = value;
            } 
        }
        private string section { get { return v_class; } 
            set 
            { 
                v_class = value;
                this.Name = value;
                label1.Text = this.Name;
            } 
        }
        /// </summary>

        /// <setValue>
        public void setSubjecode(string value)
        {
            subcode = value;
        }
        public void setInstructor(string value)
        {
            instructor = value;
        }
        public void setStartingTime(string value)
        {
            start_time = value;
        }
        public void setEndingTime(string value)
        {
            end_time = value;
        }
        public void setRoom(string value)
        {
            room = value;
        }
        public void setSection(string value)
        {
            section = value;
        }
        /// </setValue>

        public Class_box()
        {
            InitializeComponent();
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
            string[] data = { "CC101", instructor, start_time, end_time, room, section };
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
