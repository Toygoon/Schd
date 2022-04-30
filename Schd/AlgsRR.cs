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
            ReadyQueueElement exec = null;

            while (jobList.Count != 0)
            {
                // Checking for appropriate target processes existance
                for (int i=0; i<jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock && (readyQueue.Find(x => x.processID == jobList[i].processID) == null))
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                if (readyQueue.Count != 0)
                {
                    exec = readyQueue[0];
                    clock++;
                    timeBursted++;
                    exec.burstTime--;

                    for(int i=0; i<readyQueue.Count; i++)
                    {
                        if (readyQueue[i].processID != exec.processID)
                            readyQueue[i].waitingTime++;
                    }

                    if (exec.burstTime == 0 || timeBursted == tq)
                    {
                        Process tmp = jobList.Find(x => x.processID == exec.processID);

                        readyQueue.Remove(exec);
                        tmp.burstTime = exec.burstTime;

                        if (exec.burstTime == 0)
                            jobList.Remove(tmp);
                        else
                            readyQueue.Add(exec);
                        
                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, exec.waitingTime));
                        timeBursted = 0;
                    }
                } else
                {
                    // There's no process to execute
                    clock++;
                    continue;
                }
            }

            /*
            int clock = 0, timeBursted = 0;
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();

            // Any process done for execution will be removed from jobList
            // Starting the CPU
            while (jobList.Count != 0)
            {
                // Checking for appropriate target processes existance
                for (int i = 0; i < jobList.Count; i++)
                    if (jobList[i].arriveTime <= clock && readyQueue.Find(x => x.processID == jobList[i].processID) == null)
                        readyQueue.Add(new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                Debug.WriteLine("clock " + clock + ", readyQueueElements " + readyQueue.Count);

                // There's no process to execute
                if (readyQueue.Count == 0)
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
                    Debug.WriteLine("clock " + clock + ", readyQueueElements " + readyQueue.Count + ", current " + exec.processID);

                    for (int i = 0; i<jobList.Count; i++)
                        if (jobList[i].processID != exec.processID
                            && readyQueue.Find(x => x.processID == exec.processID) == null
                            && jobList[i].arriveTime <= clock)
                            readyQueue.Insert(0, new ReadyQueueElement(jobList[i].processID, jobList[i].burstTime, 0));

                    Debug.WriteLine("clock " + clock + ", readyQueueElements " + readyQueue.Count);

                    for (int i = 0; i<readyQueue.Count; i++)
                    {
                        Debug.WriteLine("readyQueue " + readyQueue[i].processID + ", exec " + exec.processID);
                        if (exec.processID != readyQueue[i].processID)
                            readyQueue[i].waitingTime++;
                    }

                    for(int i=0; i<readyQueue.Count; i++)
                    {
                        Debug.WriteLine("pid " + readyQueue[i].processID + ", wait " + readyQueue[i].waitingTime);
                    }

                    // Time slice expired or process done
                    if (timeBursted == tq || exec.burstTime == 0)
                    {
                        Process tmp = jobList.Find(x => x.processID == exec.processID);
                        jobList.Remove(tmp);
                        readyQueue.Remove(exec);
                        tmp.burstTime = exec.burstTime;
                        resultList.Add(new Result(exec.processID, clock - timeBursted, timeBursted, exec.waitingTime));

                        if (readyQueue.Count != 0)
                        {
                            exec = readyQueue[0];
                            cur = 0;
                        }

                        if (!(exec.burstTime == 0))
                            jobList.Add(tmp);

                        timeBursted = 0;
                    }
                }

                List<int> doneProcess = new List<int>();
                for (int i = 0; i<jobList.Count; i++)
                    if (jobList[i].burstTime == 0)
                        doneProcess.Add(jobList[i].processID);

                while (doneProcess.Count != 0)
                {
                    jobList.Remove(jobList.Find(x => x.processID == doneProcess[0]));
                    doneProcess.RemoveAt(0);
                }
            }
            */


            return resultList;
        }
    }
}
