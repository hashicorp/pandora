using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
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

    [Route("/v1/resource-manager/services/{serviceName}")]
    public IActionResult ResourceManager(string serviceName)
    {
        return ForService(serviceName);
    }

    private IActionResult ForService(string serviceName)
    {
        var service = _repo.GetByName(serviceName, true);
        if (service == null)
        {
            return BadRequest("service not found");
        }

        return new JsonResult(MapResponse(service, serviceName));
    }

    private static ServiceDetailsResponse MapResponse(ServiceDefinition version, string serviceName)
    {
        return new ServiceDetailsResponse
        {
            ResourceProvider = version.ResourceManager ? version.ResourceProvider! : null,
            TerraformPackageName = serviceName == "Resources" ? "resources" : null, // TODO: implement this through
            Versions = version.Versions.ToDictionary(v => v.Version, v => MapVersion(v, serviceName))
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

        [JsonPropertyName("versions")]
        public Dictionary<string, VersionDetails> Versions { get; set; }
    }
}