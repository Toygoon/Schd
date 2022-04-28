using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schd
{
    class AlgsSRTF
    {
        public static int findNext(List<ProcessExt> processExt, int clock, int curExec)
        {
            if (processExt[curExec].burstTime <= 0)
                processExt[curExec].isDone = true;


            return curExec;
        }

        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            // Sort with; arriveTime, and burstTime
            jobList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else return x.burstTime.CompareTo(y.burstTime);
            });

            int clock = 0, x = 0;
            List<ProcessExt> processExt = new List<ProcessExt>();

            for (int i = 0; i < jobList.Count; i++)
                processExt.Add(new ProcessExt(jobList[i].processID,
                    jobList[i].arriveTime,
                    jobList[i].burstTime,
                    jobList[i].priority,
                    jobList[i].burstTime,
                    0,
                    false));

            ProcessExt exec = processExt[0];

            while (processExt.Count != 0)
            {
                clock++;
                processExt[x].burstTime--;

            }

            return resultList;
        }
    }
}
