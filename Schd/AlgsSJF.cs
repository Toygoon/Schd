using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Schd
{
    class AlgsSJF
    {
        private static int findNextExec(List<Process> jobList, int clock)
        {
            int next = 0;

            for (int i = 0; i < jobList.Count; i++)
            {
                if (jobList[i].arriveTime <= clock)
                {
                    if (jobList[next].burstTime > jobList[i].burstTime)
                        next = i;
                }
            }

            return next;
        }

        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int clock = 0;

            // Sort with; arriveTime, and burstTime
            jobList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else
                {
                    return x.burstTime.CompareTo(y.burstTime);
                }
            });

            resultList.Add(new Result(jobList[0].processID, 0, jobList[0].burstTime, 0));
            clock = jobList[0].arriveTime + jobList[0].burstTime;
            jobList.RemoveAt(0);

            while (jobList.Count != 0)
            {
                int next = findNextExec(jobList, clock);
                Process exec = jobList[next];
                resultList.Add(new Result(exec.processID, clock, exec.burstTime, clock - exec.arriveTime));
                clock += exec.burstTime;
                jobList.RemoveAt(next);
            }

            return resultList;
        }
    }
}