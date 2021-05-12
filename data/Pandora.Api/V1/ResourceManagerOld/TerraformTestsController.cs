using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManagerOld
{
    [ApiController]
    public class TerraformTestsController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public TerraformTestsController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }

        [Route("/apis/v1/resource-manager/{serviceName}/terraform-resource/{resourceLabel}/tests")]
        public IActionResult ResourceManagerResource(string serviceName, string resourceLabel)
        {
            return TerraformFunctionInternal(serviceName, resourceLabel, true, false);
        }

        private IActionResult TerraformFunctionInternal(string serviceName, string resourceLabel, bool resourceManager, bool dataSource)
        {
            // TODO: implement me
            return new JsonResult(new {NotYet = "Implemented"});
        }
    }
}