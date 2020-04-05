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
    {   
        
        private static string section { get; set;  }

        public static void setSection(String value)
        {
            section = value;
        }
        public table_module()
        {
            setSection("BSCS 2");

            InitializeComponent();
            table_module_day[] tbl_day = new table_module_day[6];
            for (int i=0;i<6;i++)
            {
                tbl_day[i] = new table_module_day();
                string day="";
                switch (i)
                {
                    case 0:
                        day = "Saturday";
                        break;
                    case 1:
                        day = "Friday";
                        break;
                    case 2:
                        day = "Thursday";
                        break;
                    case 3:
                        day = "Wednesday";
                        break;
                    case 4:
                        day = "Tuesday";
                        break;
                    case 5:
                        day = "Monday";
                        break;
                }                
                tbl_day[i].setDay(day);
                tbl_day[i].setSection(section);
                tbl_day[i].Dock = DockStyle.Left;
                this.Controls.Add(tbl_day[i]);
            }
            
        }


    }
}
