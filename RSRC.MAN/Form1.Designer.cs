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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.create_process = new System.Windows.Forms.Button();
            this.process_panel = new System.Windows.Forms.Panel();
            this.resources_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // create_process
            // 
            this.create_process.Location = new System.Drawing.Point(12, 440);
            this.create_process.Name = "create_process";
            this.create_process.Size = new System.Drawing.Size(254, 65);
            this.create_process.TabIndex = 0;
            this.create_process.Text = "Create Process";
            this.create_process.UseVisualStyleBackColor = true;
            this.create_process.Click += new System.EventHandler(this.create_process_Click);
            // 
            // process_panel
            // 
            this.process_panel.AutoScroll = true;
            this.process_panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.process_panel.Location = new System.Drawing.Point(12, 12);
            this.process_panel.Name = "process_panel";
            this.process_panel.Size = new System.Drawing.Size(254, 422);
            this.process_panel.TabIndex = 1;
            // 
            // resources_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.resources_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.resources_chart.Legends.Add(legend2);
            this.resources_chart.Location = new System.Drawing.Point(282, 12);
            this.resources_chart.Name = "resources_chart";
            series4.ChartArea = "ChartArea1";
            series4.CustomProperties = "PointWidth=1";
            series4.Legend = "Legend1";
            series4.Name = "RAM";
            series5.ChartArea = "ChartArea1";
            series5.CustomProperties = "PointWidth=1";
            series5.Legend = "Legend1";
            series5.Name = "Semaphores";
            series6.ChartArea = "ChartArea1";
            series6.CustomProperties = "PointWidth=1";
            series6.Legend = "Legend1";
            series6.Name = "Interfaces";
            this.resources_chart.Series.Add(series4);
            this.resources_chart.Series.Add(series5);
            this.resources_chart.Series.Add(series6);
            this.resources_chart.Size = new System.Drawing.Size(933, 300);
            this.resources_chart.TabIndex = 2;
            this.resources_chart.Text = "RAM";
            this.resources_chart.Click += new System.EventHandler(this.ram_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(282, 319);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(933, 186);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 517);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.resources_chart);
            this.Controls.Add(this.process_panel);
            this.Controls.Add(this.create_process);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resources_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_process;
        private System.Windows.Forms.Panel process_panel;
        private System.Windows.Forms.DataVisualization.Charting.Chart resources_chart;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

