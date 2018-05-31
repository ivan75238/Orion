namespace Orion
{
    partial class NewUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUserForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxFio = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxPass = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxRole = new MetroFramework.Controls.MetroComboBox();
            this.ButtonAdd = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(40, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "ФИО";
            // 
            // TextBoxFio
            // 
            // 
            // 
            // 
            this.TextBoxFio.CustomButton.Image = null;
            this.TextBoxFio.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.TextBoxFio.CustomButton.Name = "";
            this.TextBoxFio.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxFio.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxFio.CustomButton.TabIndex = 1;
            this.TextBoxFio.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxFio.CustomButton.UseSelectable = true;
            this.TextBoxFio.CustomButton.Visible = false;
            this.TextBoxFio.Lines = new string[0];
            this.TextBoxFio.Location = new System.Drawing.Point(92, 63);
            this.TextBoxFio.MaxLength = 32767;
            this.TextBoxFio.Name = "TextBoxFio";
            this.TextBoxFio.PasswordChar = '\0';
            this.TextBoxFio.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxFio.SelectedText = "";
            this.TextBoxFio.SelectionLength = 0;
            this.TextBoxFio.SelectionStart = 0;
            this.TextBoxFio.Size = new System.Drawing.Size(182, 23);
            this.TextBoxFio.TabIndex = 1;
            this.TextBoxFio.UseSelectable = true;
            this.TextBoxFio.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxFio.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 98);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(54, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Пароль";
            // 
            // TextBoxPass
            // 
            // 
            // 
            // 
            this.TextBoxPass.CustomButton.Image = null;
            this.TextBoxPass.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.TextBoxPass.CustomButton.Name = "";
            this.TextBoxPass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxPass.CustomButton.TabIndex = 1;
            this.TextBoxPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxPass.CustomButton.UseSelectable = true;
            this.TextBoxPass.CustomButton.Visible = false;
            this.TextBoxPass.Lines = new string[0];
            this.TextBoxPass.Location = new System.Drawing.Point(92, 98);
            this.TextBoxPass.MaxLength = 32767;
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.PasswordChar = '\0';
            this.TextBoxPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxPass.SelectedText = "";
            this.TextBoxPass.SelectionLength = 0;
            this.TextBoxPass.SelectionStart = 0;
            this.TextBoxPass.Size = new System.Drawing.Size(182, 23);
            this.TextBoxPass.TabIndex = 3;
            this.TextBoxPass.UseSelectable = true;
            this.TextBoxPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(32, 137);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(38, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Роль";
            // 
            // ComboBoxRole
            // 
            this.ComboBoxRole.FormattingEnabled = true;
            this.ComboBoxRole.ItemHeight = 23;
            this.ComboBoxRole.Location = new System.Drawing.Point(92, 134);
            this.ComboBoxRole.Name = "ComboBoxRole";
            this.ComboBoxRole.Size = new System.Drawing.Size(182, 29);
            this.ComboBoxRole.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxRole.TabIndex = 5;
            this.ComboBoxRole.UseSelectable = true;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(92, 185);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(139, 29);
            this.ButtonAdd.Style = MetroFramework.MetroColorStyle.Green;
            this.ButtonAdd.TabIndex = 7;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseSelectable = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 228);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ComboBoxRole);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.TextBoxPass);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.TextBoxFio);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUserForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новый пользователь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox TextBoxFio;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextBoxPass;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox ComboBoxRole;
        private MetroFramework.Controls.MetroButton ButtonAdd;
    }
}