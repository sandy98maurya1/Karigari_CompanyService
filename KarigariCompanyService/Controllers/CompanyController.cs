using Contracts;
using KarigariCompanyService.Controllers.ResponseMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using Utility;
using Utility.LoggerService;

namespace KarigariCompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany company;
        private readonly ILoggerManager logger;

        public CompanyController(ICompany _company, ILoggerManager _logger)
        {
            company = _company;
            logger = _logger;
        }

        [HttpPost,Route("/CreateCompany")]
        public IActionResult CreateCompany(Company model)
        {
            ApiResponse<bool> responce = new ApiResponse<bool>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.CreateCompany(model).CreateCompanyResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpPost, Route("/UpdateCompany")]
        public IActionResult UpdateCompany(Company model)
        {
            ApiResponse<Company> responce = new ApiResponse<Company>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.UpdateCompany(model).UpdateCompanyResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheCompanyExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpDelete, Route("/DeleteCompany")]
        public IActionResult DeleteCompany(int CompanyId)
        {
            ApiResponse<bool> responce = new ApiResponse<bool>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.DeleteCompany(CompanyId).DeleteCompanyResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpPost, Route("/DisableCompany")]
        public IActionResult DisableCompany(int CompanyId)
        {
            ApiResponse<bool> responce = new ApiResponse<bool>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.DisableCompany(CompanyId).DisableCompanyResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpGet, Route("/GetCompanyById")]
        public IActionResult GetCompanyById(int Id)
        {
            ApiResponse<Company> responce = new ApiResponse<Company>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.GetCompanyById(Id).GetCompanyByIdResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheCompanyExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpGet, Route("/GetCompanyByName")]
        public IActionResult GetCompanyByName(string Name)
        {
            ApiResponse<Company> responce = new ApiResponse<Company>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.GetCompanyByName(Name).GetCompanyByNameResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheCompanyExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
            return Ok(responce);
        }

        [HttpGet, Route("/GetCompanies")]
        public IActionResult GetCompanies()
        {
            ApiListResponse<IEnumerable<Company>> responce = new ApiListResponse<IEnumerable<Company>>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                var response = company.GetCompanies().GetCompaniesResponse();

            }
            catch (System.Exception ex)
            {
                responce = CompanyResponseMapper.CacheListCompanyExceptionResponse(ex);
                logger.LogInfo(ex.Message); ;
            }

            logger.LogInfo(responce.Message);
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
