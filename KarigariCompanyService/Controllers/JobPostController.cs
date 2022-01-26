using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using Company.Controllers.ResponseMapper;
using Utility.LoggerService;
using Utility;

namespace KarigariCompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private IJobPost _jobPost;
        private readonly ILoggerManager _logger;
        public JobPostController(IJobPost jobPost, ILoggerManager logger)
        {
            _jobPost = jobPost;
            _logger = logger;
        }

        [HttpGet, Route("/GetJobPostByUserId")]
        public IActionResult GetProfileByUserId(int postId, int companyId)
        {
            ApiResponse<JobPost> responce = new ApiResponse<JobPost>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _jobPost.GetJobPostById(postId,companyId).GetjobPostByIdResponce();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo(responce.Message);
            return Ok(responce);

        }

        [HttpGet, Route("/GetJobPosts")]
        public IActionResult GetJobPosts(int companyId)
        {
            ApiListResponse<IEnumerable<JobPost>> responce = new ApiListResponse<IEnumerable<JobPost>>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _jobPost.GetJobPosts(companyId).GetjobPostResponce();
            }
            catch (Exception ex)
            {
                responce = ex.CacheListExceptionResponse();
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo(responce.Message);
            return Ok(responce);

        }


        [HttpPost, Route("/CreateUserjobPost")]
        public IActionResult CreateUserjobPost(JobPost jobPost)
        {
            ApiResponse<JobPost> responce = new ApiResponse<JobPost>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _jobPost.CreateJobPost(jobPost).CreateJobPostResponse();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo(responce.Message);
            return Ok(responce);

        }

        [HttpPost, Route("/UpdateJobPost")]
        public IActionResult UpdateUserjobPost(JobPost jobPost)
        {
            ApiResponse<JobPost> responce = new ApiResponse<JobPost>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _jobPost.UpdateJobPost(jobPost).CreateJobPostResponse();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
                _logger.LogInfo(ex.Message);
            }
            _logger.LogInfo(responce.Message);
            return Ok(responce);

        }

        private ApiExposeResponse<Dictionary<string, string>> GetModelErrors()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    string errordetails = string.Empty;
                    foreach (var error in state.Value.Errors)
                    {
                        errordetails = errordetails + error.ErrorMessage;
                    }

                    errors.Add(state.Key.Contains(".") ? state.Key.Split('.')[1] : state.Key, errordetails);
                }
            }


            return new ApiExposeResponse<Dictionary<string, string>>
            {
                IsSuccess = false,
                Message = Messages.InValidInputMsg,
                Error = errors
            };
        }

    }
}
