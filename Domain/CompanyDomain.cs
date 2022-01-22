using Contracts;
using Contracts.DataContracts;
using Models;
using System.Collections.Generic;

namespace Domain
{
    public class CompanyDomain : ICompany
    {
        private readonly ICompanyData companyData;
        public CompanyDomain(ICompanyData _company)
        {
            companyData = _company;
        }
        public bool CreateCompany(Company company)
        {
            return companyData.CreateCompany(company);
        }

        public bool DeleteCompany(int Id)
        {
            return companyData.DeleteCompany(Id);
        }

        public bool DisableCompany(int Id)
        {
            return companyData.DisableCompany(Id);

        }

        public IEnumerable<Company> GetCompanies()
        {
            return companyData.GetCompanies();
        }

        public Company GetCompanyById(int Id)
        {
            return companyData.GetCompanyById(Id);
        }

        public Company GetCompanyByName(string companyName)
        {
            return companyData.GetCompanyByName(companyName);
        }

        public Company UpdateCompany(Company company)
        {
            return companyData.UpdateCompany(company);
        }
    }
}
