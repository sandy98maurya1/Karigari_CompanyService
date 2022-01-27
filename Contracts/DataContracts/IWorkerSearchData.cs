using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IWorkerSearchData
    {
        IEnumerable<WorkerSearch> GetWorkerByJobType(int JobType);
        IEnumerable<WorkerSearch> GetWorkerByLocation(int JobType, int Location);
    }
}
