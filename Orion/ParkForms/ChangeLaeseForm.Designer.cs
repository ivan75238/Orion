namespace Orion
{
    partial class ChangeLaeseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLaeseForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.DateTimeNach = new MetroFramework.Controls.MetroDateTime();
            this.DateTimeKonec = new MetroFramework.Controls.MetroDateTime();
            this.ButtonChange = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(107, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Начало аренды:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 100);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(100, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Конец аренды:";
            // 
            // DateTimeNach
            // 
            this.DateTimeNach.Location = new System.Drawing.Point(138, 62);
            this.DateTimeNach.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeNach.Name = "DateTimeNach";
            this.DateTimeNach.Size = new System.Drawing.Size(139, 29);
            this.DateTimeNach.Style = MetroFramework.MetroColorStyle.Green;
            this.DateTimeNach.TabIndex = 2;
            // 
            // DateTimeKonec
            // 
            this.DateTimeKonec.Location = new System.Drawing.Point(138, 100);
            this.DateTimeKonec.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeKonec.Name = "DateTimeKonec";
            this.DateTimeKonec.Size = new System.Drawing.Size(139, 29);
            this.DateTimeKonec.Style = MetroFramework.MetroColorStyle.Green;
            this.DateTimeKonec.TabIndex = 3;
            // 
            // ButtonChange
            // 
            this.ButtonChange.Location = new System.Drawing.Point(101, 135);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(101, 29);
            this.ButtonChange.TabIndex = 4;
            this.ButtonChange.Text = "Продлить";
            this.ButtonChange.UseSelectable = true;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ChangeLaeseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 185);
            this.Controls.Add(this.ButtonChange);
            this.Controls.Add(this.DateTimeKonec);
            this.Controls.Add(this.DateTimeNach);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeLaeseForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Продление аренды";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime DateTimeNach;
        private MetroFramework.Controls.MetroDateTime DateTimeKonec;
        private MetroFramework.Controls.MetroButton ButtonChange;
    }
}