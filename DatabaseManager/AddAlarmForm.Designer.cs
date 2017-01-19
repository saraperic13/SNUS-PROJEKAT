namespace DatabaseManager
{
    partial class AddAlarmForm
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
            this.buttonSaveAlarm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAlarmID = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxHigh = new System.Windows.Forms.TextBox();
            this.textBoxLow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSaveAlarm
            // 
            this.buttonSaveAlarm.Location = new System.Drawing.Point(161, 251);
            this.buttonSaveAlarm.Name = "buttonSaveAlarm";
            this.buttonSaveAlarm.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAlarm.TabIndex = 0;
            this.buttonSaveAlarm.Text = "Save";
            this.buttonSaveAlarm.UseVisualStyleBackColor = true;
            this.buttonSaveAlarm.Click += new System.EventHandler(this.buttonSaveAlarm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alarm ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Low Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "High Value:";
            // 
            // textBoxAlarmID
            // 
            this.textBoxAlarmID.Location = new System.Drawing.Point(136, 53);
            this.textBoxAlarmID.Name = "textBoxAlarmID";
            this.textBoxAlarmID.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlarmID.TabIndex = 5;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(136, 92);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(100, 20);
            this.textBoxDescription.TabIndex = 6;
            // 
            // textBoxHigh
            // 
            this.textBoxHigh.Location = new System.Drawing.Point(136, 174);
            this.textBoxHigh.Name = "textBoxHigh";
            this.textBoxHigh.Size = new System.Drawing.Size(100, 20);
            this.textBoxHigh.TabIndex = 7;
            // 
            // textBoxLow
            // 
            this.textBoxLow.Location = new System.Drawing.Point(136, 133);
            this.textBoxLow.Name = "textBoxLow";
            this.textBoxLow.Size = new System.Drawing.Size(100, 20);
            this.textBoxLow.TabIndex = 8;
            // 
            // AddAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 301);
            this.Controls.Add(this.textBoxLow);
            this.Controls.Add(this.textBoxHigh);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxAlarmID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveAlarm);
            this.Name = "AddAlarm";
            this.Text = "AddAlarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveAlarm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAlarmID;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxHigh;
        private System.Windows.Forms.TextBox textBoxLow;
    }
}