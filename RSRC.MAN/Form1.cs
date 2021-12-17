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

namespace RSRC.MAN
{
    public partial class Form1 : Form
    {

        public static int p_size = 60;

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

            if (!p.Initialized)
            {
                Console.WriteLine("Creation Failed.");
                return;
            }

            Label p_text = new Label();
            p_text.Name = p.Name;
            p_text.Text = p.Name;
            p_text.Top = (Process.Count-1) * p_size;
            p_text.Left = process_panel.Left;

            ProgressBar p_progress = new ProgressBar();
            p_progress.Name = p.Name;
            p_progress.Top = p_text.Bottom;
            p_progress.Maximum = p.Max.Sum();
            p_progress.Width = process_panel.Width;

            Label maxed = new Label();
            maxed.Text = "Maxed!";
            maxed.Location = p_progress.Location;
            maxed.Size = p_progress.Size;
            maxed.Visible = true;

            Button terminate_process = new Button();
            terminate_process.Name = p.Name;
            terminate_process.Text = "Terminate";
            terminate_process.Top = p_text.Top;
            terminate_process.Left = p_text.Right;
            terminate_process.Click += (object sender, EventArgs e) =>
            {
                process_panel.Controls.Remove(p_text);
                process_panel.Controls.Remove(p_progress);
                process_panel.Controls.Remove(maxed);

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
            process_panel.Controls.Add(maxed);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Resource r1 = new Resource();
            Resource r2 = new Resource();
            Resource r3 = new Resource();

            resources_chart.ChartAreas[0].AxisY.Maximum = r1.Total;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
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
                // so, lazy hack
                object s = resources_chart.Series;

            }
            catch
            {
                return;
            }

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

            foreach (ProgressBar item in process_panel.Controls.OfType<ProgressBar>().ToList())
            {
                Process p = Process.Processes.Where(i => i.Name == item.Name).First();
                item.Value = p.Allocated.Sum();
                if (!p.Active)
                {
                    process_panel.Controls.Remove(item);
                }
            }
        }
    }
}
