using Contracts;
using Contracts.DataContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkerSearchDomain : IWorkerSearch
    {
        private readonly IWorkerSearchData _workerSearch;
        public WorkerSearchDomain(IWorkerSearchData workerSearch)
        {
            _workerSearch = workerSearch;
        }
        public IEnumerable<WorkerSearch> GetWorkerByJobType(string JobType)
        {
            return _workerSearch.GetWorkerByJobType(JobType);
        }

        public IEnumerable<WorkerSearch> GetWorkerByLocation(string JobType, string Location)
        {
            return _workerSearch.GetWorkerByLocation(JobType,Location);
        }
    }
}
