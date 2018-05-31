namespace Orion
{
    partial class CreateNewPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewPriceForm));
            this.TextBoxPriceCout = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxPriceKyda = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxPriceOtkuda = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxPriceMarsh = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.ButtonAddPrice = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // TextBoxPriceCout
            // 
            // 
            // 
            // 
            this.TextBoxPriceCout.CustomButton.Image = null;
            this.TextBoxPriceCout.CustomButton.Location = new System.Drawing.Point(162, 1);
            this.TextBoxPriceCout.CustomButton.Name = "";
            this.TextBoxPriceCout.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxPriceCout.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxPriceCout.CustomButton.TabIndex = 1;
            this.TextBoxPriceCout.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxPriceCout.CustomButton.UseSelectable = true;
            this.TextBoxPriceCout.CustomButton.Visible = false;
            this.TextBoxPriceCout.Lines = new string[0];
            this.TextBoxPriceCout.Location = new System.Drawing.Point(103, 167);
            this.TextBoxPriceCout.MaxLength = 32767;
            this.TextBoxPriceCout.Name = "TextBoxPriceCout";
            this.TextBoxPriceCout.PasswordChar = '\0';
            this.TextBoxPriceCout.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxPriceCout.SelectedText = "";
            this.TextBoxPriceCout.SelectionLength = 0;
            this.TextBoxPriceCout.SelectionStart = 0;
            this.TextBoxPriceCout.Size = new System.Drawing.Size(184, 23);
            this.TextBoxPriceCout.TabIndex = 25;
            this.TextBoxPriceCout.UseSelectable = true;
            this.TextBoxPriceCout.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxPriceCout.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxPriceCout.TextChanged += new System.EventHandler(this.TextBoxPriceCout_TextChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(23, 171);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(76, 19);
            this.metroLabel8.TabIndex = 24;
            this.metroLabel8.Text = "Стоимость:";
            // 
            // ComboBoxPriceKyda
            // 
            this.ComboBoxPriceKyda.FormattingEnabled = true;
            this.ComboBoxPriceKyda.ItemHeight = 23;
            this.ComboBoxPriceKyda.Location = new System.Drawing.Point(103, 127);
            this.ComboBoxPriceKyda.Name = "ComboBoxPriceKyda";
            this.ComboBoxPriceKyda.Size = new System.Drawing.Size(184, 29);
            this.ComboBoxPriceKyda.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxPriceKyda.TabIndex = 23;
            this.ComboBoxPriceKyda.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(23, 130);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(38, 19);
            this.metroLabel7.TabIndex = 22;
            this.metroLabel7.Text = "Куда:";
            // 
            // ComboBoxPriceOtkuda
            // 
            this.ComboBoxPriceOtkuda.FormattingEnabled = true;
            this.ComboBoxPriceOtkuda.ItemHeight = 23;
            this.ComboBoxPriceOtkuda.Location = new System.Drawing.Point(103, 92);
            this.ComboBoxPriceOtkuda.Name = "ComboBoxPriceOtkuda";
            this.ComboBoxPriceOtkuda.Size = new System.Drawing.Size(184, 29);
            this.ComboBoxPriceOtkuda.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxPriceOtkuda.TabIndex = 21;
            this.ComboBoxPriceOtkuda.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 95);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(53, 19);
            this.metroLabel6.TabIndex = 20;
            this.metroLabel6.Text = "Откуда:";
            // 
            // ComboBoxPriceMarsh
            // 
            this.ComboBoxPriceMarsh.FormattingEnabled = true;
            this.ComboBoxPriceMarsh.ItemHeight = 23;
            this.ComboBoxPriceMarsh.Location = new System.Drawing.Point(103, 57);
            this.ComboBoxPriceMarsh.Name = "ComboBoxPriceMarsh";
            this.ComboBoxPriceMarsh.Size = new System.Drawing.Size(184, 29);
            this.ComboBoxPriceMarsh.Style = MetroFramework.MetroColorStyle.Green;
            this.ComboBoxPriceMarsh.TabIndex = 19;
            this.ComboBoxPriceMarsh.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 60);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(73, 19);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "Маршрут: ";
            // 
            // ButtonAddPrice
            // 
            this.ButtonAddPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddPrice.Location = new System.Drawing.Point(81, 196);
            this.ButtonAddPrice.Name = "ButtonAddPrice";
            this.ButtonAddPrice.Size = new System.Drawing.Size(137, 29);
            this.ButtonAddPrice.TabIndex = 26;
            this.ButtonAddPrice.Text = "Добавить";
            this.ButtonAddPrice.UseSelectable = true;
            this.ButtonAddPrice.Click += new System.EventHandler(this.ButtonAddPrice_Click);
            // 
            // CreateNewPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 241);
            this.Controls.Add(this.ButtonAddPrice);
            this.Controls.Add(this.TextBoxPriceCout);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.ComboBoxPriceKyda);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.ComboBoxPriceOtkuda);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.ComboBoxPriceMarsh);
            this.Controls.Add(this.metroLabel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewPriceForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Новая цена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TextBoxPriceCout;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox ComboBoxPriceKyda;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox ComboBoxPriceOtkuda;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox ComboBoxPriceMarsh;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton ButtonAddPrice;
    }
}