using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Schd
{
    class AlgsFCFS
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            resultList = new List<Result>();

            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;

            int runTime = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    Debug.WriteLine("frontJob : " + jobList.ElementAt(0).processID);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0));
                        Debug.WriteLine("frontJob added to ready queue");
                        jobList.RemoveAt(0);
                        Debug.WriteLine("frontJob has removed from jobList");
                    }
                    else
                    {
                        Debug.WriteLine("frontJob - else break");
                        break;
                    }
                }

                if (currentProcess == 0)
                {
                    Debug.WriteLine("currentProcess is 0");
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);
                        Debug.WriteLine("Ready queue element : " + rq.processID);
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                        Debug.WriteLine("Add to resultList; PID " + rq.processID + ", runTime "
                            + runTime + ", bustTime " + rq.burstTime + ", waitingTime " + rq.waitingTime);
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);
                        Debug.WriteLine("cpuDone " + cpuDone + ", Removed process from readyQueue : " + rq.processID);
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        Debug.WriteLine("cpuTime : " + cpuTime + ", cpuDone : " + cpuDone);
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                Debug.WriteLine("cpuTime : " + cpuTime + ", runTime : " + runTime);
                for (int i = 0; i < readyQueue.Count; i++)
                {
                    readyQueue.ElementAt(i).waitingTime++;
                    Debug.WriteLine("PID " + readyQueue.ElementAt(i).processID + "'s waitingTime : " + readyQueue.ElementAt(i).waitingTime);
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
}