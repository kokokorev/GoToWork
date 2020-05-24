namespace GoToWorkAdminView
{
    partial class FormRequestPart
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
            this.labelPartType = new System.Windows.Forms.Label();
            this.textBoxPartType = new System.Windows.Forms.TextBox();
            this.labelPartColor = new System.Windows.Forms.Label();
            this.textBoxPartColor = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPartType
            // 
            this.labelPartType.AutoSize = true;
            this.labelPartType.Location = new System.Drawing.Point(12, 9);
            this.labelPartType.Name = "labelPartType";
            this.labelPartType.Size = new System.Drawing.Size(64, 13);
            this.labelPartType.TabIndex = 0;
            this.labelPartType.Text = "Тип детали";
            // 
            // textBoxPartType
            // 
            this.textBoxPartType.Location = new System.Drawing.Point(12, 25);
            this.textBoxPartType.Name = "textBoxPartType";
            this.textBoxPartType.Size = new System.Drawing.Size(252, 20);
            this.textBoxPartType.TabIndex = 1;
            // 
            // labelPartColor
            // 
            this.labelPartColor.AutoSize = true;
            this.labelPartColor.Location = new System.Drawing.Point(12, 48);
            this.labelPartColor.Name = "labelPartColor";
            this.labelPartColor.Size = new System.Drawing.Size(70, 13);
            this.labelPartColor.TabIndex = 2;
            this.labelPartColor.Text = "Цвет детали";
            // 
            // textBoxPartColor
            // 
            this.textBoxPartColor.Location = new System.Drawing.Point(12, 64);
            this.textBoxPartColor.Name = "textBoxPartColor";
            this.textBoxPartColor.Size = new System.Drawing.Size(252, 20);
            this.textBoxPartColor.TabIndex = 3;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 87);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(12, 103);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(252, 20);
            this.textBoxCount.TabIndex = 5;
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Location = new System.Drawing.Point(12, 129);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(252, 23);
            this.buttonSendRequest.TabIndex = 6;
            this.buttonSendRequest.Text = "Отправить запрос";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.buttonSendRequest_Click);
            // 
            // FormRequestPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 160);
            this.Controls.Add(this.buttonSendRequest);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxPartColor);
            this.Controls.Add(this.labelPartColor);
            this.Controls.Add(this.textBoxPartType);
            this.Controls.Add(this.labelPartType);
            this.Name = "FormRequestPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запросить деталь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPartType;
        private System.Windows.Forms.TextBox textBoxPartType;
        private System.Windows.Forms.Label labelPartColor;
        private System.Windows.Forms.TextBox textBoxPartColor;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonSendRequest;
    }
}