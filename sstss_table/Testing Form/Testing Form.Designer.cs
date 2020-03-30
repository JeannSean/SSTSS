namespace Testing_Form
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table_module1 = new Testing_Form.Controls.table_module();
            this.SuspendLayout();
            // 
            // table_module1
            // 
            this.table_module1.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_module1.Location = new System.Drawing.Point(0, 0);
            this.table_module1.Name = "table_module1";
            this.table_module1.Size = new System.Drawing.Size(973, 474);
            this.table_module1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 565);
            this.Controls.Add(this.table_module1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }


        #endregion

        private Controls.table_module table_module1;
    }
}

