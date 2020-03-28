namespace class_display
{
    partial class class_control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gunaShadowPanel1 = new Guna.UI.WinForms.GunaShadowPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.subject_box = new Guna.UI.WinForms.GunaTextBox();
            this.instructor_box = new Guna.UI.WinForms.GunaLineTextBox();
            this.time_box = new Guna.UI.WinForms.GunaLineTextBox();
            this.room_box = new Guna.UI.WinForms.GunaLineTextBox();
            this.gunaShadowPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaShadowPanel1
            // 
            this.gunaShadowPanel1.BackColor = System.Drawing.Color.Maroon;
            this.gunaShadowPanel1.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel1.Controls.Add(this.panel1);
            this.gunaShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaShadowPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gunaShadowPanel1.Name = "gunaShadowPanel1";
            this.gunaShadowPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.gunaShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.gunaShadowPanel1.ShadowDepth = 200;
            this.gunaShadowPanel1.ShadowShift = 2;
            this.gunaShadowPanel1.Size = new System.Drawing.Size(161, 142);
            this.gunaShadowPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.room_box);
            this.panel1.Controls.Add(this.time_box);
            this.panel1.Controls.Add(this.instructor_box);
            this.panel1.Controls.Add(this.subject_box);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 138);
            this.panel1.TabIndex = 0;
            // 
            // subject_box
            // 
            this.subject_box.BaseColor = System.Drawing.Color.White;
            this.subject_box.BorderColor = System.Drawing.Color.Silver;
            this.subject_box.BorderSize = 0;
            this.subject_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.subject_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.subject_box.FocusedBaseColor = System.Drawing.Color.White;
            this.subject_box.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.subject_box.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.subject_box.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.subject_box.Location = new System.Drawing.Point(0, 0);
            this.subject_box.Multiline = true;
            this.subject_box.Name = "subject_box";
            this.subject_box.PasswordChar = '\0';
            this.subject_box.ReadOnly = true;
            this.subject_box.SelectedText = "";
            this.subject_box.Size = new System.Drawing.Size(157, 40);
            this.subject_box.TabIndex = 4;
            this.subject_box.Text = "Subject";
            this.subject_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // instructor_box
            // 
            this.instructor_box.BackColor = System.Drawing.Color.White;
            this.instructor_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.instructor_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructor_box.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.instructor_box.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.instructor_box.HideSelection = false;
            this.instructor_box.LineColor = System.Drawing.Color.Gainsboro;
            this.instructor_box.Location = new System.Drawing.Point(0, 40);
            this.instructor_box.Name = "instructor_box";
            this.instructor_box.PasswordChar = '\0';
            this.instructor_box.ReadOnly = true;
            this.instructor_box.SelectedText = "";
            this.instructor_box.Size = new System.Drawing.Size(157, 40);
            this.instructor_box.TabIndex = 7;
            this.instructor_box.Text = "Instructor";
            this.instructor_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instructor_box.Visible = false;
            // 
            // time_box
            // 
            this.time_box.BackColor = System.Drawing.Color.White;
            this.time_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.time_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.time_box.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.time_box.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.time_box.HideSelection = false;
            this.time_box.LineColor = System.Drawing.Color.Gainsboro;
            this.time_box.Location = new System.Drawing.Point(0, 80);
            this.time_box.Name = "time_box";
            this.time_box.PasswordChar = '\0';
            this.time_box.ReadOnly = true;
            this.time_box.SelectedText = "";
            this.time_box.Size = new System.Drawing.Size(157, 29);
            this.time_box.TabIndex = 8;
            this.time_box.Text = "00:00-00:00";
            this.time_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_box.Visible = false;
            // 
            // room_box
            // 
            this.room_box.BackColor = System.Drawing.Color.White;
            this.room_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.room_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.room_box.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.room_box.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.room_box.HideSelection = false;
            this.room_box.LineColor = System.Drawing.Color.Gainsboro;
            this.room_box.Location = new System.Drawing.Point(0, 109);
            this.room_box.Name = "room_box";
            this.room_box.PasswordChar = '\0';
            this.room_box.ReadOnly = true;
            this.room_box.SelectedText = "";
            this.room_box.Size = new System.Drawing.Size(157, 29);
            this.room_box.TabIndex = 9;
            this.room_box.Text = "Room101";
            this.room_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.room_box.Visible = false;
            // 
            // class_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gunaShadowPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "class_control";
            this.Size = new System.Drawing.Size(161, 142);
            this.gunaShadowPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaTextBox subject_box;
        private Guna.UI.WinForms.GunaLineTextBox room_box;
        private Guna.UI.WinForms.GunaLineTextBox time_box;
        private Guna.UI.WinForms.GunaLineTextBox instructor_box;
    }
}
