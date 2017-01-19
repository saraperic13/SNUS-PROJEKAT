namespace DatabaseManager
{
    partial class AddTagForm
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
            this.comboBoxTagType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTagId = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxUnits = new System.Windows.Forms.TextBox();
            this.textBoxInitialValue = new System.Windows.Forms.TextBox();
            this.textBoxHighLimit = new System.Windows.Forms.TextBox();
            this.textBoxScanTime = new System.Windows.Forms.TextBox();
            this.textBoxTagAddress = new System.Windows.Forms.TextBox();
            this.comboBoxFunctionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxAutoMode = new System.Windows.Forms.CheckBox();
            this.checkBoxOnScan = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTagType
            // 
            this.comboBoxTagType.AllowDrop = true;
            this.comboBoxTagType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTagType.Items.AddRange(new object[] {
            "Analog Input",
            "Analog Output",
            "Digital Input",
            "Digital Output"});
            this.comboBoxTagType.Location = new System.Drawing.Point(83, 20);
            this.comboBoxTagType.Name = "comboBoxTagType";
            this.comboBoxTagType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTagType.TabIndex = 0;
            this.comboBoxTagType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTagType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tag Type:";
            // 
            // textBoxTagId
            // 
            this.textBoxTagId.Location = new System.Drawing.Point(333, 17);
            this.textBoxTagId.Name = "textBoxTagId";
            this.textBoxTagId.Size = new System.Drawing.Size(118, 20);
            this.textBoxTagId.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(333, 80);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(118, 20);
            this.textBoxDescription.TabIndex = 3;
            // 
            // textBoxLowLimit
            // 
            this.textBoxLowLimit.Location = new System.Drawing.Point(83, 309);
            this.textBoxLowLimit.Name = "textBoxLowLimit";
            this.textBoxLowLimit.Size = new System.Drawing.Size(118, 20);
            this.textBoxLowLimit.TabIndex = 4;
            // 
            // textBoxUnits
            // 
            this.textBoxUnits.Location = new System.Drawing.Point(83, 265);
            this.textBoxUnits.Name = "textBoxUnits";
            this.textBoxUnits.Size = new System.Drawing.Size(118, 20);
            this.textBoxUnits.TabIndex = 5;
            // 
            // textBoxInitialValue
            // 
            this.textBoxInitialValue.Location = new System.Drawing.Point(83, 224);
            this.textBoxInitialValue.Name = "textBoxInitialValue";
            this.textBoxInitialValue.Size = new System.Drawing.Size(118, 20);
            this.textBoxInitialValue.TabIndex = 6;
            // 
            // textBoxHighLimit
            // 
            this.textBoxHighLimit.Location = new System.Drawing.Point(83, 361);
            this.textBoxHighLimit.Name = "textBoxHighLimit";
            this.textBoxHighLimit.Size = new System.Drawing.Size(118, 20);
            this.textBoxHighLimit.TabIndex = 7;
            // 
            // textBoxScanTime
            // 
            this.textBoxScanTime.Location = new System.Drawing.Point(86, 179);
            this.textBoxScanTime.Name = "textBoxScanTime";
            this.textBoxScanTime.Size = new System.Drawing.Size(118, 20);
            this.textBoxScanTime.TabIndex = 8;
            // 
            // textBoxTagAddress
            // 
            this.textBoxTagAddress.Location = new System.Drawing.Point(86, 80);
            this.textBoxTagAddress.Name = "textBoxTagAddress";
            this.textBoxTagAddress.Size = new System.Drawing.Size(118, 20);
            this.textBoxTagAddress.TabIndex = 10;
            // 
            // comboBoxFunctionType
            // 
            this.comboBoxFunctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctionType.FormattingEnabled = true;
            this.comboBoxFunctionType.Items.AddRange(new object[] {
            "Sine",
            "Cosine",
            "Ramp",
            "Triangle",
            "Rectangle"});
            this.comboBoxFunctionType.Location = new System.Drawing.Point(333, 134);
            this.comboBoxFunctionType.Name = "comboBoxFunctionType";
            this.comboBoxFunctionType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFunctionType.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Scan Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "I/O Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tag ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Function Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "High Limit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Low Limit:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Units:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Value:";
            // 
            // checkBoxAutoMode
            // 
            this.checkBoxAutoMode.AutoSize = true;
            this.checkBoxAutoMode.Location = new System.Drawing.Point(252, 224);
            this.checkBoxAutoMode.Name = "checkBoxAutoMode";
            this.checkBoxAutoMode.Size = new System.Drawing.Size(78, 17);
            this.checkBoxAutoMode.TabIndex = 21;
            this.checkBoxAutoMode.Text = "Auto Mode";
            this.checkBoxAutoMode.UseVisualStyleBackColor = true;
            this.checkBoxAutoMode.CheckedChanged += new System.EventHandler(this.checkBoxAutoMode_CheckedChanged);
            // 
            // checkBoxOnScan
            // 
            this.checkBoxOnScan.AutoSize = true;
            this.checkBoxOnScan.Location = new System.Drawing.Point(252, 268);
            this.checkBoxOnScan.Name = "checkBoxOnScan";
            this.checkBoxOnScan.Size = new System.Drawing.Size(68, 17);
            this.checkBoxOnScan.TabIndex = 22;
            this.checkBoxOnScan.Text = "On Scan";
            this.checkBoxOnScan.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(317, 409);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(134, 31);
            this.buttonSave.TabIndex = 23;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // AddTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 452);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxOnScan);
            this.Controls.Add(this.checkBoxAutoMode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxFunctionType);
            this.Controls.Add(this.textBoxTagAddress);
            this.Controls.Add(this.textBoxScanTime);
            this.Controls.Add(this.textBoxHighLimit);
            this.Controls.Add(this.textBoxInitialValue);
            this.Controls.Add(this.textBoxUnits);
            this.Controls.Add(this.textBoxLowLimit);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTagId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTagType);
            this.Name = "AddTagForm";
            this.Text = "AddTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTagType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTagId;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxLowLimit;
        private System.Windows.Forms.TextBox textBoxUnits;
        private System.Windows.Forms.TextBox textBoxInitialValue;
        private System.Windows.Forms.TextBox textBoxHighLimit;
        private System.Windows.Forms.TextBox textBoxScanTime;
        private System.Windows.Forms.TextBox textBoxTagAddress;
        private System.Windows.Forms.ComboBox comboBoxFunctionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxAutoMode;
        private System.Windows.Forms.CheckBox checkBoxOnScan;
        private System.Windows.Forms.Button buttonSave;
    }
}