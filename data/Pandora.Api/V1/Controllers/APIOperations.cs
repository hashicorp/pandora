using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.Controllers;

[ApiController]
public class ApiOperationsController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;

    public ApiOperationsController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/microsoft-graph/{apiVersion}/services/{serviceName}/{serviceApiVersion}/{resourceName}/operations")]
    public IActionResult MicrosoftGraph(string apiVersion, string serviceName, string serviceApiVersion, string resourceName)
    {
        var definitionType = apiVersion.ParseServiceDefinitionTypeFromApiVersion();
        if (definitionType == null)
        {
            return BadRequest($"the API Version {apiVersion} is not supported");
        }

        return ForService(serviceName, serviceApiVersion, resourceName, definitionType.Value);
    }

    [Route("/v1/resource-manager/services/{serviceName}/{serviceApiVersion}/{resourceName}/operations")]
    public IActionResult ResourceManager(string serviceName, string serviceApiVersion, string resourceName)
    {
        return ForService(serviceName, serviceApiVersion, resourceName, ServiceDefinitionType.ResourceManager);
    }

    private IActionResult ForService(string serviceName, string serviceApiVersion, string resourceName, ServiceDefinitionType definitionType)
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

        var api = version.Resources.FirstOrDefault(a => a.Name == resourceName);
        if (api == null)
        {
            return BadRequest($"resource {resourceName} was not found");
        }

        return new JsonResult(MapResponse(api, service));
    }

    private static ApiOperationsResponse MapResponse(ResourceDefinition resource, ServiceDefinition service)
    {
        var metaData = new OperationMetaData
        {
            ResourceProvider = service.ResourceProvider!,
        };

        return new ApiOperationsResponse
        {
            MetaData = metaData,
            Operations = resource.Operations.ToDictionary(o => o.Name, MapOperation)
        };
    }

    private static ApiOperationDefinition MapOperation(OperationDefinition definition)
    {
        return new ApiOperationDefinition
        {
            ContentType = definition.ContentType,
            Method = definition.Method,
            LongRunning = definition.LongRunning,
            ExpectedStatusCodes = definition.ExpectedStatusCodes,
            ResourceIdName = definition.ResourceIdName,
            UriSuffix = definition.UriSuffix,
            FieldContainingPaginationDetails = definition.FieldContainingPaginationDetails,
            RequestObject = ApiObjectDefinitionMapper.Map(definition.RequestObject),
            ResponseObject = ApiObjectDefinitionMapper.Map(definition.ResponseObject),
            Options = MapOptions(definition.Options),
        };
    }

    private static Dictionary<string, ApiOperationOption> MapOptions(List<OptionDefinition> input)
    {
        var output = new Dictionary<string, ApiOperationOption>();

        foreach (var definition in input)
        {
            var objectDefinition = ApiObjectDefinitionMapper.Map(definition.ObjectDefinition);
            output[definition.Name] = new ApiOperationOption
            {
                HeaderName = definition.HeaderName,
                QueryStringName = definition.QueryStringName,
                ObjectDefinition = objectDefinition,
                Required = definition.Required,
            };
        }

        return output;
    }

    public class ApiOperationsResponse
    {
        [JsonPropertyName("operations")]
        public Dictionary<string, ApiOperationDefinition> Operations { get; set; }

        [JsonPropertyName("metaData")]
        public OperationMetaData? MetaData { get; set; }
    }

    public class ApiOperationDefinition
    {
        [JsonPropertyName("contentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("expectedStatusCodes")]
        public List<int> ExpectedStatusCodes { get; set; }

        [JsonPropertyName("longRunning")]
        public bool LongRunning { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("requestObject")]
        public ApiObjectDefinition? RequestObject { get; set; }

        [JsonPropertyName("resourceIdName")]
        public string? ResourceIdName { get; set; }

        [JsonPropertyName("responseObject")]
        public ApiObjectDefinition? ResponseObject { get; set; }

        [JsonPropertyName("uriSuffix")]
        public string UriSuffix { get; set; }

        [JsonPropertyName("fieldContainingPaginationDetails")]
        public string FieldContainingPaginationDetails { get; set; }

        [JsonPropertyName("options")]
        public Dictionary<string, ApiOperationOption> Options { get; set; }
    }

    public class ApiOperationOption
    {
        [JsonPropertyName("headerName")]
        public string? HeaderName { get; set; }

        [JsonPropertyName("queryStringName")]
        public string? QueryStringName { get; set; }

        [JsonPropertyName("objectDefinition")]
        public ApiObjectDefinition ObjectDefinition { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }

    public class OperationMetaData
    {
        [JsonPropertyName("resourceProvider")]
        public string? ResourceProvider { get; set; }

        // TODO: API Availability Details (e.g. GA in Public, PrivatePreview in China?)
    }
}