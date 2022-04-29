using System.Collections.Generic;

namespace Schd
{
    /// <summary>
    /// Shortest Job First Algorithm Simulation
    /// By Lim Jung Min (Advanced Computer Systems Laboratory, Yeungnam University)
    /// </summary>

    class AlgsSJF
    {
        /// <summary>
        /// findNextExec function determines which process should be executed for next.
        /// </summary>
        /// <param name="jobList">Job queue of processes</param>
        /// <param name="clock">Current CPU clock</param>
        /// <returns>The index of next process should be executed</returns>
        private static int findNextExec(List<Process> jobList, int clock)
        {
            int next = 0;

            /// Find the proper index of being executed
            /// Condition; The process is arrived before the current clock,
            /// and the burstTime is shorter than any other processes
            for (int i = 0; i < jobList.Count; i++)
                if (jobList[i].arriveTime <= clock && jobList[next].burstTime > jobList[i].burstTime)
                    next = i;

            return next;
        }

        /// <summary>
        /// Run function makes the result list of SJF algorithms.
        /// </summary>
        /// <param name="jobList">Job queue of processes</param>
        /// <param name="resultList">The result list to be filled</param>
        /// <returns>Filled the results with executed summary in result list</returns>
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            // Initialize the result list
            resultList = new List<Result>();

            int clock = 0;
            bool existsWaiting = false;

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

            /// Because jobList is sorted with arrival time, and burst time,
            /// There's no problem to execute the first process from jobList.
            resultList.Add(new Result(jobList[0].processID, jobList[0].arriveTime, jobList[0].burstTime, 0));
            // Move towards to ended time of the first process
            clock = jobList[0].arriveTime + jobList[0].burstTime;
            // First job has done with execution, remove the executed process from jobList
            jobList.RemoveAt(0);

            // Like the first process, any process done for execution will be removed from jobList
            while (jobList.Count != 0)
            {
                // Check out there are arrived processes first
                for (int i = 0; i<jobList.Count; i++)
                {
                    if (jobList[i].arriveTime <= clock)
                        break;
                    else
                        existsWaiting = true;
                }

                if (existsWaiting)
                {
                    clock++;
                    continue;
                }

                // Find out proper index of the process which will be executed for now
                int next = findNextExec(jobList, clock);
                // The process is selected for executing
                Process exec = jobList[next];

                // Execute process, and calculate the results
                resultList.Add(new Result(exec.processID, clock, exec.burstTime, clock - exec.arriveTime));
                // Move towards to ended time
                clock += exec.burstTime;
                // Because it has done with executing, remove from the job queue
                jobList.RemoveAt(next);

                existsWaiting = false;
            }

            return resultList;
        }
    }
}