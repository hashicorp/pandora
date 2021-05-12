using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager
{
    [ApiController]
    public class ServiceDetailsController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;
        public ServiceDetailsController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }
        
        [Route("/v1/resource-manager/services/{serviceName}")]
        public IActionResult ResourceManager(string serviceName)
        {
            return ForService(serviceName);
        }

        private IActionResult ForService(string serviceName)
        {
            var service = _repo.GetByName(serviceName, true);
            if (service == null) {
                return BadRequest("service not found");
            }

            return new JsonResult(MapResponse(service, serviceName));
        }

        private static ServiceDetailsResponse MapResponse(ServiceDefinition version, string serviceName)
        {
            return new ServiceDetailsResponse{
                ResourceProvider = version.ResourceManager ? version.ResourceProvider! : null,
                Terraform = MapTerraformResponse(version, serviceName),
                Versions = version.Versions.ToDictionary(v => v.Version, v => MapVersion(v, serviceName))
            };
        }

        private static TerraformResponse MapTerraformResponse(ServiceDefinition version, string serviceName)
        {
            var dataSources = version.DataSources.ToDictionary(ds => ds.ResourceLabel, r => MapResource(r, serviceName));
            var resources = version.Resources.ToDictionary(r => r.ResourceLabel, r => MapResource(r, serviceName));
            return new TerraformResponse
            {
                DataSources = dataSources,
                Resources = resources,
            };
        }

        private static TerraformObjectDetails MapResource(TerraformResourceDefinition definition, string serviceName)
        {
            var resourceTypeSegment = definition.IsDataSource ? "data-source" : "resource";
            return new TerraformObjectDetails
            {
                Generate = definition.Generate,
                Uri = $"/v1/resource-manager/services/{serviceName}/terraform-{resourceTypeSegment}/{definition.ResourceLabel}"
            };
        }

        private static VersionDetails MapVersion(VersionDefinition version, string serviceName)
        {
            return new VersionDetails
            {
                Generate = version.Generate,
                Preview = version.Preview,
                Uri = $"/v1/resource-manager/services/{serviceName}/{version.Version}"
            };
        }

        private class TerraformObjectDetails
        {
            [JsonPropertyName("generate")]
            public bool Generate { get; set; }
        
            [JsonPropertyName("uri")]
            public string Uri { get; set; }
        }

        private class TerraformResponse
        {
            [JsonPropertyName("dataSources")]
            public Dictionary<string, TerraformObjectDetails> DataSources { get; set; }

            [JsonPropertyName("resources")]
            public Dictionary<string, TerraformObjectDetails> Resources { get; set; }
        }

        private class VersionDetails
        {
            [JsonPropertyName("generate")]
            public bool Generate { get; set; }
        
            [JsonPropertyName("preview")]
            public bool Preview { get; set; }
        
            [JsonPropertyName("uri")]
            public string Uri { get; set; }
        }

        private class ServiceDetailsResponse
        {
            [JsonPropertyName("resourceProvider")]
            public string? ResourceProvider { get; set; }
        
            [JsonPropertyName("versions")]
            public Dictionary<string, VersionDetails> Versions { get; set; }

            [JsonPropertyName("terraform")]
            public TerraformResponse Terraform { get; set; }
        }
    }
}