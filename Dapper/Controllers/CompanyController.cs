using Dapper.Domain.Dto;
using Dapper.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet("company")]
        [ProducesResponseType(typeof(Company), 200)]
        public IActionResult Get()
        {
            return Ok(_companyService.GetCompany());
        }

        [HttpPost("add")]       
        public IActionResult AddCompany(Company company)
        {
            return Ok(_companyService.AddCompany(company));
        }

        [HttpPut("update")]
        public IActionResult UpdateCompany(Company company)
        {
            _companyService.UpdateCompany(company);
            return Ok("Updated");
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteCompany(string name)
        {
            _companyService.DeleteCompany(name);
            return Ok("Deleted");
        }
    }
}
