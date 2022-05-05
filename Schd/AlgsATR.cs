using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Schd
{
    /// <summary>
    /// Average Time Quantum Round Algorithm Simulation
    /// ATQ algorithm produres;
    /// First, calculate the average of the burst time for all processes
    /// Second, execute the process within time quantum
    /// Third, if the new process arrives, recalculate the time quantum
    /// Fourth, if the re-calculated time quantum is bigger than current burst time, preempt current process and execute another process
    /// Algorithm author : Lim Jung Min (Advanced Computer Systems Laboratory, Yeungnam University)
    /// </summary>
    class AlgsATR
    {
        private static int getAverage(List<ReadyQueueElement> readyQueue, int clock)
        {
            int tq = 0;

            for(int i=0; i<readyQueue.Count; i++)
                tq += readyQueue[i].burstTime;

            return tq / readyQueue.Count;
        }

        /// <summary>
        /// Run function makes the results for executing processes with RR algorithm to the list
        /// </summary>
        /// <param name="jobList">Job queue of processes</param>
        /// <param name="resultList">The result list to be filled</param>
        /// <returns>Filled the results with executed summary in result list</returns>
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            // Initialize the result list
            resultList = new List<Result>();

            int clock = 0, timeBursted = 0;
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            int tq = -1;

            // The process executing current is saved to 'exec'
            ReadyQueueElement exec = null;

            while (jobList.Count != 0)
            {
                // Checking for appropriate target processes
                for (int i = 0; i < jobList.Count; i++)
                    // Add to the ready queue, Condition; The process has already arrived, and not exists in the ready queue
                    if (jobList[i].arriveTime <= clock && (readyQueue.Find(x => x.processID == jobList[i].processID) == null))
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                // Execute the process
                if (readyQueue.Count != 0)
                {
                    // Execute the process
                    exec = readyQueue[0];
                    clock++;
                    timeBursted++;
                    exec.burstTime--;

                    // Insert the new process to the ready queue
                    for (int i = 0; i < jobList.Count; i++)
                        if (jobList[i].arriveTime <= clock
                            && readyQueue.Find(x => x.processID == jobList[i].processID) == null
                            && jobList[i].processID != exec.processID)
                            readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                    // Increase the waiting time of processes which is not executing for now
                    for (int i = 0; i < readyQueue.Count; i++)
                    {
                        if (readyQueue[i].processID != exec.processID)
                            readyQueue[i].waitingTime++;
                    }

                    // Recalculate the time quantum
                    tq = getAverage(readyQueue, clock);
                    if (tq == 0)
                        tq = 1;
                    Debug.WriteLine("clock " + clock + ", tq : " + tq);

                    // Time quantum expired, or burst time ended
                    if (exec.burstTime == 0 || timeBursted >= tq)
                    {
                        // Find out from the job queue
                        Process tmp = jobList.Find(x => x.processID == exec.processID);

                        // Remove from the ready queue, and change of the its burst time
                        readyQueue.Remove(exec);
                        tmp.burstTime = exec.burstTime;

                        // Remove the job queue when burst time has done
                        if (exec.burstTime == 0)
                            jobList.Remove(tmp);
                        // or turn it back to the ready queue
                        else
                            readyQueue.Add(exec);

                        // Add to the result list
                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, exec.waitingTime));
                        // Reset some values
                        exec.waitingTime = 0;
                        timeBursted = 0;
                    }
                }
                else
                {
                    // There's no process to execute
                    clock++;
                    continue;
                }
            }

            return resultList;
        }
    }
}
