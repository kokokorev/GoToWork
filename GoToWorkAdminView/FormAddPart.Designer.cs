namespace GoToWorkAdminView
{
    partial class FormAddPart
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
            this.labelAvailableParts = new System.Windows.Forms.Label();
            this.dataGridViewAvailableParts = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxPartCount = new System.Windows.Forms.TextBox();
            this.buttonRequestPart = new System.Windows.Forms.Button();
            this.ColumnPartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPartType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPartColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPartCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableParts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAvailableParts
            // 
            this.labelAvailableParts.AutoSize = true;
            this.labelAvailableParts.Location = new System.Drawing.Point(12, 9);
            this.labelAvailableParts.Name = "labelAvailableParts";
            this.labelAvailableParts.Size = new System.Drawing.Size(102, 13);
            this.labelAvailableParts.TabIndex = 0;
            this.labelAvailableParts.Text = "Доступные детали";
            // 
            // dataGridViewAvailableParts
            // 
            this.dataGridViewAvailableParts.AllowUserToAddRows = false;
            this.dataGridViewAvailableParts.AllowUserToDeleteRows = false;
            this.dataGridViewAvailableParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPartId,
            this.ColumnPartType,
            this.ColumnPartColor,
            this.ColumnPartCount});
            this.dataGridViewAvailableParts.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewAvailableParts.Name = "dataGridViewAvailableParts";
            this.dataGridViewAvailableParts.ReadOnly = true;
            this.dataGridViewAvailableParts.Size = new System.Drawing.Size(403, 216);
            this.dataGridViewAvailableParts.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 274);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(403, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxPartCount
            // 
            this.textBoxPartCount.Location = new System.Drawing.Point(12, 247);
            this.textBoxPartCount.Name = "textBoxPartCount";
            this.textBoxPartCount.Size = new System.Drawing.Size(190, 20);
            this.textBoxPartCount.TabIndex = 3;
            // 
            // buttonRequestPart
            // 
            this.buttonRequestPart.Location = new System.Drawing.Point(223, 245);
            this.buttonRequestPart.Name = "buttonRequestPart";
            this.buttonRequestPart.Size = new System.Drawing.Size(192, 23);
            this.buttonRequestPart.TabIndex = 4;
            this.buttonRequestPart.Text = "Запросить деталь";
            this.buttonRequestPart.UseVisualStyleBackColor = true;
            this.buttonRequestPart.Click += new System.EventHandler(this.buttonRequestPart_Click);
            // 
            // ColumnPartId
            // 
            this.ColumnPartId.HeaderText = "PartId";
            this.ColumnPartId.Name = "ColumnPartId";
            this.ColumnPartId.ReadOnly = true;
            this.ColumnPartId.Visible = false;
            // 
            // ColumnPartType
            // 
            this.ColumnPartType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPartType.HeaderText = "Тип детали";
            this.ColumnPartType.Name = "ColumnPartType";
            this.ColumnPartType.ReadOnly = true;
            // 
            // ColumnPartColor
            // 
            this.ColumnPartColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPartColor.HeaderText = "Цвет детали";
            this.ColumnPartColor.Name = "ColumnPartColor";
            this.ColumnPartColor.ReadOnly = true;
            // 
            // ColumnPartCount
            // 
            this.ColumnPartCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPartCount.HeaderText = "Количество";
            this.ColumnPartCount.Name = "ColumnPartCount";
            this.ColumnPartCount.ReadOnly = true;
            // 
            // FormAddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 310);
            this.Controls.Add(this.buttonRequestPart);
            this.Controls.Add(this.textBoxPartCount);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewAvailableParts);
            this.Controls.Add(this.labelAvailableParts);
            this.Name = "FormAddPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить деталь";
            this.Load += new System.EventHandler(this.FormAddPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAvailableParts;
        private System.Windows.Forms.DataGridView dataGridViewAvailableParts;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxPartCount;
        private System.Windows.Forms.Button buttonRequestPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartCount;
    }
}