using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace RSRC.MAN
{
    class Process
    {
        public static List<Process> Processes = new List<Process>();

        public static List<List<int>> AllocatedMatrix {
            get
            {
                List<List<int>> matrix = new List<List<int>>();
                for (int i = 0; i < Processes.Count; i++) {
                    matrix.Add(Processes[i].Allocated);
                }
                return matrix;
            }
        }

        public static List<List<int>> MaxMatrix
        {
            get
            {
                List<List<int>> matrix = new List<List<int>>();
                for (int i = 0; i < Processes.Count; i++)
                {
                    matrix.Add(Processes[i].Max);
                }
                return matrix;
            }
        }

        public static int Count
        {
            get
            {
                return Processes.Count;
            }
        }

        public bool Active = true;
        public bool Initialized = false;
        public List<int> Max = new List<int>();
        public List<int> Allocated = new List<int>();

        private System.Timers.Timer timer;
        private static Random rand = new Random();  // Must be instantiated once!

        public string Name;

        public Process()
        {

            // Add to Processes 
            Processes.Add(this);

            // Name
            Name = "Process #" + Process.Count;

            // Initialize Max
            for (int i=0; i<Resource.Count; i++)
            {
                int resource_max = Resource.TotalVector[i];
                Max.Add(rand.Next(resource_max));
            }

            // Initialize Allocated
            for (int i = 0; i < Max.Count; i++)
            {
                Allocated.Add(0);
            }

            // Initial request && initialization
            Request(null, null); 

            // Request timer
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += Request;
            timer.AutoReset = Active;
            timer.Start();

        }

        private List<int> BuildRequestList()
        {
            // Generate random request list
            // TODO: There will be an edge case with a 0 request vector, handle that

            List<int> vec = new List<int>();
            for (int i=0; i<Resource.Count; i++)
            {
                vec.Add(rand.Next(Max[i] - Allocated[i] + 1));
            }

            return vec;
        }

        public void Request(Object source, ElapsedEventArgs e)
        {
            //Request vector: req_vec
            List<int> req_vec = BuildRequestList();

            //Available resources: Resource.AvailableVector
            //Max matrix: Process.MaxMatrix
            //Allocated matrix: Process.AllocatedMatrix
            //كسمك مش هكتب سطر كود تاني

            bool granted = rand.Next(2) == 1;

            // If request is grated by the Banker's alogrithm
            if (granted)
            {
                if (!Initialized)
                {
                    Initialized = true;
                }

                int allocated = Resource.Allocate(req_vec);

                for (int i=0; i<Allocated.Count; i++)
                {
                    Allocated[i] += req_vec[i];
                }

                // Check if process has maxed
                bool maxed = true;
                for (int i=0; i<Allocated.Count; i++)
                {
                    if (Allocated[i] < Max[i])
                    {
                        maxed = false;
                    }
                }
                if (maxed)
                {
                    Active = false;
                }
            } else
            {
                // Terminate if initial allocation failed
                if (Allocated.Sum() == 0)
                {
                    Terminate();
                }
            }

            if (!Active)
            {
                timer.Stop();
                timer.Close();

                Console.WriteLine("TERMINATING: MAXED");
                //Terminate();
            }
           
        }

        public void Terminate()
        {
            // Remove from process list
            Process.Processes.Remove(this);

            // Stop the timer
            if (timer != null)
            {
                timer.Stop();
                timer.Close();
            }
            // Free the resources
            Resource.Free(Allocated);
        }

    }
}
