using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.Controllers;

[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;

    public ServicesController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("/v1/microsoft-graph/{apiVersion}/services")]
    public IActionResult MicrosoftGraph(string apiVersion)
    {
        var definitionType = apiVersion.ParseServiceDefinitionTypeFromApiVersion();
        if (definitionType == null)
        {
            return BadRequest($"the API Version {apiVersion} is not supported");
        }

        return ForServiceDefinitionType(definitionType.Value, $"/v1/microsoft-graph/{apiVersion}");
    }

    [HttpGet]
    [Route("/v1/resource-manager/services")]
    public IActionResult ResourceManager()
    {
        return ForServiceDefinitionType(ServiceDefinitionType.ResourceManager, "/v1/resource-manager");
    }

    private IActionResult ForServiceDefinitionType(ServiceDefinitionType definitionType, string routePrefix)
    {
        var services = _repo.GetAll(definitionType).ToDictionary(a => a.Name, a => ToServiceReference(a, routePrefix));
        return new JsonResult(new ServicesResponse
        {
            Services = services,
        });
    }

    public class ServicesResponse
    {
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

    private static ServiceReference ToServiceReference(ServiceDefinition input, string routePrefix)
    {
        return new ServiceReference
        {
            Generate = input.Generate,
            Uri = $"{routePrefix}/services/{input.Name}"
        };
    }
}