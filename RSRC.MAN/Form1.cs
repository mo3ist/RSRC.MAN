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

        public Form1()
        {
            InitializeComponent();
        }

        private void create_process_Click(object sender, EventArgs e)
        {
            addProcess();
           // addProcess();
        }

        private void addProcess()
        {
            Process p = new Process();

            Label p_text = new Label();
            p_text.Name = "p_text" + Process.Count;
            p_text.Text = p_text.Name;
            p_text.Top = Process.Count * 60;
            p_text.Left = process_panel.Left;

            Button terminate_process = new Button();
            terminate_process.Name = "terminate_process" + Process.Count;
            terminate_process.Text = "Terminate";
            terminate_process.Top = Process.Count * 60;
            terminate_process.Left = p_text.Right;
            terminate_process.Click += (object sender, EventArgs e) =>
            {
                process_panel.Controls.Remove(p_text);
                process_panel.Controls.Remove(terminate_process);
                p.Terminate();
            };

            process_panel.Controls.Add(p_text);
            process_panel.Controls.Add(terminate_process);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Resource r1 = new Resource();
            Resource r2 = new Resource();
            Resource r3 = new Resource();
            //fillResourceChars();

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void fillResourceChars()
        {

            resources_chart.Series["RAM"].Points.Clear();
            resources_chart.Series["Semaphores"].Points.Clear();
            resources_chart.Series["Interfaces"].Points.Clear();
            resources_chart.Series["RAM"].Points.AddXY("Process 1", "10000");
            resources_chart.Series["Semaphores"].Points.AddXY("Process 1", "1000");
        }

        private void ram_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillResourceChars();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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
            resources_chart.Series["RAM"].Points.Clear();
            resources_chart.Series["Semaphores"].Points.Clear();
            resources_chart.Series["Interfaces"].Points.Clear();
            for (int i=0; i<Process.Count; i++)
            {
                for (int j=0; j<Resource.Count; j++)
                {
                    resources_chart.Series[j].Points.AddXY("Process "+i, Process.AllocatedMatrix[i][j]+"000");
                }
            }
        }
    }
}
