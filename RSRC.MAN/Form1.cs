using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RSRC.MAN
{
    public partial class Form1 : Form
    {

        public static int p_size = 70;

        public Form1()
        {
            InitializeComponent();
        }

        private void create_process_Click(object sender, EventArgs e)
        {
            addProcess();
        }

        private void addProcess()
        {
            Process p = new Process();

            Label p_text = new Label();
            p_text.Name = p.Name;
            p_text.Text = p.Name;
            p_text.Top = (Process.Count-1) * p_size + 10;
            p_text.Left = process_panel.Left;

            ProgressBar p_progress = new ProgressBar();
            p_progress.Name = p.Name;
            p_progress.Top = p_text.Bottom + 10;
            p_progress.Left = process_panel.Left;
            p_progress.Maximum = p.Max.Sum();
            p_progress.Width = process_panel.Width - 40;

            //Label maxed = new Label();
            //maxed.Text = "Maxed!";
            //maxed.Location = p_progress.Location;
            //maxed.Size = p_progress.Size;
            //maxed.Visible = true;

            Button terminate_process = new Button();
            terminate_process.Name = p.Name;
            terminate_process.Text = "Terminate";
            terminate_process.Top = p_text.Top;
            terminate_process.Left = process_panel.Right - terminate_process.Width - 40;
            terminate_process.Click += (object sender, EventArgs e) =>
            {
                process_panel.Controls.Remove(p_text);
                process_panel.Controls.Remove(p_progress);
                //process_panel.Controls.Remove(maxed);

                // Reposition the Controls under them
                int index = process_panel.Controls.GetChildIndex(terminate_process);
                for (int i=index; i<process_panel.Controls.Count; i++)
                {
                   process_panel.Controls[i].Top -= p_size;
                }

                process_panel.Controls.Remove(terminate_process);

                p.Terminate();
            };

            process_panel.Controls.Add(p_text);
            process_panel.Controls.Add(terminate_process);
            process_panel.Controls.Add(p_progress);
            //process_panel.Controls.Add(maxed);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the resources
            Resource RAM = new Resource("RAM");
            Resource Semaphores = new Resource("Semaphores");
            Resource Interfaces = new Resource("Interfaces");

            // Initialize the charts
            resources_chart.ChartAreas[0].AxisY.Maximum = RAM.Total;

            available_chart.ChartAreas[0].AxisY.Maximum = RAM.Total;
            for (int i = 0; i < Resource.Count; i++)
            {
                available_chart.Series[i].Points.AddXY("", Resource.Resources[i].Available);
            }

            // Start the background worker
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            // Create the logger
            RichFilterableTextBox logger = new RichFilterableTextBox();
            logger.Location = new Point(282, 355);
            logger.Size = new Size(933, 295);
            logger.Name = "logger";
            logger.HideSelection = false;
            this.Controls.Add(logger);
        }

        private void ram_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            List<int> available = Resource.AvailableVector;
            while (true)
            {
                if (!available.SequenceEqual(Resource.AvailableVector))
                {
                    backgroundWorker1.ReportProgress(1);
                }
                Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                // An error occurs here when Char.Series is accessed when the form closes
                // so, a lazy hack.
                object s = resources_chart.Series;

            }
            catch
            {
                return;
            }


            // Plot the data
            resources_chart.Series["RAM"].Points.Clear();
            resources_chart.Series["Semaphores"].Points.Clear();
            resources_chart.Series["Interfaces"].Points.Clear();

            for (int i = 0; i < Process.Count; i++)
            {
                for (int j = 0; j < Resource.Count; j++)
                {
                    resources_chart.Series[j].Points.AddXY(Process.Processes[i].Name, Process.AllocatedMatrix[i][j]);
                }
            }

            // Plot the data
            available_chart.Series["RAM"].Points.Clear();
            available_chart.Series["Semaphores"].Points.Clear();
            available_chart.Series["Interfaces"].Points.Clear();

            for (int i = 0; i < Resource.Count; i++)
            {
                available_chart.Series[i].Points.AddXY("", Resource.Resources[i].Available);
            }

            // Remove terminated process's controls
            foreach (Control item in process_panel.Controls)
            {
                Process item_process = Process.Processes.Find(p => p.Name == item.Name);
                if (item_process == null)
                {
                    Button terminate_process = process_panel.Controls.OfType<Button>().ToList().Find(i => i.Name == item.Name);
                    if (terminate_process != null)
                    {
                        terminate_process.PerformClick();
                    }
                }
            }

            // Update progressbars
            foreach (ProgressBar item in process_panel.Controls.OfType<ProgressBar>().ToList())
            {
                Process p = Process.Processes.Where(i => i.Name == item.Name).First();
                if (p != null)
                {
                    item.Maximum = p.Max.Sum(); // IDK. a hack for an error I don't understand :'

                    item.Value = p.Allocated.Sum();
                    if (!p.Active)
                    {
                        process_panel.Controls.Remove(item);
                    }
                }
            }

            // Update the logger
            RichFilterableTextBox logger = this.Controls.OfType<RichFilterableTextBox>().ToList().Find(i => i.Name == "logger");

            using (RichFilterableTextBox temp_logger = new RichFilterableTextBox())
            {
                temp_logger.Rtf = Logger.GetLog();
                temp_logger.ApplyFilter(filter.Text);


                // Setting this indirectly is cool hack to prevent glitching (all the text gets rendered then filtered instantly)
                logger.Rtf = temp_logger.Rtf;

                // Scroll to bottom
                if (autoscroll.Checked)
                {
                    logger.SelectionStart = logger.Text.Length;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void filter_TextChanged(object sender, EventArgs e)
        {
        }

        private void Available_Click(object sender, EventArgs e)
        {

        }
    }
}
