using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK007.SystemContstant
{
    public enum ContactStatus
    {
        InProgress = 1,
        OnHold = 2,
        WaitingForDetails = 3,
        Researching = 4,
        ProblemSolved = 5,
        Canceled = 6

    }
    public enum IncidentResolutionStatus
    {
        Open = 1,
        Completed = 2,
        Canceled = 3
    }
}
