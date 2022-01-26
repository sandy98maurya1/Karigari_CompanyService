﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IWorkerSearch
    {
        IEnumerable<WorkerSearch> GetWorkerByJobType(string JobType);
        IEnumerable<WorkerSearch> GetWorkerByLocation(string JobType, string Location);
    }
}
