namespace RSRC.MAN
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.create_process = new System.Windows.Forms.Button();
            this.process_panel = new System.Windows.Forms.Panel();
            this.resources_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.logger = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // create_process
            // 
            this.create_process.Location = new System.Drawing.Point(12, 440);
            this.create_process.Name = "create_process";
            this.create_process.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.create_process.Size = new System.Drawing.Size(264, 65);
            this.create_process.TabIndex = 0;
            this.create_process.Text = "Create A Process";
            this.create_process.UseVisualStyleBackColor = true;
            this.create_process.Click += new System.EventHandler(this.create_process_Click);
            // 
            // process_panel
            // 
            this.process_panel.AutoScroll = true;
            this.process_panel.BackColor = System.Drawing.SystemColors.Control;
            this.process_panel.Location = new System.Drawing.Point(12, 12);
            this.process_panel.Margin = new System.Windows.Forms.Padding(0);
            this.process_panel.Name = "process_panel";
            this.process_panel.Padding = new System.Windows.Forms.Padding(10);
            this.process_panel.Size = new System.Drawing.Size(264, 425);
            this.process_panel.TabIndex = 1;
            // 
            // resources_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.resources_chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.resources_chart.Legends.Add(legend4);
            this.resources_chart.Location = new System.Drawing.Point(282, 12);
            this.resources_chart.Name = "resources_chart";
            series10.ChartArea = "ChartArea1";
            series10.CustomProperties = "PointWidth=1";
            series10.Legend = "Legend1";
            series10.Name = "RAM";
            series11.ChartArea = "ChartArea1";
            series11.CustomProperties = "PointWidth=1";
            series11.Legend = "Legend1";
            series11.Name = "Semaphores";
            series12.ChartArea = "ChartArea1";
            series12.CustomProperties = "PointWidth=1";
            series12.Legend = "Legend1";
            series12.Name = "Interfaces";
            this.resources_chart.Series.Add(series10);
            this.resources_chart.Series.Add(series11);
            this.resources_chart.Series.Add(series12);
            this.resources_chart.Size = new System.Drawing.Size(933, 300);
            this.resources_chart.TabIndex = 2;
            this.resources_chart.Text = "Resources";
            title7.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title7.Name = "Processes";
            title7.Text = "Processes";
            title8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title8.Name = "Resource Capacity";
            title8.Text = "Resource Capacity";
            this.resources_chart.Titles.Add(title7);
            this.resources_chart.Titles.Add(title8);
            this.resources_chart.Click += new System.EventHandler(this.ram_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Logs:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // logger
            // 
            this.logger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logger.Cursor = System.Windows.Forms.Cursors.No;
            this.logger.Location = new System.Drawing.Point(282, 345);
            this.logger.Name = "logger";
            this.logger.ReadOnly = true;
            this.logger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logger.Size = new System.Drawing.Size(933, 160);
            this.logger.TabIndex = 7;
            this.logger.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 517);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resources_chart);
            this.Controls.Add(this.process_panel);
            this.Controls.Add(this.create_process);
            this.Name = "Form1";
            this.Text = "RSRC.MAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_process;
        private System.Windows.Forms.Panel process_panel;
        private System.Windows.Forms.DataVisualization.Charting.Chart resources_chart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox logger;
    }
}

