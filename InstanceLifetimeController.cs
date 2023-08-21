using Dapper.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceLifetimeController : ControllerBase
    {
        private readonly ITransientInstanceLifetimeService _operationTransient;
        private readonly ISingletonInstanceLifetimeService _operationSingleton;
        private readonly IScopedInstanceLifetimeService _operationScoped;

        private readonly IInstanceLifetimeService _lifetimeService;

        public InstanceLifetimeController(IScopedInstanceLifetimeService operationScoped, 
            ISingletonInstanceLifetimeService operationSingleton, 
            ITransientInstanceLifetimeService operationTransient,
            IInstanceLifetimeService lifetimeService)
        {
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationTransient = operationTransient;
            _lifetimeService = lifetimeService;
        }

        [HttpGet("transient")]
        public IActionResult GetTransientInstance()
        {
            return Ok($"Transient :- {_operationTransient.OperationId}");
        }

        [HttpGet("singleton")]
        public IActionResult GetSingletonInstance()
        {
            return Ok($"Singleton :- {_operationSingleton.OperationId}");
        }


        [HttpGet("scoped")]
        public IActionResult GetScopedInstance()
        {
            return Ok($"Scoped :- {_operationScoped.OperationId}");
        }
    }
}
