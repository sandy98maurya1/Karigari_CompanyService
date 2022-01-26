using Contracts.DataContracts;
using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WorkerSearchData : IWorkerSearchData
    {
        IConfiguration _configuration;
        internal string connection { get; set; }
        public object MapResults { get; private set; }

        public WorkerSearchData(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = GetConnection();
        }

        public IEnumerable<WorkerSearch> GetWorkerByJobType(string JobType)
        {
            IEnumerable<WorkerSearch> result;

            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @""; //TODO : 
                    result = (IEnumerable<WorkerSearch>)dbConnection.Query<IEnumerable<WorkerSearch>>(query, new { @JobType = JobType }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return result;
            }
        }

        public IEnumerable<WorkerSearch> GetWorkerByLocation(string JobType, string Location)
        {
            IEnumerable<WorkerSearch> result;

            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @""; //TODO : 
                    result = (IEnumerable<WorkerSearch>)dbConnection.Query<IEnumerable<WorkerSearch>>(query, new { @JobType = JobType, @Location = Location }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return result;
            }
        }

        public string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }
    }
}
