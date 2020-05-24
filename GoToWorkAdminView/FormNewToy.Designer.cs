namespace GoToWorkAdminView
{
    partial class FormNewToy
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
            this.labelToyName = new System.Windows.Forms.Label();
            this.textBoxToyName = new System.Windows.Forms.TextBox();
            this.labelPartsList = new System.Windows.Forms.Label();
            this.dataGridViewPartsList = new System.Windows.Forms.DataGridView();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.buttonRequestPart = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartsList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelToyName
            // 
            this.labelToyName.AutoSize = true;
            this.labelToyName.Location = new System.Drawing.Point(12, 9);
            this.labelToyName.Name = "labelToyName";
            this.labelToyName.Size = new System.Drawing.Size(102, 13);
            this.labelToyName.TabIndex = 0;
            this.labelToyName.Text = "Название игрушки";
            // 
            // textBoxToyName
            // 
            this.textBoxToyName.Location = new System.Drawing.Point(12, 25);
            this.textBoxToyName.Name = "textBoxToyName";
            this.textBoxToyName.Size = new System.Drawing.Size(428, 20);
            this.textBoxToyName.TabIndex = 1;
            // 
            // labelPartsList
            // 
            this.labelPartsList.AutoSize = true;
            this.labelPartsList.Location = new System.Drawing.Point(12, 48);
            this.labelPartsList.Name = "labelPartsList";
            this.labelPartsList.Size = new System.Drawing.Size(88, 13);
            this.labelPartsList.TabIndex = 2;
            this.labelPartsList.Text = "Список деталей";
            // 
            // dataGridViewPartsList
            // 
            this.dataGridViewPartsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPartsList.Location = new System.Drawing.Point(12, 64);
            this.dataGridViewPartsList.Name = "dataGridViewPartsList";
            this.dataGridViewPartsList.Size = new System.Drawing.Size(428, 206);
            this.dataGridViewPartsList.TabIndex = 3;
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.Location = new System.Drawing.Point(12, 277);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(428, 23);
            this.buttonAddPart.TabIndex = 4;
            this.buttonAddPart.Text = "Добавить деталь";
            this.buttonAddPart.UseVisualStyleBackColor = true;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // buttonRequestPart
            // 
            this.buttonRequestPart.Location = new System.Drawing.Point(12, 306);
            this.buttonRequestPart.Name = "buttonRequestPart";
            this.buttonRequestPart.Size = new System.Drawing.Size(428, 23);
            this.buttonRequestPart.TabIndex = 5;
            this.buttonRequestPart.Text = "Запросить деталь";
            this.buttonRequestPart.UseVisualStyleBackColor = true;
            this.buttonRequestPart.Click += new System.EventHandler(this.buttonRequestPart_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(12, 335);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(428, 23);
            this.buttonDone.TabIndex = 6;
            this.buttonDone.Text = "Готово";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormNewToy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 370);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonRequestPart);
            this.Controls.Add(this.buttonAddPart);
            this.Controls.Add(this.dataGridViewPartsList);
            this.Controls.Add(this.labelPartsList);
            this.Controls.Add(this.textBoxToyName);
            this.Controls.Add(this.labelToyName);
            this.Name = "FormNewToy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая игрушка";
            this.Load += new System.EventHandler(this.FormNewToy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelToyName;
        private System.Windows.Forms.TextBox textBoxToyName;
        private System.Windows.Forms.Label labelPartsList;
        private System.Windows.Forms.DataGridView dataGridViewPartsList;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.Button buttonRequestPart;
        private System.Windows.Forms.Button buttonDone;
    }
}