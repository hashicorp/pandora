using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Pandora.Data.Models;
using Pandora.Data.Repositories;
using Pandora.Data.Transformers;

namespace Pandora.Api.V1.ResourceManager
{
    [ApiController]
    public class ServiceVersionController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public ServiceVersionController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }

        [Route("/v1/resource-manager/services/{serviceName}/{apiVersion}")]
        public IActionResult ResourceManager(string serviceName, string apiVersion)
        {
            return ForService(serviceName, apiVersion);
        }

        private IActionResult ForService(string serviceName, string apiVersion)
        {
            var service = _repo.GetByName(serviceName, true);
            if (service == null)
            {
                return BadRequest("service not found");
            }

            var version = service.Versions.FirstOrDefault(v => v.Version == apiVersion);
            if (version == null)
            {
                return BadRequest($"version {apiVersion} was not found");
            }

            return new JsonResult(MapResponse(version, apiVersion, serviceName));
        }

        private static ApiVersionResponse MapResponse(VersionDefinition version, string versionNumber, string serviceName)
        {
            return new ApiVersionResponse
            {
                Resources = version.Apis.ToDictionary(a => a.Name,
                    a => MapResourceForApiVersion(a, versionNumber, serviceName)),
            };
        }

        private static ApiTypeInformation MapResourceForApiVersion(ApiDefinition definition, string versionNumber, string serviceName)
        {
            return new ApiTypeInformation
            {
                OperationsUri = $"/v1/resource-manager/services/{serviceName}/{versionNumber}/{definition.Name}/operations",
                SchemaUri = $"/v1/resource-manager/services/{serviceName}/{versionNumber}/{definition.Name}/schema",
            };
        }
    }

    public class ApiVersionResponse
    {
        [JsonPropertyName("resources")]
        public Dictionary<string, ApiTypeInformation> Resources { get; set; }
    }

    public class ApiTypeInformation
    {
        [JsonPropertyName("operationsUri")]
        public string OperationsUri { get; set; }

        [JsonPropertyName("schemaUri")]
        public string SchemaUri { get; set; }
    }
}