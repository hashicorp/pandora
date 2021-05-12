using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager
{
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public ServicesController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        [Route("/v1/resource-manager/services")]
        public IActionResult ResourceManager()
        {
            return new JsonResult(new ServicesResponse
            {
                Services = GetServices(true),
            });
        }
    
        public class ServicesResponse {
            [JsonPropertyName("services")]
            public Dictionary<string, ServiceReference> Services { get; set; }
        }
    
        public class ServiceReference
        {
            [JsonPropertyName("generate")]
            public bool Generate { get; set; }
        
            [JsonPropertyName("uri")]
            public string Uri { get; set; }
        }

        private static ServiceReference ToServiceReference(ServiceDefinition input)
        {
            return new ServiceReference
            {
                Generate = input.Generate,
                Uri = $"/v1/resource-manager/services/{input.Name}"
            };
        }

        private Dictionary<string, ServiceReference> GetServices(bool resourceManager)
        {
            return _repo.GetAll(resourceManager)
                .ToDictionary(a => a.Name, ToServiceReference);            
        }
    }
}
