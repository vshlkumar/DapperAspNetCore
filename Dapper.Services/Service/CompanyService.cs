using Dapper.Data.Interface;
using Dapper.Domain.Dto;
using Dapper.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Services.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository= companyRepository;
        }

        public List<Company> GetCompany()
        {
            var company = _companyRepository.GetCompany();
            return company;
        }

        public Company AddCompany(Company company)
        {
            _companyRepository.AddCompany(company);
            return company;
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }    

        public void DeleteCompany(string name)
        {
            _companyRepository.DeleteCompany(name);
        }
    }
}
