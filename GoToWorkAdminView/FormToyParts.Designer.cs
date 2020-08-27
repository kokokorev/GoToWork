namespace GoToWorkAdminView
{
    partial class FormToyParts
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
            this.labelPickToy = new System.Windows.Forms.Label();
            this.dataGridViewPickToy = new System.Windows.Forms.DataGridView();
            this.labelDocFormat = new System.Windows.Forms.Label();
            this.comboBoxDocForm = new System.Windows.Forms.ComboBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPickToy)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPickToy
            // 
            this.labelPickToy.AutoSize = true;
            this.labelPickToy.Location = new System.Drawing.Point(12, 9);
            this.labelPickToy.Name = "labelPickToy";
            this.labelPickToy.Size = new System.Drawing.Size(101, 13);
            this.labelPickToy.TabIndex = 0;
            this.labelPickToy.Text = "Выберите игрушку";
            // 
            // dataGridViewPickToy
            // 
            this.dataGridViewPickToy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPickToy.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewPickToy.Name = "dataGridViewPickToy";
            this.dataGridViewPickToy.Size = new System.Drawing.Size(366, 150);
            this.dataGridViewPickToy.TabIndex = 1;
            // 
            // labelDocFormat
            // 
            this.labelDocFormat.AutoSize = true;
            this.labelDocFormat.Location = new System.Drawing.Point(12, 178);
            this.labelDocFormat.Name = "labelDocFormat";
            this.labelDocFormat.Size = new System.Drawing.Size(156, 13);
            this.labelDocFormat.TabIndex = 2;
            this.labelDocFormat.Text = "Выберите формат документа";
            // 
            // comboBoxDocForm
            // 
            this.comboBoxDocForm.FormattingEnabled = true;
            this.comboBoxDocForm.Location = new System.Drawing.Point(12, 194);
            this.comboBoxDocForm.Name = "comboBoxDocForm";
            this.comboBoxDocForm.Size = new System.Drawing.Size(366, 21);
            this.comboBoxDocForm.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(12, 260);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(366, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Отправить отчет";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(12, 234);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(366, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 218);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(77, 13);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Введите Email";
            // 
            // FormToyParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 293);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.comboBoxDocForm);
            this.Controls.Add(this.labelDocFormat);
            this.Controls.Add(this.dataGridViewPickToy);
            this.Controls.Add(this.labelPickToy);
            this.Name = "FormToyParts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Состав игрушки";
            this.Load += new System.EventHandler(this.FormToyParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPickToy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPickToy;
        private System.Windows.Forms.DataGridView dataGridViewPickToy;
        private System.Windows.Forms.Label labelDocFormat;
        private System.Windows.Forms.ComboBox comboBoxDocForm;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
    }
}