using Contracts.DataContracts;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class CompanyData : ICompanyData
    {
        public bool CreateCompany(Company company)
        {
            using(IDbConnection cnn = new SqlConnection(ApplicationDbContext.GetConnectionString()))
            {
                string sql = "Insert INTO KarigariCompany";
            }
            throw new System.NotImplementedException();
        }

        public bool DeleteCompany(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool DisableCompany(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Company> GetCompanies()
        {
            throw new System.NotImplementedException();
        }

        public Company GetCompanyById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Company GetCompanyByName(string companyName)
        {
            throw new System.NotImplementedException();
        }

        public Company UpdateCompany(Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}
