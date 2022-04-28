using System.Collections.Generic;

namespace Schd
{
    class AlgsSRTF
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            // Sort with; arriveTime, and burstTime
            jobList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else return x.burstTime.CompareTo(y.burstTime);
            });

            Process exec = jobList[0];
            int clock = 0, idx = 0, pid = 0, timeBursted = 0, beforepid = exec.processID;
            Dictionary<int, int> waitingTime = new Dictionary<int, int>();

            for (int i = 0; i < jobList.Count; i++)
                waitingTime.Add(jobList[i].processID, 0);

            while (jobList.Count != 0)
            {
                pid = exec.processID;
                idx = jobList.IndexOf(exec);

                for (int i = 0; i < jobList.Count; i++)
                    if (jobList[i].processID != pid && jobList[i].arriveTime <= clock)
                        waitingTime[jobList[i].processID]++;

                clock++;
                exec.burstTime--;
                timeBursted++;

                if (exec.burstTime <= 0)
                {
                    jobList.Remove(exec);

                    if (jobList.Count == 0)
                    {
                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, waitingTime[exec.processID]));
                        break;
                    }

                    exec = jobList[0];
                    pid = exec.processID;
                    idx = 0;
                }

                for (int i = 0; i < jobList.Count; i++)
                {
                    if (jobList[i].arriveTime <= clock
                        && jobList[i].burstTime < jobList[idx].burstTime)
                    {
                        exec = jobList[i];
                        pid = exec.processID;
                        idx = i;
                    }
                }

                if (beforepid != pid)
                {
                    resultList.Add(new Result(beforepid, clock - timeBursted, timeBursted, waitingTime[beforepid]));
                    waitingTime[beforepid] = 0;
                    timeBursted = 0;
                    beforepid = pid;
                }
            }

            return resultList;
        }
    }
}
