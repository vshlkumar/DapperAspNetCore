using Dapper.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Data.Interface
{
    public interface ICompanyRepository
    {
        List<Company> GetCompany();
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(string name);
    }
}
