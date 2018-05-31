namespace Orion
{
    partial class AddNewTripForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewTripForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxMarsh = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxVoditel = new MetroFramework.Controls.MetroComboBox();
            this.ButtonAdd = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(25, 62);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(44, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Дата: ";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(75, 62);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(200, 29);
            this.metroDateTime1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroDateTime1.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 107);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Маршрут:";
            // 
            // ComboBoxMarsh
            // 
            this.ComboBoxMarsh.FormattingEnabled = true;
            this.ComboBoxMarsh.ItemHeight = 23;
            this.ComboBoxMarsh.Location = new System.Drawing.Point(100, 104);
            this.ComboBoxMarsh.Name = "ComboBoxMarsh";
            this.ComboBoxMarsh.Size = new System.Drawing.Size(175, 29);
            this.ComboBoxMarsh.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxMarsh.TabIndex = 3;
            this.ComboBoxMarsh.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 153);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Водитель:";
            // 
            // ComboBoxVoditel
            // 
            this.ComboBoxVoditel.FormattingEnabled = true;
            this.ComboBoxVoditel.ItemHeight = 23;
            this.ComboBoxVoditel.Location = new System.Drawing.Point(100, 150);
            this.ComboBoxVoditel.Name = "ComboBoxVoditel";
            this.ComboBoxVoditel.Size = new System.Drawing.Size(175, 29);
            this.ComboBoxVoditel.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxVoditel.TabIndex = 5;
            this.ComboBoxVoditel.UseSelectable = true;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(84, 185);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(139, 29);
            this.ButtonAdd.Style = MetroFramework.MetroColorStyle.Green;
            this.ButtonAdd.TabIndex = 15;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseSelectable = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // AddNewTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 231);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ComboBoxVoditel);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.ComboBoxMarsh);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewTripForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новая поездка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ComboBoxMarsh;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox ComboBoxVoditel;
        private MetroFramework.Controls.MetroButton ButtonAdd;
    }
}