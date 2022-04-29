using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schd
{
    class AlgsRR
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList, int tq)
        {
            Process exec = jobList[0];

            int clock = exec.arriveTime, timeBursted = 0;

            while (jobList.Count != 0)
            {
                if (timeBursted == 3)
                {

                } else
                {

                }
            }
            /*
            int j = 0;
            resultList = new List<Result>();

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            List<int> completedJobs = new List<int>();

            int clock = 0;

            while (jobList.Count != 0)
            {
                for (int i = 0; i<jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock)
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                for (int i = 0; i<readyQueue.Count; i++)
                {
                    for (j = 0; j<tq; j++)
                    {
                        for (int k = 0; k<readyQueue.Count; k++)
                            if (i != k)
                                readyQueue[k].waitingTime++;

                        clock++;
                        readyQueue[i].burstTime--;

                        if (readyQueue[i].burstTime == 0)
                        {
                            completedJobs.Add(readyQueue[i].processID);
                            break;
                        }
                    }

                    Process tmp = jobList.Find(x => x.processID == readyQueue[i].processID);
                    tmp.burstTime = readyQueue[i].burstTime;

                    j++;
                    resultList.Add(new Result(readyQueue[i].processID, clock - j, j, readyQueue[i].waitingTime));
                }
            }

            */

            /*
            while (jobList.Count != 0)
            {
                readyQueue = new List<ReadyQueueElement>();

                for (int i = 0; i<jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock)
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                for (int i = 0; i<readyQueue.Count; i++)
                    Debug.WriteLine("pid " + readyQueue[i].processID);

                for (int i = 0; i<readyQueue.Count; i++)
                {
                    for (int j = tq; j > 0; j--)
                    {
                        readyQueue[i].burstTime--;
                        clock++;

                        if (readyQueue[i].burstTime == 0)
                        {
                            resultList.Add(new Result(readyQueue[i].processID, clock - timeBursted, timeBursted, readyQueue[i].waitingTime));
                            break;
                        }
                    }
                }

                for (int i = 0; i<readyQueue.Count; i++)
                {
                    Process tmp = jobList.Find(x => x.processID == readyQueue[i].processID);

                    if (readyQueue[i].burstTime == 0)
                        jobList.Remove(exec);
                    else
                        tmp.burstTime = readyQueue[i].burstTime;
                }

            }
            */

            return resultList;
        }
    }
}
