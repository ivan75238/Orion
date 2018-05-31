namespace Orion
{
    partial class ClientHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientHistoryForm));
            this.DataGridOrders = new MetroFramework.Controls.MetroGrid();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeBilet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarshName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Otkyda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kyda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderMesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voditel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poezdka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridOrders
            // 
            this.DataGridOrders.AllowUserToAddRows = false;
            this.DataGridOrders.AllowUserToDeleteRows = false;
            this.DataGridOrders.AllowUserToResizeRows = false;
            this.DataGridOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGridOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.TypeBilet,
            this.MarshName,
            this.Otkyda,
            this.Kyda,
            this.OrderMesto,
            this.voditel,
            this.Poezdka,
            this.Cout,
            this.ColumnStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridOrders.EnableHeadersVisualStyles = false;
            this.DataGridOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DataGridOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridOrders.Location = new System.Drawing.Point(23, 63);
            this.DataGridOrders.Name = "DataGridOrders";
            this.DataGridOrders.ReadOnly = true;
            this.DataGridOrders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridOrders.Size = new System.Drawing.Size(952, 331);
            this.DataGridOrders.Style = MetroFramework.MetroColorStyle.Green;
            this.DataGridOrders.TabIndex = 8;
            this.DataGridOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridOrders_CellDoubleClick);
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Дата";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // TypeBilet
            // 
            this.TypeBilet.FillWeight = 106.9648F;
            this.TypeBilet.HeaderText = "Тип билета";
            this.TypeBilet.Name = "TypeBilet";
            this.TypeBilet.ReadOnly = true;
            // 
            // MarshName
            // 
            this.MarshName.HeaderText = "Маршрут";
            this.MarshName.Name = "MarshName";
            this.MarshName.ReadOnly = true;
            // 
            // Otkyda
            // 
            this.Otkyda.FillWeight = 92.83659F;
            this.Otkyda.HeaderText = "Откуда";
            this.Otkyda.Name = "Otkyda";
            this.Otkyda.ReadOnly = true;
            // 
            // Kyda
            // 
            this.Kyda.FillWeight = 98.47018F;
            this.Kyda.HeaderText = "Куда";
            this.Kyda.Name = "Kyda";
            this.Kyda.ReadOnly = true;
            // 
            // OrderMesto
            // 
            this.OrderMesto.HeaderText = "Место";
            this.OrderMesto.Name = "OrderMesto";
            this.OrderMesto.ReadOnly = true;
            // 
            // voditel
            // 
            this.voditel.HeaderText = "Водитель";
            this.voditel.Name = "voditel";
            this.voditel.ReadOnly = true;
            // 
            // Poezdka
            // 
            this.Poezdka.FillWeight = 96.63148F;
            this.Poezdka.HeaderText = "Машина";
            this.Poezdka.Name = "Poezdka";
            this.Poezdka.ReadOnly = true;
            // 
            // Cout
            // 
            this.Cout.FillWeight = 98.44554F;
            this.Cout.HeaderText = "Стоимость";
            this.Cout.Name = "Cout";
            this.Cout.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Статус";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ClientHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 404);
            this.Controls.Add(this.DataGridOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientHistoryForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "История поездок";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid DataGridOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poezdka;
        private System.Windows.Forms.DataGridViewTextBoxColumn voditel;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderMesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kyda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Otkyda;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarshName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeBilet;
    }
}