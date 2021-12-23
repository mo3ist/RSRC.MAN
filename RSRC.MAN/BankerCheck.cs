using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSRC.MAN
{
    class BankerCheck
    {
        public static bool grantRequest(List<List<int>> Max, List<List<int>> alloc, List<List<int>> Req, List<int> avail)
        {
            List<List<int>> initialNeed = calculateInitialNeed(Max, alloc);//Calculate the need
                                                                           // check if the request is less than the available
            bool checkingres1 = checkReqAvail(Req, avail);
            if (checkingres1 == false) return false;

            // check if the request is less than than need
            checkingres1 = checkReqNeed(Req, initialNeed);
            if (checkingres1 == false) return false;



            calculateStuff(ref initialNeed, Req, ref alloc, ref avail);// edit the need and the available and the allocaited according to the request ...

            bool state = checkSaftey(initialNeed, alloc, avail);



            return state;
        }

        public static List<List<int>> calculateInitialNeed(List<List<int>> max, List<List<int>> alloc)
        {
            int n = max.Count();
            int m = max[0].Count();
            List<List<int>> intialNeed = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                intialNeed.Add(new List<int>());
                for (int j = 0; j < m; j++)
                {
                    intialNeed[i].Add(max[i][j] - alloc[i][j]);
                }
            }




            return intialNeed;
        }



        public static void calculateStuff(ref List<List<int>> initialNeed, List<List<int>> Req, ref List<List<int>> alloc, ref List<int> avail)
        {

            int n = alloc.Count();
            int m = alloc[0].Count();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    initialNeed[i][j] -= Req[i][j];
                    alloc[i][j] += Req[i][j];
                    avail[j] -= Req[i][j];
                }
            }



        }

        public static bool checkReqAvail(List<List<int>> Req, List<int> avail)
        {
            int i;
            for (i = 0; i < Req.Count(); i++)
            {
                int j;
                for (j = 0; j < Req[0].Count(); j++)
                {
                    if (Req[i][j] > avail[j])
                        break;
                }
                if (j != Req[0].Count()) break;

            }

            if (i != Req.Count())
                return false;
            else return true;
        }
        public static bool checkReqNeed(List<List<int>> Req, List<List<int>> Need)
        {
            int i;
            for (i = 0; i < Need.Count(); i++)
            {
                int j;
                for (j = 0; j < Need[0].Count(); j++)
                {
                    if (Req[i][j] > Need[i][j])
                        break;
                }
                if (j != Need[0].Count())
                    break;
            }
            if (i != Need.Count())
                return false;
            else return true;


        }

        public static bool checkSaftey(List<List<int>> need, List<List<int>> alloc, List<int> avail)
        {


            int count = 0;
            int processNum = Convert.ToInt32(need.Count());
            int resourceNum = Convert.ToInt32(need[0].Count());
            bool[] finished = new bool[processNum];
            for (int i = 0; i < processNum; i++)
            {
                finished[i] = false;
            }

            while (count < processNum)
            {

                bool flag = false;
                for (int i = 0; i < processNum; i++)
                {
                    if (finished[i] == false)
                    {
                        int j;
                        for (j = 0; j < resourceNum; j++)
                        {
                            if (need[i][j] > avail[j])
                                break;

                        }
                        if (j == resourceNum)
                        {

                            count++;
                            flag = true;
                            finished[i] = true;

                            for (j = 0; j < resourceNum; j++)
                            {
                                avail[j] = avail[j] + alloc[i][j];
                            }
                        }
                    }
                }
                if (flag == false)
                    break;

            }

            return (count < processNum ? false : true);



        }
        public static List<List<int>> intiateReq(int index, List<int> reqvec)
        {
            List<List<int>> redyReq = new List<List<int>>();
            int n = RSRC.MAN.Process.Processes.Count();
            int m = reqvec.Count();
            for (int i = 0; i < n; i++)
            {
                redyReq.Add(new List<int>());
                if (i == index)
                {
                    for (int j = 0; j < m; j++)
                    {
                        redyReq[i].Add(reqvec[j]);
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        redyReq[i].Add(0);
                    }
                }


            }
            return redyReq;
        }
    }
}