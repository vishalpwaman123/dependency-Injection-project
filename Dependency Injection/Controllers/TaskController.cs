using Dependency_Injection.Interface;
using Dependency_Injection.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        private readonly IScopeService _scopeService1;
        private readonly IScopeService _scopeService2;

        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public TaskController(ITransientService transientService1,
            ITransientService transientService2,
            IScopeService scopeService1,
            IScopeService scopeService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        { 
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopeService1 = scopeService1;
            _scopeService2 = scopeService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskGuid()
        {
            try
            {
                //Create new Object
                var transient1 = _transientService1.GetTaskId();
                //Create new Object
                var transient2 = _transientService2.GetTaskId();
                //Create new Object => S1
                var scoped1 = _scopeService1.GetTaskId();
                //Use previews S1 Object 
                var scoped2 = _scopeService2.GetTaskId();
                //Create SS1 Object First time project run
                var singleton1 = _singletonService1.GetTaskId();
                //Use SS1 Object until end of project
                var singleton2 = _singletonService2.GetTaskId();
                var response = new GetTaskResponse
                {
                    transient1 = transient1,
                    transient2 = transient2,
                    scoped1 = scoped1,
                    scoped2 = scoped2,
                    singleton1 = singleton1,
                    singleton2 = singleton2,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
