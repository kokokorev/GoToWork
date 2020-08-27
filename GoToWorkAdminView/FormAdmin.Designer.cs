namespace GoToWorkAdminView
{
    partial class FormAdmin
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
            this.labelToys = new System.Windows.Forms.Label();
            this.dataGridViewToys = new System.Windows.Forms.DataGridView();
            this.buttonNewToy = new System.Windows.Forms.Button();
            this.buttonToyParts = new System.Windows.Forms.Button();
            this.buttonPartsMovement = new System.Windows.Forms.Button();
            this.labelReports = new System.Windows.Forms.Label();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonStat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToys)).BeginInit();
            this.SuspendLayout();
            // 
            // labelToys
            // 
            this.labelToys.AutoSize = true;
            this.labelToys.Location = new System.Drawing.Point(12, 9);
            this.labelToys.Name = "labelToys";
            this.labelToys.Size = new System.Drawing.Size(51, 13);
            this.labelToys.TabIndex = 0;
            this.labelToys.Text = "Игрушки";
            // 
            // dataGridViewToys
            // 
            this.dataGridViewToys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToys.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewToys.Name = "dataGridViewToys";
            this.dataGridViewToys.Size = new System.Drawing.Size(339, 227);
            this.dataGridViewToys.TabIndex = 1;
            // 
            // buttonNewToy
            // 
            this.buttonNewToy.Location = new System.Drawing.Point(12, 258);
            this.buttonNewToy.Name = "buttonNewToy";
            this.buttonNewToy.Size = new System.Drawing.Size(339, 23);
            this.buttonNewToy.TabIndex = 2;
            this.buttonNewToy.Text = "Новая игрушка";
            this.buttonNewToy.UseVisualStyleBackColor = true;
            this.buttonNewToy.Click += new System.EventHandler(this.buttonNewToy_Click);
            // 
            // buttonToyParts
            // 
            this.buttonToyParts.Location = new System.Drawing.Point(357, 25);
            this.buttonToyParts.Name = "buttonToyParts";
            this.buttonToyParts.Size = new System.Drawing.Size(142, 23);
            this.buttonToyParts.TabIndex = 3;
            this.buttonToyParts.Text = "Состав игрушки";
            this.buttonToyParts.UseVisualStyleBackColor = true;
            this.buttonToyParts.Click += new System.EventHandler(this.buttonToyParts_Click);
            // 
            // buttonPartsMovement
            // 
            this.buttonPartsMovement.Location = new System.Drawing.Point(357, 54);
            this.buttonPartsMovement.Name = "buttonPartsMovement";
            this.buttonPartsMovement.Size = new System.Drawing.Size(142, 23);
            this.buttonPartsMovement.TabIndex = 4;
            this.buttonPartsMovement.Text = "Движение деталей";
            this.buttonPartsMovement.UseVisualStyleBackColor = true;
            this.buttonPartsMovement.Click += new System.EventHandler(this.buttonPartsMovement_Click);
            // 
            // labelReports
            // 
            this.labelReports.AutoSize = true;
            this.labelReports.Location = new System.Drawing.Point(354, 9);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new System.Drawing.Size(44, 13);
            this.labelReports.TabIndex = 5;
            this.labelReports.Text = "Отчеты";
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(357, 83);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(142, 23);
            this.buttonBackup.TabIndex = 6;
            this.buttonBackup.Text = "Создать бэкап";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonStat
            // 
            this.buttonStat.Location = new System.Drawing.Point(358, 113);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(141, 23);
            this.buttonStat.TabIndex = 7;
            this.buttonStat.Text = "Статистика";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 291);
            this.Controls.Add(this.buttonStat);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.labelReports);
            this.Controls.Add(this.buttonPartsMovement);
            this.Controls.Add(this.buttonToyParts);
            this.Controls.Add(this.buttonNewToy);
            this.Controls.Add(this.dataGridViewToys);
            this.Controls.Add(this.labelToys);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelToys;
        private System.Windows.Forms.DataGridView dataGridViewToys;
        private System.Windows.Forms.Button buttonNewToy;
        private System.Windows.Forms.Button buttonToyParts;
        private System.Windows.Forms.Button buttonPartsMovement;
        private System.Windows.Forms.Label labelReports;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonStat;
    }
}