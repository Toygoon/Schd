﻿using System.Collections.Generic;
using System.Linq;

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
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0));
                        jobList.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
}