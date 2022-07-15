using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager;

[ApiController]
public class TerraformController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;

    public TerraformController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/resource-manager/services/{serviceName}/{apiVersion}/terraform")]
    public IActionResult Terraform(string serviceName, string apiVersion)
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

        return new JsonResult(MapResponse(version));
    }

    private static TerraformV1Response MapResponse(VersionDefinition version)
    {
        return new TerraformV1Response
        {
            DataSources = new Dictionary<string, DataSourceResponse>(),
            Resources = version.TerraformResources.ToDictionary(k => k.ResourceLabel, MapResourceDefinition),
        };
    }

    private static ResourceResponse MapResourceDefinition(TerraformResourceDefinition input)
    {
        return new ResourceResponse
        {
            DeleteMethod = MapMethodDefinition(input.DeleteMethod),
            DisplayName = input.DisplayName,
            Resource = input.Resource,
            GenerateSchema = input.GenerateSchema,
            GenerateIdValidation = input.GenerateIDValidationFunction,
            ResourceName = input.ResourceName,
            ResourceIdName = input.ResourceIdName,
        };
    }

    private static MethodDefinition MapMethodDefinition(TerraformMethodDefinition input)
    {
        return new MethodDefinition
        {
            Generate = input.Generate,
            MethodName = input.MethodName,
            TimeoutInMinutes = input.TimeoutInMinutes,
        };
    }

    private class TerraformV1Response
    {
        [JsonPropertyName("dataSources")]
        public Dictionary<string, DataSourceResponse> DataSources { get; set; }

        [JsonPropertyName("resources")]
        public Dictionary<string, ResourceResponse> Resources { get; set; }
    }

    private class DataSourceResponse
    {
        // TODO: stuff and things - don't forget to account for Single vs Plural DS's
    }

    private class ResourceResponse
    {
        // TODO: Schema [incl. Docs], Mappings, Tests etc
        [JsonPropertyName("deleteMethod")]
        public MethodDefinition DeleteMethod { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => DeleteMethod.Generate || GenerateSchema || GenerateIdValidation;

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("generateIdValidation")]
        public bool GenerateIdValidation { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("resourceIdName")]
        public string ResourceIdName { get; set; }

        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }
    }

    private class MethodDefinition
    {
        [JsonPropertyName("generate")]
        public bool Generate { get; set; }

        [JsonPropertyName("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyName("timeoutInMinutes")]
        public int TimeoutInMinutes { get; set; }
    }
}