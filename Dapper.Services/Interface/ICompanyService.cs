using Dapper.Domain.Dto;

namespace Dapper.Services.Interface
{
    public interface ICompanyService
    {
        List<Company> GetCompany();

        Company AddCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(string name);
    }
}
