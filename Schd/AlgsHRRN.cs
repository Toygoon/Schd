using System.Collections.Generic;
using System.Linq;

namespace Schd
{
    /// <summary>
    /// Highest Response Ratio Next Algorithm Simulation
    /// By Lim Jung Min (Advanced Computer Systems Laboratory, Yeungnam University)
    /// </summary>
    class AlgsHRRN
    {
        /// <summary>
        /// calcHRRN function calculates and returns the priority;
        /// (waiting time + estimated run time) / estimated run time
        /// </summary>
        /// <param name="burstTime">Burst time of current process</param>
        /// <param name="waitingTime">Waiting time of current process</param>
        /// <returns>Calculated priority</returns>
        public static double calcHRRN(int burstTime, int waitingTime)
        {
            return (waitingTime + burstTime) / (double)burstTime;
        }

        /// <summary>
        /// Run function makes the results for executing processes with HRRN algorithm to the list
        /// </summary>
        /// <param name="jobList">Job queue of processes</param>
        /// <param name="resultList">The result list to be filled</param>
        /// <returns>Filled the results with executed summary in result list</returns>
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            // Initialize the result list
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

            int clock = 0, timeBursted = 0;

            Dictionary<int, double> ratio;
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();

            // Any process done for execution will be removed from jobList
            // Starting the CPU
            while (jobList.Count != 0)
            {
                // Find out the process which should be inserted to the ready queue
                for (int i = 0; i<jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock && readyQueue.Find(x => x.processID == jobList[i].processID) == null)
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                // The index of ready queue to be executed now
                int next = 0;

                if (readyQueue.Count != 0)
                {
                    // Determine which process should be executed for the next.
                    for (int i = 0; i<readyQueue.Count; i++)
                        if (readyQueue[i].burstTime < readyQueue[next].burstTime)
                            next = i;
                }
                else
                {
                    // No process to execute, just increase the clock (idle state)
                    clock++;
                    continue;
                }

                // exec is the process to be executed
                ReadyQueueElement exec = readyQueue[next];
                while (true)
                {
                    // Insert the new process to the ready queue
                    for (int i = 0; i<jobList.Count; i++)
                        if (jobList[i].arriveTime <= clock && readyQueue.Find(x => x.processID == jobList[i].processID) == null)
                            readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                    // If burst time is 0, current process is done for executing
                    if (exec.burstTime == 0)
                    {
                        // Add to the resultList
                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, exec.waitingTime));

                        // Remove from the job queue, and the ready queue
                        jobList.Remove(jobList.Find(x => x.processID == exec.processID));
                        readyQueue.RemoveAt(next);

                        break;
                    }

                    // Execute the process
                    clock++;
                    exec.burstTime--;
                    timeBursted++;

                    // Increase waiting time except current process in the ready queue
                    for (int i = 0; i<readyQueue.Count; i++)
                        if (next != i)
                            readyQueue[i].waitingTime++;
                }

                // Current process is done, so reset the bursted time
                timeBursted = 0;
            }

            /*
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
            */

            return resultList;
        }
    }
}
