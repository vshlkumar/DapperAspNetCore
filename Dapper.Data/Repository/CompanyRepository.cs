using Dapper.Data.Interface;
using Dapper.Domain.Dto;

namespace Dapper.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public List<Company> GetCompany()
        {
            using (var db = _context.CreateConnection())
            {
                string query = "Select * from Company";
                return db.Query<Company>(query).ToList();
            }
        }

        public void AddCompany(Company company)
        {
            using (var db = _context.CreateConnection())
            {  
                string query = "Insert into Company(Name,IsActive,Id) values (@Name, @IsActive, @Id)";
                db.Execute(query, company);                
            }            
        }

        public void UpdateCompany(Company company)
        {
            using (var db = _context.CreateConnection())
            {
                string query = "Update Company set Name = @Name , IsActive = @IsActive Where Id = @Id";
                db.Execute(query, company);
            }
        }

        public void DeleteCompany(string name)
        {
            using (var db = _context.CreateConnection())
            {
                db.Open();
                string query = "Delete Company Where Name = @name";
                db.ExecuteScalar(query, new { Name = name });
            }
        }
    }
}
