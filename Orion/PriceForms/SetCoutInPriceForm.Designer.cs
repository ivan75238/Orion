namespace Orion
{
    partial class SetCoutInPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCoutInPriceForm));
            this.ButtonSet = new MetroFramework.Controls.MetroButton();
            this.TextBoxCout = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // ButtonSet
            // 
            this.ButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSet.Location = new System.Drawing.Point(26, 91);
            this.ButtonSet.Name = "ButtonSet";
            this.ButtonSet.Size = new System.Drawing.Size(248, 29);
            this.ButtonSet.TabIndex = 24;
            this.ButtonSet.Text = "Изменить";
            this.ButtonSet.UseSelectable = true;
            this.ButtonSet.Click += new System.EventHandler(this.ButtonSet_Click);
            // 
            // TextBoxCout
            // 
            // 
            // 
            // 
            this.TextBoxCout.CustomButton.Image = null;
            this.TextBoxCout.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.TextBoxCout.CustomButton.Name = "";
            this.TextBoxCout.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxCout.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxCout.CustomButton.TabIndex = 1;
            this.TextBoxCout.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxCout.CustomButton.UseSelectable = true;
            this.TextBoxCout.CustomButton.Visible = false;
            this.TextBoxCout.Lines = new string[0];
            this.TextBoxCout.Location = new System.Drawing.Point(119, 62);
            this.TextBoxCout.MaxLength = 32767;
            this.TextBoxCout.Name = "TextBoxCout";
            this.TextBoxCout.PasswordChar = '\0';
            this.TextBoxCout.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxCout.SelectedText = "";
            this.TextBoxCout.SelectionLength = 0;
            this.TextBoxCout.SelectionStart = 0;
            this.TextBoxCout.Size = new System.Drawing.Size(155, 23);
            this.TextBoxCout.TabIndex = 25;
            this.TextBoxCout.UseSelectable = true;
            this.TextBoxCout.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxCout.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxCout.TextChanged += new System.EventHandler(this.TextBoxCout_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(26, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Стоимость:";
            // 
            // SetCoutInPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 143);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.TextBoxCout);
            this.Controls.Add(this.ButtonSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetCoutInPriceForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новая стоимость";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton ButtonSet;
        private MetroFramework.Controls.MetroTextBox TextBoxCout;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}