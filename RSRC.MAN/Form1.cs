using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSRC.MAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void create_resource_Click(object sender, EventArgs e)
        {
            Resource r = new Resource();
            Console.WriteLine("New resource created. Resource count: " + Resource.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            Console.WriteLine("New process created. Process count: " + Process.Count);
        }

        private void display_data_Click(object sender, EventArgs e)
        {
            // Available
            Console.WriteLine("Available:");
            foreach (int a in Resource.AvailableVector)
            {
                Console.Write("{0} ", a);
            }

            Console.WriteLine();

            // Allocated
            Console.WriteLine("Allocated:");
            foreach (List<int> vec in Process.AllocatedMatrix)
            {
                foreach (int a in vec)
                {
                    Console.Write("{0} ", a);
                }
                Console.WriteLine();
            }
        }

        private void terminate_process_Click(object sender, EventArgs e)
        {
            Process.Processes[0].Terminate();
        }
    }
}
