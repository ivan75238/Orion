namespace Orion
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxUser = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxPass = new MetroFramework.Controls.MetroTextBox();
            this.ButtonIn = new MetroFramework.Controls.MetroButton();
            this.ButtonOut = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Пользователь";
            // 
            // ComboBoxUser
            // 
            this.ComboBoxUser.FormattingEnabled = true;
            this.ComboBoxUser.ItemHeight = 23;
            this.ComboBoxUser.Location = new System.Drawing.Point(123, 61);
            this.ComboBoxUser.Name = "ComboBoxUser";
            this.ComboBoxUser.Size = new System.Drawing.Size(187, 29);
            this.ComboBoxUser.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxUser.TabIndex = 1;
            this.ComboBoxUser.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 114);
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
            this.TextBoxPass.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.TextBoxPass.CustomButton.Name = "";
            this.TextBoxPass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxPass.CustomButton.TabIndex = 1;
            this.TextBoxPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxPass.CustomButton.UseSelectable = true;
            this.TextBoxPass.CustomButton.Visible = false;
            this.TextBoxPass.Lines = new string[0];
            this.TextBoxPass.Location = new System.Drawing.Point(123, 110);
            this.TextBoxPass.MaxLength = 32767;
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.PasswordChar = '\0';
            this.TextBoxPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxPass.SelectedText = "";
            this.TextBoxPass.SelectionLength = 0;
            this.TextBoxPass.SelectionStart = 0;
            this.TextBoxPass.Size = new System.Drawing.Size(187, 23);
            this.TextBoxPass.Style = MetroFramework.MetroColorStyle.Green;
            this.TextBoxPass.TabIndex = 3;
            this.TextBoxPass.UseSelectable = true;
            this.TextBoxPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonIn
            // 
            this.ButtonIn.Location = new System.Drawing.Point(24, 139);
            this.ButtonIn.Name = "ButtonIn";
            this.ButtonIn.Size = new System.Drawing.Size(134, 32);
            this.ButtonIn.TabIndex = 4;
            this.ButtonIn.Text = "Войти";
            this.ButtonIn.UseSelectable = true;
            this.ButtonIn.Click += new System.EventHandler(this.ButtonIn_Click);
            // 
            // ButtonOut
            // 
            this.ButtonOut.Location = new System.Drawing.Point(175, 139);
            this.ButtonOut.Name = "ButtonOut";
            this.ButtonOut.Size = new System.Drawing.Size(135, 32);
            this.ButtonOut.TabIndex = 5;
            this.ButtonOut.Text = "Отмена";
            this.ButtonOut.UseSelectable = true;
            this.ButtonOut.Click += new System.EventHandler(this.ButtonOut_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 194);
            this.Controls.Add(this.ButtonOut);
            this.Controls.Add(this.ButtonIn);
            this.Controls.Add(this.TextBoxPass);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.ComboBoxUser);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ComboBoxUser;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextBoxPass;
        private MetroFramework.Controls.MetroButton ButtonIn;
        private MetroFramework.Controls.MetroButton ButtonOut;
    }
}