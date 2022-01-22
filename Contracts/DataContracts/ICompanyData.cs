using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface ICompanyData
    {
        Company GetCompanyByName(string companyName);
        Company GetCompanyById(int Id);
        IEnumerable<Company> GetCompanies();
        bool CreateCompany(Company company);
        Company UpdateCompany(Company company);
        bool DeleteCompany(int Id);
        bool DisableCompany(int Id);
    }
}
