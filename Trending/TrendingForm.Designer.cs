namespace Trending
{
    partial class TrendingForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.trendingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trendingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // trendingChart
            // 
            chartArea2.Name = "ChartArea1";
            this.trendingChart.ChartAreas.Add(chartArea2);
            this.trendingChart.Location = new System.Drawing.Point(12, 12);
            this.trendingChart.Name = "trendingChart";
            this.trendingChart.Size = new System.Drawing.Size(882, 493);
            this.trendingChart.TabIndex = 0;
            this.trendingChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 517);
            this.Controls.Add(this.trendingChart);
            this.Name = "Form1";
            this.Text = "Trending";
            ((System.ComponentModel.ISupportInitialize)(this.trendingChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart trendingChart;
    }
}

