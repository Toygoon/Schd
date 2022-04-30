using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schd
{
    /// <summary>
    /// Round Robin Algorithm Simulation
    /// By Lim Jung Min (Advanced Computer Systems Laboratory, Yeungnam University)
    /// </summary>
    class AlgsRR
    {
        /// <summary>
        /// Run function makes the results for executing processes with RR algorithm to the list
        /// </summary>
        /// <param name="jobList">Job queue of processes</param>
        /// <param name="resultList">The result list to be filled</param>
        /// <returns>Filled the results with executed summary in result list</returns>
        public static List<Result> Run(List<Process> jobList, List<Result> resultList, int tq)
        {
            // Initialize the result list
            resultList = new List<Result>();

            int clock = 0, timeBursted = 0;
            bool checkExec;

            List<ReadyQueueElement> readyQueue;


            // Any process done for execution will be removed from jobList
            // Starting the CPU
            while (jobList.Count != 0)
            {
                readyQueue = new List<ReadyQueueElement>();
                checkExec = false;

                // Checking for appropriate target processes existance
                for (int i = 0; i < jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock)
                    {
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));
                        checkExec = true;
                        break;
                    }

                // There's no process to execute
                if (checkExec == false)
                {
                    clock++;
                    continue;
                }

                ReadyQueueElement exec = null;
                int cur = 0;

                while (readyQueue.Count != 0)
                {
                    exec = readyQueue[cur];

                    clock++;
                    timeBursted++;
                    exec.burstTime--;

                    for (int i = 0; i<readyQueue.Count; i++)
                        if (exec.processID != readyQueue[i].processID)
                            readyQueue[i].waitingTime++;

                    if (timeBursted == tq || exec.burstTime == 0)
                    {
                        // Todo; migrate readyqueue to joblist, add to resultlist
                        Process tmp = jobList.Find(x => x.processID == exec.processID);
                        readyQueue.Remove(exec);
                        tmp.burstTime = exec.burstTime;
                    }
                }
            }

            return resultList;
        }
    }
}
