using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager;

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
            Resources = version.Resources.ToDictionary(a => a.Name,
                a => MapResourceForApiVersion(a, versionNumber, serviceName)),
            Source = MapSource(version.Source),
            TerraformUri = $"/v1/resource-manager/services/{serviceName}/{versionNumber}/terraform",
        };
    }

    private static string MapSource(Data.Models.ApiDefinitionsSource input)
    {
        switch (input)
        {
            case Data.Models.ApiDefinitionsSource.HandWritten:
                return ApiDefinitionsSource.HandWritten.ToString();
            case Data.Models.ApiDefinitionsSource.ResourceManagerRestApiSpecs:
                return ApiDefinitionsSource.ResourceManagerRestApiSpecs.ToString();
        }

        throw new NotSupportedException($"unsupported/unmapped Source {input.ToString()}");
    }

    private static ApiTypeInformation MapResourceForApiVersion(ResourceDefinition definition, string versionNumber, string serviceName)
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

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("terraformUri")]
    public string TerraformUri { get; set; }
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
}