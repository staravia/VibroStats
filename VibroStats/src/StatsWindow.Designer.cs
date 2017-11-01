namespace vibromark
{
    partial class StatsWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.scoreText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.averageBPM = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.averageUR = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.L_BpmDrain = new System.Windows.Forms.Label();
            this.L_GeneralUnstability = new System.Windows.Forms.Label();
            this.L_BpmUnstability = new System.Windows.Forms.Label();
            this.L_staminaDrain = new System.Windows.Forms.Label();
            this.L_peakBPM = new System.Windows.Forms.Label();
            this.L_medianBPM = new System.Windows.Forms.Label();
            this.bpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.R_bpmDrain = new System.Windows.Forms.Label();
            this.R_Unstability = new System.Windows.Forms.Label();
            this.R_BpmUnstability = new System.Windows.Forms.Label();
            this.R_staminaDrain = new System.Windows.Forms.Label();
            this.R_peakBPM = new System.Windows.Forms.Label();
            this.R_medianBPM = new System.Windows.Forms.Label();
            this.handPrefText = new System.Windows.Forms.Label();
            this.dateText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // scoreText
            // 
            this.scoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.Location = new System.Drawing.Point(12, 23);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(298, 46);
            this.scoreText.TabIndex = 1;
            this.scoreText.Text = "1442";
            this.scoreText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Accuracy";
            // 
            // accText
            // 
            this.accText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accText.Location = new System.Drawing.Point(6, 97);
            this.accText.Name = "accText";
            this.accText.Size = new System.Drawing.Size(117, 42);
            this.accText.TabIndex = 3;
            this.accText.Text = "99.99%";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Average BPM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // averageBPM
            // 
            this.averageBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageBPM.Location = new System.Drawing.Point(115, 97);
            this.averageBPM.Name = "averageBPM";
            this.averageBPM.Size = new System.Drawing.Size(94, 29);
            this.averageBPM.TabIndex = 5;
            this.averageBPM.Text = "182.11";
            this.averageBPM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Average UR";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // averageUR
            // 
            this.averageUR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageUR.Location = new System.Drawing.Point(198, 97);
            this.averageUR.Name = "averageUR";
            this.averageUR.Size = new System.Drawing.Size(117, 29);
            this.averageUR.TabIndex = 7;
            this.averageUR.Text = "42ms";
            this.averageUR.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.averageUR.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.L_BpmDrain);
            this.groupBox1.Controls.Add(this.L_GeneralUnstability);
            this.groupBox1.Controls.Add(this.L_BpmUnstability);
            this.groupBox1.Controls.Add(this.L_staminaDrain);
            this.groupBox1.Controls.Add(this.L_peakBPM);
            this.groupBox1.Controls.Add(this.L_medianBPM);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(11, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left Hand";
            // 
            // L_BpmDrain
            // 
            this.L_BpmDrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_BpmDrain.Location = new System.Drawing.Point(6, 72);
            this.L_BpmDrain.Name = "L_BpmDrain";
            this.L_BpmDrain.Size = new System.Drawing.Size(136, 15);
            this.L_BpmDrain.TabIndex = 5;
            this.L_BpmDrain.Text = "BpmDrain/Sec: -0.2bpm/s";
            // 
            // L_GeneralUnstability
            // 
            this.L_GeneralUnstability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_GeneralUnstability.Location = new System.Drawing.Point(6, 102);
            this.L_GeneralUnstability.Name = "L_GeneralUnstability";
            this.L_GeneralUnstability.Size = new System.Drawing.Size(141, 15);
            this.L_GeneralUnstability.TabIndex = 4;
            this.L_GeneralUnstability.Text = "General Unstability: 23ms";
            this.L_GeneralUnstability.Click += new System.EventHandler(this.label13_Click);
            // 
            // L_BpmUnstability
            // 
            this.L_BpmUnstability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_BpmUnstability.Location = new System.Drawing.Point(6, 87);
            this.L_BpmUnstability.Name = "L_BpmUnstability";
            this.L_BpmUnstability.Size = new System.Drawing.Size(137, 15);
            this.L_BpmUnstability.TabIndex = 3;
            this.L_BpmUnstability.Text = "BPM Unstable Rate: 50ms";
            // 
            // L_staminaDrain
            // 
            this.L_staminaDrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_staminaDrain.Location = new System.Drawing.Point(6, 57);
            this.L_staminaDrain.Name = "L_staminaDrain";
            this.L_staminaDrain.Size = new System.Drawing.Size(136, 15);
            this.L_staminaDrain.TabIndex = 2;
            this.L_staminaDrain.Text = "Stamina Drain: -10.2bpm";
            // 
            // L_peakBPM
            // 
            this.L_peakBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_peakBPM.Location = new System.Drawing.Point(6, 42);
            this.L_peakBPM.Name = "L_peakBPM";
            this.L_peakBPM.Size = new System.Drawing.Size(136, 15);
            this.L_peakBPM.TabIndex = 1;
            this.L_peakBPM.Text = "Peak BPM: 180.2";
            // 
            // L_medianBPM
            // 
            this.L_medianBPM.AccessibleDescription = "";
            this.L_medianBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_medianBPM.Location = new System.Drawing.Point(6, 27);
            this.L_medianBPM.Name = "L_medianBPM";
            this.L_medianBPM.Size = new System.Drawing.Size(136, 15);
            this.L_medianBPM.TabIndex = 0;
            this.L_medianBPM.Text = "Median BPM: 180.2";
            this.L_medianBPM.Click += new System.EventHandler(this.label9_Click);
            // 
            // bpmChart
            // 
            this.bpmChart.BackColor = System.Drawing.Color.Transparent;
            this.bpmChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisX.LabelStyle.Format = "#s";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleBreakStyle.Spacing = 0D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Format = "#bpm";
            chartArea1.AxisY.LabelStyle.Interval = 20D;
            chartArea1.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.Interval = 20D;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.Minimum = 160D;
            chartArea1.AxisY.ScaleBreakStyle.Spacing = 0D;
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.AxisY.ScrollBar.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.bpmChart.ChartAreas.Add(chartArea1);
            this.bpmChart.Location = new System.Drawing.Point(11, 267);
            this.bpmChart.Name = "bpmChart";
            this.bpmChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.bpmChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "lhBpm";
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "rhBpm";
            this.bpmChart.Series.Add(series1);
            this.bpmChart.Series.Add(series2);
            this.bpmChart.Size = new System.Drawing.Size(304, 126);
            this.bpmChart.TabIndex = 10;
            this.bpmChart.Text = "chart1";
            this.bpmChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.R_bpmDrain);
            this.groupBox2.Controls.Add(this.R_Unstability);
            this.groupBox2.Controls.Add(this.R_BpmUnstability);
            this.groupBox2.Controls.Add(this.R_staminaDrain);
            this.groupBox2.Controls.Add(this.R_peakBPM);
            this.groupBox2.Controls.Add(this.R_medianBPM);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(163, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 123);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Right Hand";
            // 
            // R_bpmDrain
            // 
            this.R_bpmDrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_bpmDrain.Location = new System.Drawing.Point(6, 72);
            this.R_bpmDrain.Name = "R_bpmDrain";
            this.R_bpmDrain.Size = new System.Drawing.Size(136, 15);
            this.R_bpmDrain.TabIndex = 5;
            this.R_bpmDrain.Text = "BpmDrain/Sec: -0.2bpm/s";
            // 
            // R_Unstability
            // 
            this.R_Unstability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Unstability.Location = new System.Drawing.Point(6, 102);
            this.R_Unstability.Name = "R_Unstability";
            this.R_Unstability.Size = new System.Drawing.Size(141, 15);
            this.R_Unstability.TabIndex = 4;
            this.R_Unstability.Text = "General Unstability: 23ms";
            // 
            // R_BpmUnstability
            // 
            this.R_BpmUnstability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_BpmUnstability.Location = new System.Drawing.Point(6, 87);
            this.R_BpmUnstability.Name = "R_BpmUnstability";
            this.R_BpmUnstability.Size = new System.Drawing.Size(137, 15);
            this.R_BpmUnstability.TabIndex = 3;
            this.R_BpmUnstability.Text = "BPM Unstable Rate: 50ms";
            // 
            // R_staminaDrain
            // 
            this.R_staminaDrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_staminaDrain.Location = new System.Drawing.Point(6, 57);
            this.R_staminaDrain.Name = "R_staminaDrain";
            this.R_staminaDrain.Size = new System.Drawing.Size(136, 15);
            this.R_staminaDrain.TabIndex = 2;
            this.R_staminaDrain.Text = "Stamina Drain: -10.2bpm";
            // 
            // R_peakBPM
            // 
            this.R_peakBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_peakBPM.Location = new System.Drawing.Point(6, 42);
            this.R_peakBPM.Name = "R_peakBPM";
            this.R_peakBPM.Size = new System.Drawing.Size(136, 15);
            this.R_peakBPM.TabIndex = 1;
            this.R_peakBPM.Text = "Peak BPM: 180.2";
            // 
            // R_medianBPM
            // 
            this.R_medianBPM.AccessibleDescription = "";
            this.R_medianBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_medianBPM.Location = new System.Drawing.Point(6, 27);
            this.R_medianBPM.Name = "R_medianBPM";
            this.R_medianBPM.Size = new System.Drawing.Size(136, 15);
            this.R_medianBPM.TabIndex = 0;
            this.R_medianBPM.Text = "Median BPM: 180.2";
            // 
            // handPrefText
            // 
            this.handPrefText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handPrefText.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.handPrefText.Location = new System.Drawing.Point(12, 59);
            this.handPrefText.Name = "handPrefText";
            this.handPrefText.Size = new System.Drawing.Size(298, 16);
            this.handPrefText.TabIndex = 11;
            this.handPrefText.Text = "2.2% Right Hand Preference";
            this.handPrefText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateText
            // 
            this.dateText.Location = new System.Drawing.Point(8, 391);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(303, 12);
            this.dateText.TabIndex = 12;
            this.dateText.Text = "April 22nd, 10:32pm";
            this.dateText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 412);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.handPrefText);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bpmChart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.averageUR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.averageBPM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.accText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(338, 451);
            this.MinimumSize = new System.Drawing.Size(338, 451);
            this.Name = "Form2";
            this.Text = "VibroStats Results";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label dateText;
        public System.Windows.Forms.DataVisualization.Charting.Chart bpmChart;
        public System.Windows.Forms.Label L_BpmDrain;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label R_bpmDrain;
        public System.Windows.Forms.Label R_Unstability;
        public System.Windows.Forms.Label R_BpmUnstability;
        public System.Windows.Forms.Label R_staminaDrain;
        public System.Windows.Forms.Label R_peakBPM;
        public System.Windows.Forms.Label R_medianBPM;
        public System.Windows.Forms.Label handPrefText;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label scoreText;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label accText;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label averageBPM;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label averageUR;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label L_medianBPM;
        public System.Windows.Forms.Label L_GeneralUnstability;
        public System.Windows.Forms.Label L_BpmUnstability;
        public System.Windows.Forms.Label L_staminaDrain;
        public System.Windows.Forms.Label L_peakBPM;
    }
}