namespace Orion
{
    partial class AddNewsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewsForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxMessage = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxTitle = new MetroFramework.Controls.MetroTextBox();
            this.DateTimePublication = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.ButtonAdd = new MetroFramework.Controls.MetroButton();
            this.LabelNameImage = new MetroFramework.Controls.MetroLabel();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.ButtonSelectImage = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Заголовок:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 89);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(97, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Текст новости:";
            // 
            // TextBoxMessage
            // 
            // 
            // 
            // 
            this.TextBoxMessage.CustomButton.Image = null;
            this.TextBoxMessage.CustomButton.Location = new System.Drawing.Point(103, 1);
            this.TextBoxMessage.CustomButton.Name = "";
            this.TextBoxMessage.CustomButton.Size = new System.Drawing.Size(165, 165);
            this.TextBoxMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxMessage.CustomButton.TabIndex = 1;
            this.TextBoxMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxMessage.CustomButton.UseSelectable = true;
            this.TextBoxMessage.CustomButton.Visible = false;
            this.TextBoxMessage.Lines = new string[0];
            this.TextBoxMessage.Location = new System.Drawing.Point(23, 111);
            this.TextBoxMessage.MaxLength = 32767;
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.PasswordChar = '\0';
            this.TextBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxMessage.SelectedText = "";
            this.TextBoxMessage.SelectionLength = 0;
            this.TextBoxMessage.SelectionStart = 0;
            this.TextBoxMessage.ShortcutsEnabled = true;
            this.TextBoxMessage.Size = new System.Drawing.Size(269, 167);
            this.TextBoxMessage.TabIndex = 2;
            this.TextBoxMessage.UseSelectable = true;
            this.TextBoxMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxTitle
            // 
            // 
            // 
            // 
            this.TextBoxTitle.CustomButton.Image = null;
            this.TextBoxTitle.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.TextBoxTitle.CustomButton.Name = "";
            this.TextBoxTitle.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxTitle.CustomButton.TabIndex = 1;
            this.TextBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxTitle.CustomButton.UseSelectable = true;
            this.TextBoxTitle.CustomButton.Visible = false;
            this.TextBoxTitle.Lines = new string[0];
            this.TextBoxTitle.Location = new System.Drawing.Point(132, 60);
            this.TextBoxTitle.MaxLength = 32767;
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.PasswordChar = '\0';
            this.TextBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxTitle.SelectedText = "";
            this.TextBoxTitle.SelectionLength = 0;
            this.TextBoxTitle.SelectionStart = 0;
            this.TextBoxTitle.ShortcutsEnabled = true;
            this.TextBoxTitle.Size = new System.Drawing.Size(160, 23);
            this.TextBoxTitle.TabIndex = 3;
            this.TextBoxTitle.UseSelectable = true;
            this.TextBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DateTimePublication
            // 
            this.DateTimePublication.Location = new System.Drawing.Point(137, 284);
            this.DateTimePublication.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimePublication.Name = "DateTimePublication";
            this.DateTimePublication.Size = new System.Drawing.Size(155, 29);
            this.DateTimePublication.Style = MetroFramework.MetroColorStyle.Green;
            this.DateTimePublication.TabIndex = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 288);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(118, 19);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Дата публикации:";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(173, 345);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(119, 29);
            this.ButtonAdd.TabIndex = 12;
            this.ButtonAdd.Text = "Добавить новость";
            this.ButtonAdd.UseSelectable = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // LabelNameImage
            // 
            this.LabelNameImage.AutoSize = true;
            this.LabelNameImage.Location = new System.Drawing.Point(23, 319);
            this.LabelNameImage.Name = "LabelNameImage";
            this.LabelNameImage.Size = new System.Drawing.Size(123, 19);
            this.LabelNameImage.TabIndex = 13;
            this.LabelNameImage.Text = "Имя изображения";
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialog1";
            this.openFileDialogImage.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            // 
            // ButtonSelectImage
            // 
            this.ButtonSelectImage.Location = new System.Drawing.Point(23, 345);
            this.ButtonSelectImage.Name = "ButtonSelectImage";
            this.ButtonSelectImage.Size = new System.Drawing.Size(137, 29);
            this.ButtonSelectImage.TabIndex = 14;
            this.ButtonSelectImage.Text = "Выбрать изображение";
            this.ButtonSelectImage.UseSelectable = true;
            this.ButtonSelectImage.Click += new System.EventHandler(this.ButtonSelectImage_Click);
            // 
            // AddNewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 399);
            this.Controls.Add(this.ButtonSelectImage);
            this.Controls.Add(this.LabelNameImage);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.DateTimePublication);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.TextBoxTitle);
            this.Controls.Add(this.TextBoxMessage);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewsForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Добавить новость";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextBoxMessage;
        private MetroFramework.Controls.MetroTextBox TextBoxTitle;
        private MetroFramework.Controls.MetroDateTime DateTimePublication;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton ButtonAdd;
        private MetroFramework.Controls.MetroLabel LabelNameImage;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private MetroFramework.Controls.MetroButton ButtonSelectImage;
    }
}