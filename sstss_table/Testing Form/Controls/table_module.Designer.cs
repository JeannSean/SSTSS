namespace Testing_Form.Controls
{
    partial class table_module
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
            this.table_container = new Guna.UI.WinForms.GunaShadowPanel();
            this.SuspendLayout();
            // 
            // table_container
            // 
            this.table_container.AutoSize = true;
            this.table_container.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.table_container.BaseColor = System.Drawing.SystemColors.ControlDarkDark;
            this.table_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_container.Location = new System.Drawing.Point(0, 0);
            this.table_container.Margin = new System.Windows.Forms.Padding(2);
            this.table_container.Name = "table_container";
            this.table_container.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table_container.ShadowColor = System.Drawing.Color.Black;
            this.table_container.ShadowDepth = 200;
            this.table_container.Size = new System.Drawing.Size(973, 539);
            this.table_container.TabIndex = 4;
            // 
            // table_module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.table_container);
            this.MaximumSize = new System.Drawing.Size(973, 863);
            this.MinimumSize = new System.Drawing.Size(973, 539);
            this.Name = "table_module";
            this.Size = new System.Drawing.Size(973, 539);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaShadowPanel table_container;
    }
}
