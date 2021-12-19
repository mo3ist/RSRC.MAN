using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSRC.MAN
{
    class Resource
    {
        public static List<Resource> Resources = new List<Resource>();
        public static int Count {
            get {
                return Resources.Count;
            }
        }
        public static List<int> TotalVector {
            get
            {
                List<int> vec = new List<int>();
                for (int i=0; i<Resources.Count; i++)
                {
                    vec.Add(Resources[i].Total);
                }
                return vec;

            }
        }
        public static List<int> AvailableVector
        {
            get
            {
                List<int> vec = new List<int>();
                for (int i = 0; i < Resources.Count; i++)
                {
                    vec.Add(Resources[i].Available);
                }
                return vec;

            }
        }

        public int Total = 100;
        public int Available = 100;
        public string Name;

        public Resource(string name)
        {
            Name = name;
            Resources.Add(this);
        }

        public static int Allocate(List<int> req_list)
        {
            for (int i=0; i<req_list.Count; i++)
            {
                Resources[i].Allocate(req_list[i]);
            }

            string log_text = "";
            foreach (int r in req_list)
            {
                log_text += r + ", ";
            }

            Logger.Warning(String.Format("[ {0} ] were allocated successfully.", log_text.Substring(0, log_text.Length-2)));

            return 1;
        }

        public static int Free(List<int> req_list)
        {
            for (int i = 0; i < req_list.Count; i++)
            {
                Resources[i].Free(req_list[i]);
            }

            string log_text = "";
            foreach (int r in req_list)
            {
                log_text += r + ", ";
            }

            Logger.Warning(String.Format("[ {0} ] were freed successfully.", log_text.Substring(0, log_text.Length - 2)));

            return 1;
        }

        private int Allocate(int req)
        {
            Available -= req;
            return 1;
        }

        private int Free(int req)
        {
            Available += req;
            return 1;
        }
    }
}
