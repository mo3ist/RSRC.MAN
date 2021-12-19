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
        public static int RequestInterval = 1000;
        public static int RequestStep = 100;

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

        // Process is running
        public bool Active = true;

        // Process has been created
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

            // Name (works as a global id, too)
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

            // Request timer
            timer = new System.Timers.Timer();
            timer.AutoReset = false;

            // Initial request
            timer.Start();

            timer.Elapsed +=
            // Timer wrapper
            (object sender, ElapsedEventArgs e) => 
            {
                // Stop and assign the interval
                timer.Stop();
                timer.Interval = RequestInterval;

                // Call the request
                Request();

                // Start
                timer.Start();
            };
        }

        private List<int> BuildRequestList()
        {
            // Generate random request list
            // TODO: There will be an edge case with a 0 request vector, handle that

            List<int> vec = new List<int>();
            for (int i=0; i<Resource.Count; i++)
            {
                vec.Add(
                    rand.Next(
                        Math.Min(RequestStep, Max[i]-Allocated[i]+1)
                    )
                );
            }

            return vec;
        }

        public void Request()
        {
            List<int> req_vec = BuildRequestList();

            int index = Processes.FindIndex(p => p.Name == this.Name);

            if (index == -1)
            {
                Terminate();
            }

            List<List<int>> req_matrix = BankerCheck.intiateReq(index, new List<int>(req_vec));

            List<List<int>> AllocatedMatrixCopy = new List<List<int>>();
            foreach (List<int> vec in Process.AllocatedMatrix)
            {
                List<int> temp_vec = new List<int>();
                foreach (int i in vec)
                {
                    temp_vec.Add(i);
                }
                AllocatedMatrixCopy.Add(temp_vec);
            }

            List<int> AvailableVectorCopy = new List<int>();
            foreach (int i in Resource.AvailableVector)
            {
                AvailableVectorCopy.Add(i);
            }

            Logger.Info(String.Format("{0}'s request is being checked.", Name));

            bool granted;

            //try
            //{
                granted = BankerCheck.grantRequest(
                    Process.MaxMatrix,
                    AllocatedMatrixCopy,
                    req_matrix,
                    AvailableVectorCopy
                );
            //} 
            //catch
            //{
            //    granted = false;
            //}
            

            // If request is grated by the Banker's alogrithm
            if (granted)
            {
                Logger.Warning(String.Format("{0}'s request was granted.", Name));

                if (!Initialized)
                {
                    Initialized = true;
                    Logger.Debug(String.Format("{0} was created successfully.", Name));
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
            }
            else
            {
                Logger.Error(String.Format("{0}'s request was denied.", Name));

                // Terminate if initial allocation failed
                if (Allocated.Sum() == 0)
                {
                    Terminate();
                    Logger.Fatal(String.Format("{0} was terminated due to a resource shortage.", Name));
                }
            }

            if (!Active)
            {
                // Auto termination
                Logger.Debug(String.Format("{0} was terminated. Process has maxed.", Name));

                Terminate();
            }
           
        }

        public void Terminate()
        {
            // Remove from process list
            Process.Processes.Remove(this);

            // Stop the timer
            timer.Stop();
            timer.Close();
            
            // Free the resources
            Resource.Free(Allocated);
        }

    }
}
