namespace Orion
{
    partial class NewPassword
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
            this.LabelNewPass = new MetroFramework.Controls.MetroLabel();
            this.ButtonChangePassword = new MetroFramework.Controls.MetroButton();
            this.TextBoxPass = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // LabelNewPass
            // 
            this.LabelNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNewPass.AutoSize = true;
            this.LabelNewPass.Location = new System.Drawing.Point(63, 66);
            this.LabelNewPass.Name = "LabelNewPass";
            this.LabelNewPass.Size = new System.Drawing.Size(150, 19);
            this.LabelNewPass.TabIndex = 17;
            this.LabelNewPass.Text = "Введите новый пароль";
            // 
            // ButtonChangePassword
            // 
            this.ButtonChangePassword.Location = new System.Drawing.Point(63, 127);
            this.ButtonChangePassword.Name = "ButtonChangePassword";
            this.ButtonChangePassword.Size = new System.Drawing.Size(157, 29);
            this.ButtonChangePassword.Style = MetroFramework.MetroColorStyle.Green;
            this.ButtonChangePassword.TabIndex = 18;
            this.ButtonChangePassword.Text = "Изменить";
            this.ButtonChangePassword.UseSelectable = true;
            this.ButtonChangePassword.Click += new System.EventHandler(this.ButtonChangePassword_Click);
            // 
            // TextBoxPass
            // 
            // 
            // 
            // 
            this.TextBoxPass.CustomButton.Image = null;
            this.TextBoxPass.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.TextBoxPass.CustomButton.Name = "";
            this.TextBoxPass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxPass.CustomButton.TabIndex = 1;
            this.TextBoxPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxPass.CustomButton.UseSelectable = true;
            this.TextBoxPass.CustomButton.Visible = false;
            this.TextBoxPass.Lines = new string[0];
            this.TextBoxPass.Location = new System.Drawing.Point(63, 98);
            this.TextBoxPass.MaxLength = 32767;
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.PasswordChar = '\0';
            this.TextBoxPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxPass.SelectedText = "";
            this.TextBoxPass.SelectionLength = 0;
            this.TextBoxPass.SelectionStart = 0;
            this.TextBoxPass.Size = new System.Drawing.Size(157, 23);
            this.TextBoxPass.TabIndex = 19;
            this.TextBoxPass.UseSelectable = true;
            this.TextBoxPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 179);
            this.Controls.Add(this.TextBoxPass);
            this.Controls.Add(this.ButtonChangePassword);
            this.Controls.Add(this.LabelNewPass);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPassword";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новый пароль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LabelNewPass;
        private MetroFramework.Controls.MetroButton ButtonChangePassword;
        private MetroFramework.Controls.MetroTextBox TextBoxPass;
    }
}