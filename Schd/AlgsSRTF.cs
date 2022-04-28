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
            List<Tuple<int, int>> waitingTime = new List<Tuple<int, int>>();

            for(int i=0; i<jobList.Count; i++)
                waitingTime.Add(new Tuple<int, int>(jobList[i].processID, 0));

            while (jobList.Count != 0)
            {
                pid = exec.processID;
                idx = jobList.IndexOf(exec);

                for (int i = 0; i < jobList.Count; i++)
                    if (jobList[i].processID != pid && jobList[i].arriveTime <= clock)
                        for(int j=0; j<waitingTime.Count; j++)
                            if (waitingTime[j].Item1 == jobList[i].processID)
                                waitingTime[j] = new Tuple<int, int>(jobList[i].processID, waitingTime[j].Item2 + 1);

                clock++;
                exec.burstTime--;
                timeBursted++;

                if (exec.burstTime <= 0)
                {
                    jobList.Remove(exec);

                    if (jobList.Count == 0)
                    {
                        int tmp = 0;
                        for (int i = 0; i < waitingTime.Count; i++)
                            if (waitingTime[i].Item1 == beforepid)
                            {
                                tmp = i;
                                break;
                            }

                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, waitingTime[tmp].Item2));
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
                    int tmp = 0;
                    for (int i = 0; i < waitingTime.Count; i++)
                        if (waitingTime[i].Item1 == beforepid)
                        {
                            tmp = i;
                            break;
                        }

                    resultList.Add(new Result(beforepid, clock - timeBursted, timeBursted, waitingTime[tmp].Item2));
                    waitingTime[tmp] = new Tuple<int, int>(beforepid, 0);
                    timeBursted = 0;
                    beforepid = pid;
                }
            }

            return resultList;
        }
    }
}
