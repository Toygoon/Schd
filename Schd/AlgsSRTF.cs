using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schd
{
    class AlgsSRTF
    {
        public static int needsPreempt(List<Process> jobList, int clock, int jobIndex)
        {
            int preempt = -1;

            for (int i = 0; i < jobList.Count; i++)
            {
                if (jobList[i].arriveTime <= clock && jobList[i].burstTime < jobList[jobIndex].burstTime)
                {
                    preempt = i;
                }
            }

            return preempt;
        }

        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            int clock = 0, jobIndex = 0, readyIndex = 0, preempt = -1, burstTime = 0;

            bool isDone = false;
            List<int> completed = new List<int>();

            // Sort with; arriveTime, and burstTime
            jobList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else return x.burstTime.CompareTo(y.burstTime);
            });

            for (int i = 0; i < jobList.Count; i++)
                readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

            Process exec = jobList[0];

            while (isDone == false)
            {
                jobIndex = jobList.IndexOf(jobList.Find(item => item.processID == exec.processID));
                readyIndex = readyQueue.IndexOf(readyQueue.Find(item => item.processID == exec.processID));

                readyQueue[readyIndex].burstTime--;
                clock++;
                burstTime++;

                if (readyQueue[readyIndex].burstTime == 0)
                {
                    readyQueue.RemoveAt(readyIndex);
                    jobList.RemoveAt(jobIndex);
                    completed.Add(jobIndex);
                }

                preempt = needsPreempt(jobList, clock, jobIndex);
                if (preempt != -1)
                {
                    exec = jobList[preempt];
                    resultList.Add(new Result(exec.processID, clock, burstTime, 0));
                }
            }

            return resultList;
        }
    }
}
