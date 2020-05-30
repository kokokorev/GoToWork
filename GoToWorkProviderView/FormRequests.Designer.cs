namespace GoToWorkProviderView
{
    partial class FormRequests
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
            this.labelRequests = new System.Windows.Forms.Label();
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.buttonOrderPart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxForm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRequests
            // 
            this.labelRequests.AutoSize = true;
            this.labelRequests.Location = new System.Drawing.Point(12, 9);
            this.labelRequests.Name = "labelRequests";
            this.labelRequests.Size = new System.Drawing.Size(73, 13);
            this.labelRequests.TabIndex = 0;
            this.labelRequests.Text = "Все запросы";
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.Size = new System.Drawing.Size(526, 319);
            this.dataGridViewRequests.TabIndex = 1;
            // 
            // buttonOrderPart
            // 
            this.buttonOrderPart.Location = new System.Drawing.Point(12, 390);
            this.buttonOrderPart.Name = "buttonOrderPart";
            this.buttonOrderPart.Size = new System.Drawing.Size(171, 23);
            this.buttonOrderPart.TabIndex = 2;
            this.buttonOrderPart.Text = "Заказать деталь";
            this.buttonOrderPart.UseVisualStyleBackColor = true;
            this.buttonOrderPart.Click += new System.EventHandler(this.buttonOrderPart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Формат отчета";
            // 
            // comboBoxForm
            // 
            this.comboBoxForm.FormattingEnabled = true;
            this.comboBoxForm.Location = new System.Drawing.Point(12, 363);
            this.comboBoxForm.Name = "comboBox1";
            this.comboBoxForm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxForm.TabIndex = 4;
            // 
            // FormRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 422);
            this.Controls.Add(this.comboBoxForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOrderPart);
            this.Controls.Add(this.dataGridViewRequests);
            this.Controls.Add(this.labelRequests);
            this.Name = "FormRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запросы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRequests;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button buttonOrderPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxForm;
    }
}