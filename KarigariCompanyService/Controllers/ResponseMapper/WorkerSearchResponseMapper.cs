using Models;
using System;
using System.Collections.Generic;
using Utility;

namespace KarigariCompanyService.Controllers.ResponseMapper
{
    public static class WorkerSearchResponseMapper
    {
        public static ApiListResponse<IEnumerable<WorkerSearch>> SearchByJobTypeResponse(this IEnumerable<WorkerSearch> searchResult)
        {
            if (searchResult != null)
            {
                return new ApiListResponse<IEnumerable<WorkerSearch>>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    Data = searchResult,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiListResponse<IEnumerable<WorkerSearch>>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = false,
                    Data = null,
                    StatusCode = 400
                };
            }
        }

        public static ApiListResponse<IEnumerable<WorkerSearch>> CacheSearchListExceptionResponse(this Exception ex)
        {
            return new ApiListResponse<IEnumerable<WorkerSearch>>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }

    }
}
