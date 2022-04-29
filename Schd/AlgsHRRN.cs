using System.Collections.Generic;
using System.Linq;

namespace Schd
{
    class AlgsHRRN
    {
        public static double calcHRRN(int burstTime, int waitingTime)
        {
            return (waitingTime + burstTime) / (double)burstTime;
        }

        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            resultList = new List<Result>();

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

            // waitingTime; <processID, waitingTime>
            Dictionary<int, int> waitingTime = new Dictionary<int, int>();
            Dictionary<int, double> HRRN;

            for (int i = 0; i < jobList.Count; i++)
                waitingTime.Add(jobList[i].processID, 0);

            Process exec = jobList[0];
            int clock = exec.arriveTime, burstTime = 0;

            while (jobList.Count != 0)
            {
                for (int i = 0; i < jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock && exec.processID != jobList[i].processID)
                        waitingTime[jobList[i].processID]++;

                clock++;
                burstTime++;
                exec.burstTime--;

                if (exec.burstTime <= 0)
                {
                    resultList.Add(new Result(exec.processID, clock - burstTime, burstTime, waitingTime[exec.processID]));
                    jobList.RemoveAt(jobList.IndexOf(jobList.Find(x => x.processID == exec.processID)));

                    if (jobList.Count == 0)
                        break;

                    burstTime = 0;
                    HRRN = new Dictionary<int, double>();

                    for (int i = 0; i < jobList.Count; i++)
                        if (jobList[i].arriveTime <= clock)
                            HRRN.Add(jobList[i].processID, calcHRRN(jobList[i].burstTime, waitingTime[jobList[i].processID]));

                    var min = HRRN.OrderBy(x => x.Value).Last();
                    exec = jobList.Find(x => x.processID == min.Key);
                }
            }
            return resultList;
        }
    }
}
