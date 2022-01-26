﻿using Models;
using System;
using System.Collections.Generic;
using Utility;

namespace KarigariCompanyService.Controllers.ResponseMapper
{
    public static class JobPostResponseMapper
    {
        public static ApiResponse<JobPost> GetjobPostByIdResponce(this JobPost jobPost)
        {
            if (jobPost == null)
            {
                return new ApiResponse<JobPost>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<JobPost>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    Data = jobPost,
                    StatusCode = 200
                };
            }
        }

        public static ApiListResponse<IEnumerable<JobPost>> GetjobPostResponce(this IEnumerable<JobPost> jobPosts)
        {
            if (jobPosts == null)
            {
                return new ApiListResponse<IEnumerable<JobPost>>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiListResponse<IEnumerable<JobPost>>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    Data = jobPosts,
                    StatusCode = 200
                };
            }
        }


        public static ApiResponse<JobPost> CreateJobPostResponse(this JobPost jobPost)
        {
            if (jobPost != null)
            {
                return new ApiResponse<JobPost>
                {
                    Message = string.Format(Messages.CreateSucess, jobPost.Id + " " + jobPost.JobTypeID),
                    IsSuccess = false,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<JobPost>
                {
                    Message = string.Format(Messages.CreateFail, jobPost.Id + " " + jobPost.JobTypeID),
                    IsSuccess = true,
                    StatusCode = 400
                };
            }
        }
      
        public static ApiResponse<JobPost> CacheJobPostExceptionResponse(this Exception ex)
        {
            return new ApiResponse<JobPost>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }

        public static ApiListResponse<IEnumerable<JobPost>> CacheListExceptionResponse(this Exception ex)
        {
            return new ApiListResponse<IEnumerable<JobPost>>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }
    }
}
