namespace Orion
{
    partial class PromPynktCatalogAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromPynktCatalogAddForm));
            this.ButtonAddPP = new MetroFramework.Controls.MetroButton();
            this.TextBoxAddPP = new MetroFramework.Controls.MetroTextBox();
            this.LabelAddTypeBilet = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // ButtonAddPP
            // 
            this.ButtonAddPP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonAddPP.Location = new System.Drawing.Point(29, 95);
            this.ButtonAddPP.Name = "ButtonAddPP";
            this.ButtonAddPP.Size = new System.Drawing.Size(269, 29);
            this.ButtonAddPP.TabIndex = 35;
            this.ButtonAddPP.Text = "Добавить";
            this.ButtonAddPP.UseSelectable = true;
            this.ButtonAddPP.Click += new System.EventHandler(this.ButtonAddPP_Click);
            // 
            // TextBoxAddPP
            // 
            this.TextBoxAddPP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.TextBoxAddPP.CustomButton.Image = null;
            this.TextBoxAddPP.CustomButton.Location = new System.Drawing.Point(170, 1);
            this.TextBoxAddPP.CustomButton.Name = "";
            this.TextBoxAddPP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxAddPP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxAddPP.CustomButton.TabIndex = 1;
            this.TextBoxAddPP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxAddPP.CustomButton.UseSelectable = true;
            this.TextBoxAddPP.CustomButton.Visible = false;
            this.TextBoxAddPP.Lines = new string[0];
            this.TextBoxAddPP.Location = new System.Drawing.Point(106, 63);
            this.TextBoxAddPP.MaxLength = 32767;
            this.TextBoxAddPP.Name = "TextBoxAddPP";
            this.TextBoxAddPP.PasswordChar = '\0';
            this.TextBoxAddPP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxAddPP.SelectedText = "";
            this.TextBoxAddPP.SelectionLength = 0;
            this.TextBoxAddPP.SelectionStart = 0;
            this.TextBoxAddPP.Size = new System.Drawing.Size(192, 23);
            this.TextBoxAddPP.Style = MetroFramework.MetroColorStyle.Green;
            this.TextBoxAddPP.TabIndex = 34;
            this.TextBoxAddPP.UseSelectable = true;
            this.TextBoxAddPP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxAddPP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LabelAddTypeBilet
            // 
            this.LabelAddTypeBilet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelAddTypeBilet.AutoSize = true;
            this.LabelAddTypeBilet.Location = new System.Drawing.Point(29, 67);
            this.LabelAddTypeBilet.Name = "LabelAddTypeBilet";
            this.LabelAddTypeBilet.Size = new System.Drawing.Size(71, 19);
            this.LabelAddTypeBilet.TabIndex = 33;
            this.LabelAddTypeBilet.Text = "Название:";
            // 
            // PromPynktCatalogAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 149);
            this.Controls.Add(this.ButtonAddPP);
            this.Controls.Add(this.TextBoxAddPP);
            this.Controls.Add(this.LabelAddTypeBilet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromPynktCatalogAddForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новый пункт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton ButtonAddPP;
        private MetroFramework.Controls.MetroTextBox TextBoxAddPP;
        private MetroFramework.Controls.MetroLabel LabelAddTypeBilet;
    }
}