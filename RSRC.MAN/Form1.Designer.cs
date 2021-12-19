﻿namespace RSRC.MAN
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.create_process = new System.Windows.Forms.Button();
            this.process_panel = new System.Windows.Forms.Panel();
            this.resources_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoscroll = new System.Windows.Forms.CheckBox();
            this.available_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.available_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // create_process
            // 
            this.create_process.Location = new System.Drawing.Point(12, 608);
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
            this.process_panel.Size = new System.Drawing.Size(264, 593);
            this.process_panel.TabIndex = 1;
            // 
            // resources_chart
            // 
            chartArea5.Name = "ChartArea1";
            this.resources_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.resources_chart.Legends.Add(legend5);
            this.resources_chart.Location = new System.Drawing.Point(282, 12);
            this.resources_chart.Name = "resources_chart";
            series13.ChartArea = "ChartArea1";
            series13.CustomProperties = "PointWidth=1";
            series13.Legend = "Legend1";
            series13.Name = "RAM";
            series14.ChartArea = "ChartArea1";
            series14.CustomProperties = "PointWidth=1";
            series14.Legend = "Legend1";
            series14.Name = "Semaphores";
            series15.ChartArea = "ChartArea1";
            series15.CustomProperties = "PointWidth=1";
            series15.Legend = "Legend1";
            series15.Name = "Interfaces";
            this.resources_chart.Series.Add(series13);
            this.resources_chart.Series.Add(series14);
            this.resources_chart.Series.Add(series15);
            this.resources_chart.Size = new System.Drawing.Size(609, 300);
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
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(1012, 325);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(203, 20);
            this.filter.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(957, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter logs";
            // 
            // autoscroll
            // 
            this.autoscroll.AutoSize = true;
            this.autoscroll.Checked = true;
            this.autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoscroll.Location = new System.Drawing.Point(282, 656);
            this.autoscroll.Name = "autoscroll";
            this.autoscroll.Size = new System.Drawing.Size(72, 17);
            this.autoscroll.TabIndex = 9;
            this.autoscroll.Text = "Autoscroll";
            this.autoscroll.UseVisualStyleBackColor = true;
            // 
            // available_chart
            // 
            chartArea6.Name = "ChartArea1";
            this.available_chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.available_chart.Legends.Add(legend6);
            this.available_chart.Location = new System.Drawing.Point(898, 13);
            this.available_chart.Name = "available_chart";
            this.available_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.available_chart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "RAM";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Semaphores";
            series18.ChartArea = "ChartArea1";
            series18.Legend = "Legend1";
            series18.Name = "Interfaces";
            this.available_chart.Series.Add(series16);
            this.available_chart.Series.Add(series17);
            this.available_chart.Series.Add(series18);
            this.available_chart.Size = new System.Drawing.Size(317, 300);
            this.available_chart.TabIndex = 10;
            this.available_chart.Text = "Available";
            title9.Name = "Available Resources";
            title9.Text = "Available Resources";
            this.available_chart.Titles.Add(title9);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1002, 657);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Mohammad Alsakhawy";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(1124, 657);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(82, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Ahmed Elshamy";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(967, 657);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Devs:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 685);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.available_chart);
            this.Controls.Add(this.autoscroll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resources_chart);
            this.Controls.Add(this.process_panel);
            this.Controls.Add(this.create_process);
            this.Name = "Form1";
            this.Text = "RSRC.MAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.available_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_process;
        private System.Windows.Forms.Panel process_panel;
        private System.Windows.Forms.DataVisualization.Charting.Chart resources_chart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox autoscroll;
        private System.Windows.Forms.DataVisualization.Charting.Chart available_chart;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
    }
}

