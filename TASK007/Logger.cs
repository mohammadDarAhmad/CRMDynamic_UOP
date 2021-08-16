using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK007
{ 
    public class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void PrintLog(string text)
        {
            log.Error(text);
        }
        public void PrintInfo(string text)
        {
            log.Info(text);
        }
    }
}
