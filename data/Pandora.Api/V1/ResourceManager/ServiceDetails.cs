using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager;

[ApiController]
public class ServiceDetailsController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;
    public ServiceDetailsController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/microsoft-graph/{apiVersion}/services/{serviceName}")]
    public IActionResult MicrosoftGraph(string apiVersion, string serviceName)
    {
        var definitionType = apiVersion.ParseServiceDefinitionTypeFromApiVersion();
        if (definitionType == null)
        {
            return BadRequest($"the API Version {apiVersion} is not supported");
        }

        return ForService(serviceName, definitionType.Value, $"/v1/microsoft-graph/{apiVersion}");
    }

    [Route("/v1/resource-manager/services/{serviceName}")]
    public IActionResult ResourceManager(string serviceName)
    {
        return ForService(serviceName, ServiceDefinitionType.ResourceManager, "/v1/resource-manager");
    }

    private IActionResult ForService(string serviceName, ServiceDefinitionType definitionType, string routePrefix)
    {
        var service = _repo.GetByName(serviceName, definitionType);
        if (service == null)
        {
            return BadRequest("service not found");
        }

        return new JsonResult(MapResponse(service, serviceName, routePrefix));
    }

    private static ServiceDetailsResponse MapResponse(ServiceDefinition version, string serviceName, string routePrefix)
    {
        return new ServiceDetailsResponse
        {
            ResourceProvider = version.ResourceProvider!,
            TerraformPackageName = version.TerraformPackageName,
            TerraformUri = $"/v1/resource-manager/services/{serviceName}/terraform",
            Versions = version.Versions.ToDictionary(v => v.Version, v => MapVersion(v, serviceName, routePrefix))
        };
    }

    private static VersionDetails MapVersion(VersionDefinition version, string serviceName, string routePrefix)
    {
        return new VersionDetails
        {
            Generate = version.Generate,
            Preview = version.Preview,
            Uri = $"{routePrefix}/services/{serviceName}/{version.Version}"
        };
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

        [JsonPropertyName("terraformPackageName")]
        public string? TerraformPackageName { get; set; }

        [JsonPropertyName("terraformUri")]
        public string TerraformUri { get; set; }

        [JsonPropertyName("versions")]
        public Dictionary<string, VersionDetails> Versions { get; set; }
    }
}