using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();

            // The process executing current is saved to 'exec'
            ReadyQueueElement exec = null;

            while (jobList.Count != 0)
            {
                // Checking for appropriate target processes
                for (int i = 0; i<jobList.Count; i++)
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

                    // Increase the waiting time of processes which is not executing for now
                    for (int i = 0; i<readyQueue.Count; i++)
                    {
                        if (readyQueue[i].processID != exec.processID)
                            readyQueue[i].waitingTime++;
                    }

                    // Time quantum expired, or burst time ended
                    if (exec.burstTime == 0 || timeBursted == tq)
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
