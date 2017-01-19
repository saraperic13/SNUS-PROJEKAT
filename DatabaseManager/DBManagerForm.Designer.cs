namespace DatabaseManager
{
    partial class DBManagerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewTags = new System.Windows.Forms.ListView();
            this.listViewAlarms = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemoveAlarm = new System.Windows.Forms.Button();
            this.buttonAddAlarm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tags";
            // 
            // listViewTags
            // 
            this.listViewTags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTags.Location = new System.Drawing.Point(28, 40);
            this.listViewTags.Name = "listViewTags";
            this.listViewTags.Size = new System.Drawing.Size(252, 398);
            this.listViewTags.TabIndex = 4;
            this.listViewTags.UseCompatibleStateImageBehavior = false;
            this.listViewTags.SelectedIndexChanged += new System.EventHandler(this.listViewTags_SelectedIndexChanged);
            // 
            // listViewAlarms
            // 
            this.listViewAlarms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAlarms.Location = new System.Drawing.Point(314, 40);
            this.listViewAlarms.Name = "listViewAlarms";
            this.listViewAlarms.Size = new System.Drawing.Size(240, 398);
            this.listViewAlarms.TabIndex = 5;
            this.listViewAlarms.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alarms for selected tag";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(112, 444);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(85, 24);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemoveAlarm
            // 
            this.buttonRemoveAlarm.Location = new System.Drawing.Point(446, 444);
            this.buttonRemoveAlarm.Name = "buttonRemoveAlarm";
            this.buttonRemoveAlarm.Size = new System.Drawing.Size(85, 24);
            this.buttonRemoveAlarm.TabIndex = 8;
            this.buttonRemoveAlarm.Text = "Remove Alarm";
            this.buttonRemoveAlarm.UseVisualStyleBackColor = true;
            this.buttonRemoveAlarm.Click += new System.EventHandler(this.buttonRemoveAlarm_Click);
            // 
            // buttonAddAlarm
            // 
            this.buttonAddAlarm.Location = new System.Drawing.Point(340, 444);
            this.buttonAddAlarm.Name = "buttonAddAlarm";
            this.buttonAddAlarm.Size = new System.Drawing.Size(85, 24);
            this.buttonAddAlarm.TabIndex = 9;
            this.buttonAddAlarm.Text = "Add Alarm";
            this.buttonAddAlarm.UseVisualStyleBackColor = true;
            this.buttonAddAlarm.Click += new System.EventHandler(this.buttonAddAlarm_Click);
            // 
            // DBManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 495);
            this.Controls.Add(this.buttonAddAlarm);
            this.Controls.Add(this.buttonRemoveAlarm);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewAlarms);
            this.Controls.Add(this.listViewTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DBManagerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewTags;
        private System.Windows.Forms.ListView listViewAlarms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRemoveAlarm;
        private System.Windows.Forms.Button buttonAddAlarm;
    }
}

