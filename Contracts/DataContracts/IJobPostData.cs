﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IJobPostData
    {
        JobPost GetJobPostById(int Id, int CompanyId);
        IEnumerable<JobPost> GetJobPosts(int CompanyId);
        JobPost CreateJobPost(JobPost post);
        JobPost UpdateJobPost(JobPost post);
    }
}
