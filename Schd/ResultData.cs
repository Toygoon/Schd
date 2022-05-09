using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schd
{
    class ResultData
    {
        public string algsType;
        public List<Result> resultList;
        public Dictionary<int, int> waitingTimeList;
        public int totalExecTime;
        public double avgWaitingTime;
        public int timeQuantum;
    }

}
