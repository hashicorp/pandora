using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.Controllers;

[ApiController]
public class ServiceVersionController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;

    public ServiceVersionController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/microsoft-graph/{apiVersion}/services/{serviceName}/{serviceApiVersion}")]
    public IActionResult MicrosoftGraph(string apiVersion, string serviceName, string serviceApiVersion)
    {
        var definitionType = apiVersion.ParseServiceDefinitionTypeFromApiVersion();
        if (definitionType == null)
        {
            return BadRequest($"the API Version {apiVersion} is not supported");
        }

        return ForService(serviceName, serviceApiVersion, definitionType.Value, "/v1/microsoft-graph/{apiVersion}");
    }

    [Route("/v1/resource-manager/services/{serviceName}/{serviceApiVersion}")]
    public IActionResult ResourceManager(string serviceName, string serviceApiVersion)
    {
        return ForService(serviceName, serviceApiVersion, ServiceDefinitionType.ResourceManager, "/v1/resource-manager");
    }

    private IActionResult ForService(string serviceName, string serviceApiVersion, ServiceDefinitionType definitionType, string routePrefix)
    {
        var service = _repo.GetByName(serviceName, definitionType);
        if (service == null)
        {
            return BadRequest("service not found");
        }

        var version = service.Versions.FirstOrDefault(v => v.Version == serviceApiVersion);
        if (version == null)
        {
            return BadRequest($"version {serviceApiVersion} was not found");
        }

        return new JsonResult(MapResponse(version, serviceName, serviceApiVersion, routePrefix));
    }

    private static ApiVersionResponse MapResponse(VersionDefinition version, string serviceName, string serviceApiVersion, string routePrefix)
    {
        return new ApiVersionResponse
        {
            Resources = version.Resources.ToDictionary(a => a.Name,
                a => MapResourceForApiVersion(a, serviceName, serviceApiVersion, routePrefix)),
            Source = MapSource(version.Source),
        };
    }

    private static string MapSource(Data.Models.ApiDefinitionsSource input)
    {
        switch (input)
        {
            // TODO: support a Graph source
            case Data.Models.ApiDefinitionsSource.HandWritten:
                return ApiDefinitionsSource.HandWritten.ToString();
            case Data.Models.ApiDefinitionsSource.ResourceManagerRestApiSpecs:
                return ApiDefinitionsSource.ResourceManagerRestApiSpecs.ToString();
        }

        throw new NotSupportedException($"unsupported/unmapped Source {input.ToString()}");
    }

    private static ApiTypeInformation MapResourceForApiVersion(ResourceDefinition definition, string serviceName, string serviceApiVersion, string routePrefix)
    {
        return new ApiTypeInformation
        {
            OperationsUri = $"{routePrefix}/services/{serviceName}/{serviceApiVersion}/{definition.Name}/operations",
            SchemaUri = $"{routePrefix}/services/{serviceName}/{serviceApiVersion}/{definition.Name}/schema",
        };
    }


    public class ApiVersionResponse
    {
        [JsonPropertyName("resources")]
        public Dictionary<string, ApiTypeInformation> Resources { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }

    public class ApiTypeInformation
    {
        [JsonPropertyName("operationsUri")]
        public string OperationsUri { get; set; }

        [JsonPropertyName("schemaUri")]
        public string SchemaUri { get; set; }
    }

    public enum ApiDefinitionsSource
    {
        Unknown = 0,

        [Description("ResourceManagerRestApiSpecs")]
        ResourceManagerRestApiSpecs,

        [Description("HandWritten")]
        HandWritten

        // TODO: support for Graph
    }
}
