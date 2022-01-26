﻿using Models;
using System;
using System.Collections.Generic;
using Utility;

namespace KarigariCompanyService.Controllers.ResponseMapper
{
    public static class CompanyResponseMapper
    {
        public static ApiResponse<bool> CreateCompanyResponse(this bool status)
        {
            if (status)
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.CreateFail, "Company"),
                    IsSuccess = false,
                    StatusCode = 400
                };
            }
        }

        public static ApiResponse<bool> UpdateCompanyResponse(this bool status)
        {

            return new ApiResponse<bool>
            {
                Message = string.Format(Messages.Success),
                IsSuccess = true,
                StatusCode = 200
            };


        }

        public static ApiResponse<bool> DeleteCompanyResponse(this bool status)
        {
            if (status)
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.DeleteSucess),
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.DeleteFail, "Company"),
                    IsSuccess = false,
                    StatusCode = 400
                };
            }
        }

        public static ApiResponse<bool> DisableCompanyResponse(this bool status)
        {
            if (status)
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.DisableSucess),
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<bool>
                {
                    Message = string.Format(Messages.DisableFail, "Company"),
                    IsSuccess = false,
                    StatusCode = 400
                };
            }
        }

        public static ApiListResponse<IEnumerable<Company>> GetCompaniesResponse(this IEnumerable<Company> companies)
        {
            if (companies != null)
            {
                return new ApiListResponse<IEnumerable<Company>>
                {
                    Message = string.Format("Companie(s) found"),
                    IsSuccess = true,
                    Data = companies,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiListResponse<IEnumerable<Company>>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 400
                };
            }
        }

        public static ApiResponse<Company> GetCompanyByNameResponse(this Company company)
        {
            if (company != null)
            {
                return new ApiResponse<Company>
                {
                    Message = string.Format("Company found"),
                    IsSuccess = true,
                    Data = company,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<Company>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 400
                };
            }
        }

        public static ApiResponse<Company> GetCompanyByIdResponse(this Company company)
        {
            if (company != null)
            {
                return new ApiResponse<Company>
                {
                    Message = string.Format("Company found"),
                    IsSuccess = true,
                    Data = company,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<Company>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 400
                };
            }
        }

        public static ApiResponse<bool> CacheExceptionResponse(this Exception ex)
        {
            return new ApiResponse<bool>
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }

        public static ApiResponse<Company> CacheCompanyExceptionResponse(this Exception ex)
        {
            return new ApiResponse<Company>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }

        public static ApiListResponse<IEnumerable<Company>> CacheListCompanyExceptionResponse(this Exception ex)
        {
            return new ApiListResponse<IEnumerable<Company>>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }
    }
}
