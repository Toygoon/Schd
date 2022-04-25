using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Schd
{
    class ReadyQueueElement
    {
        public int processID;
        public int burstTime;
        public int waitingTime;

        public ReadyQueueElement(int processID, int burstTime, int waitingTime)
        {
            this.processID = processID;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
        }
    }
}
