namespace GoToWorkProviderView
{
    partial class FormMain
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
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.labelParts = new System.Windows.Forms.Label();
            this.buttonOrderPart = new System.Windows.Forms.Button();
            this.buttonPartsMovement = new System.Windows.Forms.Button();
            this.buttonRequests = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonStat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.Size = new System.Drawing.Size(741, 413);
            this.dataGridViewParts.TabIndex = 0;
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Location = new System.Drawing.Point(12, 9);
            this.labelParts.Name = "labelParts";
            this.labelParts.Size = new System.Drawing.Size(99, 13);
            this.labelParts.TabIndex = 1;
            this.labelParts.Text = "Детали на складе";
            // 
            // buttonOrderPart
            // 
            this.buttonOrderPart.Location = new System.Drawing.Point(759, 25);
            this.buttonOrderPart.Name = "buttonOrderPart";
            this.buttonOrderPart.Size = new System.Drawing.Size(169, 23);
            this.buttonOrderPart.TabIndex = 2;
            this.buttonOrderPart.Text = "Заказать детали";
            this.buttonOrderPart.UseVisualStyleBackColor = true;
            this.buttonOrderPart.Click += new System.EventHandler(this.buttonOrderPart_Click);
            // 
            // buttonPartsMovement
            // 
            this.buttonPartsMovement.Location = new System.Drawing.Point(759, 54);
            this.buttonPartsMovement.Name = "buttonPartsMovement";
            this.buttonPartsMovement.Size = new System.Drawing.Size(169, 23);
            this.buttonPartsMovement.TabIndex = 3;
            this.buttonPartsMovement.Text = "Отчет по движению";
            this.buttonPartsMovement.UseVisualStyleBackColor = true;
            this.buttonPartsMovement.Click += new System.EventHandler(this.buttonPartsMovement_Click);
            // 
            // buttonRequests
            // 
            this.buttonRequests.Location = new System.Drawing.Point(759, 83);
            this.buttonRequests.Name = "buttonRequests";
            this.buttonRequests.Size = new System.Drawing.Size(169, 23);
            this.buttonRequests.TabIndex = 4;
            this.buttonRequests.Text = "Запросы";
            this.buttonRequests.UseVisualStyleBackColor = true;
            this.buttonRequests.Click += new System.EventHandler(this.buttonRequests_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(759, 112);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(169, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(759, 141);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(169, 23);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Создать бэкап";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonStat
            // 
            this.buttonStat.Location = new System.Drawing.Point(759, 170);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(169, 23);
            this.buttonStat.TabIndex = 5;
            this.buttonStat.Text = "Статистика";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.buttonStat);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonRequests);
            this.Controls.Add(this.buttonPartsMovement);
            this.Controls.Add(this.buttonOrderPart);
            this.Controls.Add(this.labelParts);
            this.Controls.Add(this.dataGridViewParts);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.Label labelParts;
        private System.Windows.Forms.Button buttonOrderPart;
        private System.Windows.Forms.Button buttonPartsMovement;
        private System.Windows.Forms.Button buttonRequests;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonStat;
    }
}